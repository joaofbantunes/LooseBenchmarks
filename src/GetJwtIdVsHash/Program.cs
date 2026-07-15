using System.Buffers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.JsonWebTokens;

_ = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class Benchmark
{
    private static readonly JwtSecurityTokenHandler JwtHandler = new();
    private static readonly JsonWebTokenHandler NewerJwtHandler = new();

    private static StringValues AuthorizationHeader => "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMiwicmFuZG9tX2NsYWltXzEiOiJzdHVmZiIsInJhbmRvbV9jbGFpbV8yIjoibW9yZV9zdHVmZiIsInJhbmRvbV9jbGFpbV8zIjoiZXZlbl9tb3JlX3N0dWZmIiwicmFuZG9tX2NsYWltXzQiOiJzdHVmZiIsInJhbmRvbV9jbGFpbV81IjoibW9yZV9zdHVmZiIsInJhbmRvbV9jbGFpbV82IjoiZXZlbl9tb3JlX3N0dWZmIiwicmFuZG9tX2NsYWltXzciOiJMb3JlbSBpcHN1bSBkb2xvciBzaXQgYW1ldCwgY29uc2VjdGV0dXIgYWRpcGlzY2luZyBlbGl0LCBzZWQgZG8gZWl1c21vZCB0ZW1wb3IgaW5jaWRpZHVudCB1dCBsYWJvcmUgZXQgZG9sb3JlIG1hZ25hIGFsaXF1YS4gVXQgZW5pbSBhZCBtaW5pbSB2ZW5pYW0sIHF1aXMgbm9zdHJ1ZCBleGVyY2l0YXRpb24gdWxsYW1jbyBsYWJvcmlzIG5pc2kgdXQgYWxpcXVpcCBleCBlYSBjb21tb2RvIGNvbnNlcXVhdC4gRHVpcyBhdXRlIGlydXJlIGRvbG9yIGluIHJlcHJlaGVuZGVyaXQgaW4gdm9sdXB0YXRlIHZlbGl0IGVzc2UgY2lsbHVtIGRvbG9yZSBldSBmdWdpYXQgbnVsbGEgcGFyaWF0dXIuIEV4Y2VwdGV1ciBzaW50IG9jY2FlY2F0IGN1cGlkYXRhdCBub24gcHJvaWRlbnQsIHN1bnQgaW4gY3VscGEgcXVpIG9mZmljaWEgZGVzZXJ1bnQgbW9sbGl0IGFuaW0gaWQgZXN0IGxhYm9ydW0uIiwianRpIjoiMDM3ZTJlOTMtN2NmNi00NzE2LWJkN2YtODRlMTlmYTY5MWYwIn0.IWAbekIBsFzs7N1Nv3J48tn6XJlrQbOhogvrWjxEI7k";


    [Benchmark(Baseline = true)]
    public string NativeTokenHandler()
    {
        var tokenPayload  = AuthorizationHeader.ToString().AsSpan()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim().ToString();
        return JwtHandler.ReadJwtToken(tokenPayload).Id;
    }
    
    [Benchmark]
    public string NewerNativeTokenHandler()
    {
        var tokenPayload  = AuthorizationHeader.ToString().AsMemory()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim();
        return NewerJwtHandler.ReadJsonWebToken(tokenPayload).Id;
    }

    [Benchmark]
    public string Hash()
    {
        var tokenPayload  = AuthorizationHeader.ToString().AsSpan()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim().ToString();
        var tokenBytes = Encoding.UTF8.GetBytes(tokenPayload);
        var hash = SHA256.HashData(tokenBytes);
        return Convert.ToBase64String(hash);
    }
    
    [Benchmark]
    public string SomeAllocationRemovalHash()
    {
        var tokenPayload  = AuthorizationHeader.ToString().AsSpan()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim().ToString();
        return Inner(tokenPayload);
    
        static string Inner(string token)
        {
            var tokenBytes = Encoding.UTF8.GetBytes(token);
            Span<byte> hashBytes = stackalloc byte[32];
            _ = SHA256.HashData(tokenBytes, hashBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
    
    [Benchmark]
    public string FurtherAllocationRemovalHash()
    {
        var tokenPayload  = AuthorizationHeader.ToString().AsSpan()[JwtBearerDefaults.AuthenticationScheme.Length..].Trim();
        return Inner(tokenPayload);
    
        static string Inner(ReadOnlySpan<char> token)
        {
            var byteCount = Encoding.UTF8.GetByteCount(token);
    
            var rentBuffer = ArrayPool<byte>.Shared.Rent(byteCount);
            var utf8Bytes = rentBuffer.AsSpan(0, byteCount);
    
            try
            {
                Encoding.UTF8.GetBytes(token, utf8Bytes);
                Span<byte> hashBytes = stackalloc byte[32];
                SHA256.HashData(utf8Bytes, hashBytes);
                return Convert.ToBase64String(hashBytes);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(rentBuffer);
            }
        }
    }
}