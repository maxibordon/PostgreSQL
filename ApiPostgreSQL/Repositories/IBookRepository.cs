using APIPostgreSQLModelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiPostgreSQL
{
   public  interface IBookRepository
   {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookByTitle(string title);
        Task<bool> InsertBook(Book book);


   }
}
