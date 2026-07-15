using System.Buffers;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.JsonWebTokens;

var tokenPayload = Benchmark.AuthorizationHeader.ToString().AsSpan()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim().ToString();
string[] ids =
[
    "037e2e93-7cf6-4716-bd7f-84e19fa691f0",
    Benchmark.JwtHandler.ReadJwtToken(tokenPayload).Id,
    Benchmark.NewerJwtHandler.ReadJsonWebToken(tokenPayload).Id,
    Benchmark.GetJwtIdHack(tokenPayload)
];

if (ids.Distinct().Count() != 1)
{
    throw new Exception("Incorrect jwt ids");
}

_ = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class Benchmark
{
    public static readonly JwtSecurityTokenHandler JwtHandler = new();
    public static readonly JsonWebTokenHandler NewerJwtHandler = new();
    
    public static StringValues AuthorizationHeader => "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMiwicmFuZG9tX2NsYWltXzEiOiJzdHVmZiIsInJhbmRvbV9jbGFpbV8yIjoibW9yZV9zdHVmZiIsInJhbmRvbV9jbGFpbV8zIjoiZXZlbl9tb3JlX3N0dWZmIiwicmFuZG9tX2NsYWltXzQiOiJzdHVmZiIsInJhbmRvbV9jbGFpbV81IjoibW9yZV9zdHVmZiIsInJhbmRvbV9jbGFpbV82IjoiZXZlbl9tb3JlX3N0dWZmIiwicmFuZG9tX2NsYWltXzciOiJMb3JlbSBpcHN1bSBkb2xvciBzaXQgYW1ldCwgY29uc2VjdGV0dXIgYWRpcGlzY2luZyBlbGl0LCBzZWQgZG8gZWl1c21vZCB0ZW1wb3IgaW5jaWRpZHVudCB1dCBsYWJvcmUgZXQgZG9sb3JlIG1hZ25hIGFsaXF1YS4gVXQgZW5pbSBhZCBtaW5pbSB2ZW5pYW0sIHF1aXMgbm9zdHJ1ZCBleGVyY2l0YXRpb24gdWxsYW1jbyBsYWJvcmlzIG5pc2kgdXQgYWxpcXVpcCBleCBlYSBjb21tb2RvIGNvbnNlcXVhdC4gRHVpcyBhdXRlIGlydXJlIGRvbG9yIGluIHJlcHJlaGVuZGVyaXQgaW4gdm9sdXB0YXRlIHZlbGl0IGVzc2UgY2lsbHVtIGRvbG9yZSBldSBmdWdpYXQgbnVsbGEgcGFyaWF0dXIuIEV4Y2VwdGV1ciBzaW50IG9jY2FlY2F0IGN1cGlkYXRhdCBub24gcHJvaWRlbnQsIHN1bnQgaW4gY3VscGEgcXVpIG9mZmljaWEgZGVzZXJ1bnQgbW9sbGl0IGFuaW0gaWQgZXN0IGxhYm9ydW0uIiwianRpIjoiMDM3ZTJlOTMtN2NmNi00NzE2LWJkN2YtODRlMTlmYTY5MWYwIn0.IWAbekIBsFzs7N1Nv3J48tn6XJlrQbOhogvrWjxEI7k";

    [Benchmark(Baseline = true)]
    public string NativeTokenHandler()
    {
        var tokenPayload = AuthorizationHeader.ToString().AsSpan()[JwtBearerDefaults.AuthenticationScheme.Length..]
            .Trim().ToString();
        return JwtHandler.ReadJwtToken(tokenPayload).Id;
    }

    [Benchmark]
    public string NewerNativeTokenHandler()
    {
        var tokenPayload = AuthorizationHeader.ToString().AsMemory()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim();
        return NewerJwtHandler.ReadJsonWebToken(tokenPayload).Id;
    }

    [Benchmark]
    public string Hack()
    {
        var tokenPayload = AuthorizationHeader.ToString().AsSpan()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim();
        return GetJwtIdHack(tokenPayload);
    }

    public static string GetJwtIdHack(ReadOnlySpan<char> token)
    {
        var firstDot = token.IndexOf('.');
        ReadOnlySpan<char> remainder = token[(firstDot + 1)..];
        var secondDot = remainder.IndexOf('.');
        ReadOnlySpan<char> payloadBase64Url = remainder[..secondDot];
        var rentedBuffer = ArrayPool<byte>.Shared.Rent(payloadBase64Url.Length);
        try
        {
            if (!TryDecodeBase64Url(payloadBase64Url, rentedBuffer, out int bytesWritten))
            {
                throw new Exception("Doesn't happen in this benchmark");
            }

            ReadOnlySpan<byte> jsonBytes = rentedBuffer.AsSpan(0, bytesWritten);
            var reader = new Utf8JsonReader(jsonBytes);
            while (reader.Read())
            {
                if (reader.TokenType != JsonTokenType.PropertyName || !reader.ValueTextEquals("jti")) continue;
                if (!reader.Read() || reader.TokenType != JsonTokenType.String) continue;
                return reader.GetString()!;
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(rentedBuffer);
        }

        throw new Exception("Doesn't happen in this benchmark");
    }

    static bool TryDecodeBase64Url(ReadOnlySpan<char> base64Url, Span<byte> destination, out int bytesWritten)
    {
        bytesWritten = 0;

        var requiredPadding = (4 - base64Url.Length % 4) % 4;
        var standardBase64Length = base64Url.Length + requiredPadding;

        var rentedChars = ArrayPool<char>.Shared.Rent(standardBase64Length);
        var base64Chars = rentedChars.AsSpan(0, standardBase64Length);

        try
        {
            for (var i = 0; i < base64Url.Length; i++)
            {
                var c = base64Url[i];
                base64Chars[i] = c switch
                {
                    '-' => '+',
                    '_' => '/',
                    _ => c
                };
            }

            for (var i = 0; i < requiredPadding; i++)
            {
                base64Chars[base64Url.Length + i] = '=';
            }

            return Convert.TryFromBase64Chars(base64Chars, destination, out bytesWritten);
        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentedChars);
        }
    }
}