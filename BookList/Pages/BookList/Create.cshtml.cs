using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() //We use IActionResult because we'll be rediredcting to a new page
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book); //Add book to a queue
                await _db.SaveChangesAsync(); //Save changes and pushes them to the database
                return RedirectToPage("Index"); //Redirect to index page when finished
            }
            else
            {
                return Page();
            }
        }
            
            
    }
}
