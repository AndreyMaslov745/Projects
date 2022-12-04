using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("/api/[controller]")]
public class ArraySortController : ControllerBase
{

    [HttpGet]
    [Route("/generate-array")]
    public IActionResult GenerateArray(int lenght)
    {
        var array = IntArraySortingExtensions.GenerateRandom(lenght);
        var bubbleSorted = new SortViewModel("Bubble", array, (array) => array.BubbleSort());
        return Ok(bubbleSorted);
    }
}