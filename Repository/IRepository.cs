using BlazorCrud.Models;

namespace BlazorCrud.Repository
{
    public interface IRepository
    {
        public Task<List<Book>> GetBooks(); //obtinene la lista de libros
        public Task<Book> GetBookId(int bookId); //obtiene un libro por su id
        public Task<Book> CreateBook(Book createBook);
        public Task<Book> UpdateBook(int bookId, Book uptdateBook);
        public Task DeleteBook(int bookId);

    }      
}
