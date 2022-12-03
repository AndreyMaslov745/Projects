using Microsoft.AspNetCore.Mvc;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly CollectionGenerationService _collectionGenerationServices;

    public HomeController(CollectionGenerationService collectionGenerationServices)
    {
        _collectionGenerationServices = collectionGenerationServices;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var targetCollection = _collectionGenerationServices.InstantiateRandomCollection<double>(10).ToArray();
        return View(targetCollection);
    }
}