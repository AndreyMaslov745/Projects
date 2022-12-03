using Microsoft.AspNetCore.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models.Enum;

namespace WebApplication1.Controllers;

[Route("/api/[controller]")]
public class ArraySortController : ControllerBase
{
    private readonly CollectionGenerationService _collectionGenerationServices;

    public ArraySortController(CollectionGenerationService collectionGenerationServices)
    {
        _collectionGenerationServices = collectionGenerationServices;
    }

    [HttpGet]
    [Route("/generate-array")]
    public IActionResult GenerateArray(int lenght, ArrayType type) => type switch
    {
        ArrayType.Int => Ok(_collectionGenerationServices.InstantiateRandomCollection<int>(lenght)),
        ArrayType.Double => Ok(_collectionGenerationServices.InstantiateRandomCollection<double>(lenght)),
        ArrayType.Float => Ok(_collectionGenerationServices.InstantiateRandomCollection<float>(lenght)),
        ArrayType.Long => Ok(_collectionGenerationServices.InstantiateRandomCollection<long>(lenght)),
        _ => BadRequest("Wrong type")
    };
}