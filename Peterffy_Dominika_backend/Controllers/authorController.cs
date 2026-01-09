using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peterffy_Dominika_backend.Models;
using Peterffy_Dominika_backend.Services.Library;

namespace Peterffy_Dominika_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authorController : ControllerBase{
        private readonly LibrarydbContext _context;
        private readonly IAuthor _author;

        public authorController(LibrarydbContext context, IAuthor author)
        {
            _context = context;
            _author = author;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthorWithBooks(int id)
        {
            try
            {
                var requestResult = await _author.GetAuthorWithBooks(id);
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

        [HttpGet("count")]
        public async Task<ActionResult> GetAuthorsCount()
        {
            try
            {
                var requestResult = await _author.GetAuthorsCount();
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
