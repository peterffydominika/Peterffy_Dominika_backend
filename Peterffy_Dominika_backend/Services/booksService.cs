using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using Peterffy_Dominika_backend.Models;
using Peterffy_Dominika_backend.Models.DTOs;
using Peterffy_Dominika_backend.Services.Library;

namespace Peterffy_Dominika_backend.Services
{
    public class booksService(LibrarydbContext context, ResponseDTO responseDto) : IBook
    {
        private readonly LibrarydbContext _context = context;
        private readonly ResponseDTO _responseDto = responseDto;

        //10.Feladat
        public async Task<object> GetAllBooks()
        {
            try
            {
                var konyvek = await _context.Books.ToListAsync();
                _responseDto.Message = "Sikeres lekérdezés!";
                _responseDto.Result = konyvek;
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
