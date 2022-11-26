using System.Data;
using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.BooksService

{
    public class BooksService
    {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Books;User Id=postgres;Password=11042004;";

        public List<Books> GetBooks()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Books";

                return conn.Query<Books>(sql).ToList();
            }
        }

        public int InsertBooks(Books books)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
              var sql =
                    $"insert into Books (name, author, price,notes) VALUES " +
                    $"('{books.Name}', " +
                    $"'{books.Author}', " +
                    $"'{books.Price}', " +
                    $"'{books.Notes}')";
                var result = conn.Execute(sql);

                return result;
            }
        }

        public int UpdateBooks(Books books)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE books SET " +
                    $"name = '{books.Name}', " +
                    $"author = '{books.Author}', " +
                    $"price = '{books.Price}', " +
                    $"notes= '{books.Notes}'" +
                    $"WHERE id = {books.Id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

        public int DeleteBooks(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Books WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
            public int GetCount()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
    var sql = "select count(*) from Books";
     var count = conn.ExecuteScalar<int>(sql);
     return count;

         }

    }
        public int GetById(int id)
    {
       using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = 
            "Select * from Books where id = {id}";  
            
            return conn.Execute(sql);
        }
    }
    
}
}
