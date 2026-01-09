namespace Peterffy_Dominika_backend.Services.Library
{
    public interface ICategory
    {
        Task<object> GetCategoriesWithBooks();
    }
}
