using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; //Connection to the database

        public IndexModel(ApplicationDbContext db)
        {
            _db = db; 
        }

        public IEnumerable<Book> Books { get; set; } //This will be what holds the list of books
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync(); //Step into the book table and add them to a list
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();


            return RedirectToPage("Index");
        }
    }
}
