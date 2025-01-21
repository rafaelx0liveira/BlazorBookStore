using BlazorBookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBookStore.Domain.Abstractions
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book?> AddBook(Book book);
        Task DeleteBook(int id);
        Task UpdateBook(Book book);
    }
}
