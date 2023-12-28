using Microsoft.EntityFrameworkCore;

namespace PlsBozulmaaa.Repositories
{
    public class BookRepository
    {

        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _db.Add(book);
            _db.SaveChanges();
        }

        public Book GetBookById(int bookId)
        {
            return _db.Books
                .Include(b => b.Genre)
                .FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _db.Books
                .Include(b => b.Genre)
                .ToList();
        }

        
    }
}

