using BlazorCrud.Data;
using BlazorCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBook(Book createBook)
        {
            if(createBook != null) 
            {
                createBook.CreateDate = DateTime.Now;
                await _context.Book.AddAsync(createBook);
                await _context.SaveChangesAsync();
                return createBook;
            }
            else
            {
                return new Book();
            }
        }

        public async Task DeleteBook(int bookId)
        {
            var bookFromDb = await _context.Book.FindAsync(bookId);
            _context.Remove(bookFromDb);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookId(int bookId)
        {
            var bookFromDb = await _context.Book.FindAsync(bookId);
            if(bookFromDb == null)
            {
                return new Book();
            }
            else
            {
                return bookFromDb;
            }
        }

        public Task<List<Book>> GetBooks()
        {
            return _context.Book.ToListAsync();
        }

        public async Task<Book> UpdateBook(int bookId, Book uptdateBook)
        {
            var bookFromDb = await _context.Book.FindAsync(bookId);
            bookFromDb.Title = uptdateBook.Title;
            bookFromDb.Author = uptdateBook.Author;
            bookFromDb.Pages = uptdateBook.Pages;
            bookFromDb.Price = uptdateBook.Price;           
            bookFromDb.Description = uptdateBook.Description;

            await _context.SaveChangesAsync();
            return bookFromDb;
        }
    }
}
