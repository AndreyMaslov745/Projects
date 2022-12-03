using WebApplication1.Extensions.Factory.Interfaces;

namespace WebApplication1.Extensions.Factory;

public class NumberFactory : INumberFactory
{
    public AbstractFactory CreateFactory(string type)
    {
        AbstractFactory factory = type switch
        {
            nameof(Double) => new RandomDoubleFactory(),
            nameof(Int32) => new RandomIntFactory(),
            nameof(Int64) => new RandomLongFactory(),
            nameof(Single) => new RandomFloatFactory(),
            _ => new RandomIntFactory()
        };
        return factory;
    }
}
public interface IRandomFactory
{ 
    IComparable CreateNumber();
}

public abstract class AbstractFactory
{
    public virtual IComparable CreateNumber() => 0;
}

public class RandomIntFactory : AbstractFactory
{
    public override IComparable CreateNumber() => new Random().Next();
}

public class RandomDoubleFactory : AbstractFactory
{
    public override IComparable CreateNumber() => new Random().NextDouble();
}

public class RandomFloatFactory : AbstractFactory
{
    public override IComparable CreateNumber() => new Random().NextSingle();
}

public class RandomLongFactory : AbstractFactory
{
    public override IComparable CreateNumber()=> new Random().NextInt64();
}
