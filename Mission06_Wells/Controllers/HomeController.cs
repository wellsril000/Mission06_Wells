using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Wells.Models;
using Microsoft.EntityFrameworkCore;
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
      ViewBag.Categories = _context.Categories.ToList();
        return View(new NewMovie());
    }

    
    [HttpPost]
    public IActionResult AddMovie(NewMovie newMovie)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine("Attempting to create new movie");
            
            _context.Movies.Add(newMovie); // This adds the new movie record to the database 
            _context.SaveChanges();
            
            Console.WriteLine("Created new movie");
            return View("Confirmation", newMovie);
        }
        else
        {
             Console.WriteLine("⚠️ ModelState is NOT valid.");
                    
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine(error.ErrorMessage); // Check the console for errors
                    }
                    
                    ViewBag.Categories = _context.Categories.ToList();
                    return View();
        }
    }
    
    public IActionResult Confirmation()
    {
        return View();
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies.Include(m => m.Category).ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieToEdit= _context.Movies.Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("AddMovie", movieToEdit);
    }

    [HttpPost]
    public IActionResult Edit(NewMovie updatedMovie)
    {
        _context.Update(updatedMovie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movieToDelete = _context.Movies.Single(x => x.MovieId == id);
        // _context.Movies.Remove(movieToDelete);
        // _context.SaveChanges();
        
        return View(movieToDelete);
        
    }

    [HttpPost]
    public IActionResult Delete(NewMovie deleteMovie)
    {
        _context.Movies.Remove(deleteMovie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

}
   