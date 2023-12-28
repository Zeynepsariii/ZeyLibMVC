namespace PlsBozulmaaa.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        Book GetBookById(int bookId);
        IEnumerable<Book> GetAllBooks();
    }
}
