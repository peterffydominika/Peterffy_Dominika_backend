using Peterffy_Dominika_backend.Models.DTOs;

namespace Peterffy_Dominika_backend.Services.Library
{
    public interface IBook
    {
        Task<object> GetAllBooks();
        
    }
}
