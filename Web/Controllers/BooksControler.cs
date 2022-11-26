using Domain.Dtos;
using Infrastructure.BooksService;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController
    {
        private BooksService _booksService;

        public BooksController()
        {
            _booksService = new BooksService();
        }


        [HttpGet]
        public List<Books> GetBooks()
        {
            return _booksService.GetBooks();
        }
        [HttpPost("Insert")]
        public int InsertBooks(Books books)
        {
            return _booksService.InsertBooks(books);
        }

        [HttpPut]
        public int UpdateBooks(Books books)
        {
            return _booksService.UpdateBooks(books);
        }

        [HttpDelete]
        public int DeleteBooks(int id)
        {
            return _booksService.DeleteBooks(id);
        }

[HttpGet("Count")]
        public int GetCount()
        {
            return _booksService.GetCount();
        }

       
    }

    }

