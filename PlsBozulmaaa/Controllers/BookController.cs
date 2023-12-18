using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlsBozulmaaa.Constants;

namespace PlsBozulmaaa.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db; // Replace with your actual DbContext

        public BookController(ApplicationDbContext context)
        {
            _db = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(_db.Genres, "Id", "GenreName");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Book book)
        {

            
                try
                {
                    if (ModelState.IsValid)
                    {
                        _db.Add(book);
                        await _db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    // Handle validation errors
                    return View(book);
                }
                catch (Exception ex)
                {
                    // Log or print the exception details
                    Console.WriteLine(ex.Message);
                    return View(book); // You may want to handle the exception differently
                }
            }
            //if (ModelState.IsValid)
            //{
            //    _db.Add(book);
            //    await _db.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index)); // Redirect to appropriate view
            //}

            //return View(book);
        
    }
}
