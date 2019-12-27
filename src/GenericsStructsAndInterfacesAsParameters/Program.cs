using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace GenericsStructsAndInterfacesAsParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }

    [RankColumn]
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark(Baseline = true)]
        public void InterfaceCallerWithClass()
            => InterfaceCaller.Instance.Call(new ClassCallable(i => i > 0));

        [Benchmark]
        public void InterfaceCallerWithStruct()
            => InterfaceCaller.Instance.Call(new StructCallable(i => i > 0));

        [Benchmark]
        public void GenericCallerWithClass()
            => GenericCaller.Instance.Call(new ClassCallable(i => i > 0));

        [Benchmark]
        public void GenericCallerWithStruct()
            => GenericCaller.Instance.Call(new StructCallable(i => i > 0));
    }

    public interface ICallable
    {
        bool Call(int i);
    }

    public class ClassCallable : ICallable
    {
        private readonly Func<int, bool> _innerCallable;

        public ClassCallable(Func<int, bool> innerCallable)
        {
            _innerCallable = innerCallable;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool Call(int i) => _innerCallable(i);
    }

    public struct StructCallable : ICallable
    {
        private readonly Func<int, bool> _innerCallable;

        public StructCallable(Func<int, bool> innerCallable)
        {
            _innerCallable = innerCallable;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool Call(int i) => _innerCallable(i);
    }

    public class InterfaceCaller
    {
        private const int SomeInt = 1;

        private InterfaceCaller()
        {
        }

        public static InterfaceCaller Instance { get; } = new InterfaceCaller();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Call(ICallable callable) => callable.Call(SomeInt);
    }

    public class GenericCaller
    {
        private const int SomeInt = 1;

        private GenericCaller()
        {
        }

        public static GenericCaller Instance { get; } = new GenericCaller();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Call<TCallable>(TCallable callable) where TCallable : ICallable
            => callable.Call(SomeInt);
    }
}