using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public booksController(LibrarydbContext context, IBook book)
        {
            _context = context;
            _book = book;
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
    }
}
