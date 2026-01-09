using Microsoft.EntityFrameworkCore;
using Peterffy_Dominika_backend.Models;
using Peterffy_Dominika_backend.Models.DTOs;
using Peterffy_Dominika_backend.Services.Library;

namespace Peterffy_Dominika_backend.Services
{
    public class categoryService(LibrarydbContext context, ResponseDTO responseDto) : ICategory
    {
        private readonly LibrarydbContext _context = context;
        private readonly ResponseDTO _responseDto = responseDto;

        //11.Feladat
        public async Task<object> GetCategoriesWithBooks()
        {
            var categories = await _context.Categories
                                           .Include(c => c.Books)
                                           .ToListAsync();

            _responseDto.Message = "Sikeres lekérdezés!";
            _responseDto.Result = categories;
            return _responseDto;
        }
    }
}
