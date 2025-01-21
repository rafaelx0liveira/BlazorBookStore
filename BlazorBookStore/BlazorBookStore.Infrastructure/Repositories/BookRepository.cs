using BlazorBookStore.Domain.Abstractions;
using BlazorBookStore.Domain.Entities;
using BlazorBookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBookStore.Infrastructure.Repositories
{
    public class BookRepository 
        (AppDbContext context)
        : IBookRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            if (_context is not null &&
                _context.Books is not null)
            {
                var books = await _context.Books.ToListAsync();
                return books;
            }
            else
            {
                throw new Exception("Invalid data...");
            }
        }

        public async Task<Book?> AddBook(Book book)
        {
            if(_context is not null &&
            book is not null &&
            _context.Books is not null)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return book;
            }
            else
            {
                throw new Exception("Invalid data...");
            }
        }
        public async Task<Book?> GetBookById(int id)
        {
            if (_context is not null &&
                _context.Books is not null)
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.LivroId == id);

                if (book == null) throw new Exception($"Livro com Id {id} não encontrado");

                return book;
            }
            else
            {
                throw new Exception("Invalid data...");
            }
        }

        public async Task DeleteBook(int id)
        {
            var book = await GetBookById(id);

            if(book is not null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Livro com Id {id} não encontrado");
            }
        }


        public async Task UpdateBook(Book book)
        {
            if (_context is not null &&
                book is not null &&
                _context.Books is not null)
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Dados inválidos...");
            }
        }
    }
}
