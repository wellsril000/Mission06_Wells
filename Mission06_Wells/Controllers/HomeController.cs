using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Wells.Models;

namespace Mission06_Wells.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context; // this creates a more permanent variable 
    public HomeController(MovieCollectionContext movieName) //Constructor
    {
        _context = movieName;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    public IActionResult Confirmation()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(NewMovie newMovie)
    {
        _context.Movies.Add(newMovie); // This adds the new movie record to the database 
        _context.SaveChanges();
        return View("Confirmation", newMovie);
        
    }

}
   