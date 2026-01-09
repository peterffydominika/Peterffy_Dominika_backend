using Microsoft.EntityFrameworkCore;
using Peterffy_Dominika_backend.Models;
using Peterffy_Dominika_backend.Models.DTOs;
using Peterffy_Dominika_backend.Services.Library;

namespace Peterffy_Dominika_backend.Services
{
    public class authorService(LibrarydbContext context, ResponseDTO responseDto) : IAuthor
    {
        private readonly LibrarydbContext _context = context;
        private readonly ResponseDTO _responseDto = responseDto;
        //9.Feladat
        public async Task<object> GetAuthorWithBooks(int authorId)
        {
            try
            {
                var author = await _context.Authors
                    .Include(a => a.Books)
                    .FirstOrDefaultAsync(a => a.AuthorId == authorId);

                if (author == null)
                {
                    _responseDto.Message = "Szerző nem található.";
                    _responseDto.Result = null;
                    return _responseDto;
                }

                _responseDto.Message = "Sikeres lekérdezés!";
                _responseDto.Result = author;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
    }
}
