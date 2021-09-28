using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
public class Benchmark
{
    private static readonly InterfaceCaller InterfaceCaller = new InterfaceCaller();
    private static readonly GenericCaller GenericCaller = new GenericCaller();

    [Benchmark(Baseline = true)]
    public void InterfaceCallerWithClass()
        => InterfaceCaller.Call(new ClassCallable(i => i > 0));

    [Benchmark]
    public void InterfaceCallerWithStruct()
        => InterfaceCaller.Call(new StructCallable(i => i > 0));

    [Benchmark]
    public void GenericCallerWithClass()
        => GenericCaller.Call(new ClassCallable(i => i > 0));

    [Benchmark]
    public void GenericCallerWithStruct()
        => GenericCaller.Call(new StructCallable(i => i > 0));
}

public interface ICallable
{
    bool Call(int i);
}

public class ClassCallable : ICallable
{
    private readonly Func<int, bool> _innerCallable;

    public ClassCallable(Func<int, bool> innerCallable)
        => _innerCallable = innerCallable;

    public bool Call(int i) => _innerCallable(i);
}

public struct StructCallable : ICallable
{
    private readonly Func<int, bool> _innerCallable;

    public StructCallable(Func<int, bool> innerCallable)
        => _innerCallable = innerCallable;

    public bool Call(int i) => _innerCallable(i);
}

public class InterfaceCaller
{
    private const int SomeInt = 1;

    public void Call(ICallable callable)
        => callable.Call(SomeInt);
}

public class GenericCaller
{
    private const int SomeInt = 1;

    public void Call<TCallable>(TCallable callable) where TCallable : ICallable
        => callable.Call(SomeInt);
}
