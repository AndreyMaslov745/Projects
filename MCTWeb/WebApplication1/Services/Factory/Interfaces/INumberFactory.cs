namespace WebApplication1.Extensions.Factory.Interfaces;

public interface INumberFactory
{
    AbstractFactory CreateFactory(string type);
}