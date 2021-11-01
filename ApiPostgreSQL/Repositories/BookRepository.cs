using APIPostgreSQLModelos;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiPostgreSQL.Repositories
{
    public class BookRepository : IBookRepository
    {

        private PostgreSQLConfiguration _connectionString;

        public BookRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            
            var db = dbConnection();
            var sql = @" 
                     SELECT title,author, data FROM public.""book""
                   ";
            return await db.QueryAsync<Book>(sql, new { });
        } 

        public async Task<Book> GetBookByTitle(string title)
        {
            var db = dbConnection();
            var sql = @" 
                     SELECT title,author, data FROM public.""book""
                     WHERE title=@Title"; // Esta recuperación por campo aplica tanto para números como strings
            return await db.QueryFirstOrDefaultAsync<Book>(sql, new { Title=title });
        }

        public async Task<bool> InsertBook(Book book)
        {
            var db = dbConnection();
            var sql = @" 
                     INSERT INTO  public.""book"" (title, author,data)
                     VALUES(@Title,@Author,CAST(@Data as json))"; // El tema del json se puede usar para campos adicionales
            var result=await db.ExecuteAsync(sql, new { book.Title,book.Author,book.Data});
            return result > 0;
        }
    }
}
