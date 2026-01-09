using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Peterffy_Dominika_backend.Models;
using Peterffy_Dominika_backend.Services.Library;

namespace Peterffy_Dominika_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        private readonly LibrarydbContext _context;
        private readonly IBook _book;
        private readonly IConfiguration _config;

        public booksController(LibrarydbContext context, IBook book, IConfiguration config)
        {
            _context = context;
            _book = book;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            try
            {
                var requestResult = await _book.GetAllBooks();
                return Ok(requestResult);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    message = ex.Message
                });
            }
        }

        // 13.Feladat - új könyv hozzáadása
        [HttpPost]
        public async Task<ActionResult> AddBook(Book book, string UserID)
        {
            try
            {
                var uid = _config["UID"];
                if (string.IsNullOrEmpty(uid) || UserID != uid)
                {
                    return Unauthorized(new
                    {
                        message = "Nincs jogosultsága új könyv felvételéhez!"
                    });
                }

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return StatusCode(201, new
                {
                    message = "Könyv hozzáadása sikeresen megtörtént."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    message = ex.Message
                });
            }
        }
    }
}
