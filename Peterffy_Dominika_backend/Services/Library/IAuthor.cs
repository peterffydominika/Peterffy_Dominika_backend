namespace Peterffy_Dominika_backend.Services.Library
{
    public interface IAuthor
    {
        Task<object> GetAuthorWithBooks(int authorId);
    }
}
