using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peterffy_Dominika_backend.Models;
using Peterffy_Dominika_backend.Services.Library;

namespace Peterffy_Dominika_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {
        private readonly LibrarydbContext _context;
        private readonly ICategory _category;

        public categoryController(LibrarydbContext context, ICategory category)
        {
            _context = context;
            _category = category;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategoriesWithBooks()
        {
            try
            {
                var requestResult = await _category.GetCategoriesWithBooks();
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
