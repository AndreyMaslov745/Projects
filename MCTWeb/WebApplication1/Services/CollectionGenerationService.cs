using System.Data.SqlTypes;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Extensions.Factory.Interfaces;

namespace WebApplication1.Extensions;

public class CollectionGenerationService
{
    private readonly INumberFactory _numberFactory;

    public CollectionGenerationService(INumberFactory numberFactory)
    {
        _numberFactory = numberFactory;
    }

    public ICollection<IComparable> InstantiateRandomCollection<T>(int lenght) where T : struct, IComparable
    {
        var factory = _numberFactory.CreateFactory(typeof(T).Name);
        var resCollection = new List<IComparable>();
        for (int i = 0; i <= lenght; i++)
        {
            resCollection.Add(factory.CreateNumber());
        }
        return resCollection;
    }
}
