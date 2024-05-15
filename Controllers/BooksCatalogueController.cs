using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BooksCatalogue_API.Models;

public class BooksCatalogueController : ApiController
{
    [HttpGet]
    [Route("api/Books/Title/{Title}")]
    public IHttpActionResult SearchByTitle(string Title)
    {
        using (BooksCatalogueDB_Connection_String db = new BooksCatalogueDB_Connection_String())
        {
            IQueryable<Book> query = db.Books;

            if (!string.IsNullOrEmpty(Title))
            {
                query = query.Where(b => b.Title.Contains(Title));
            }

            var results = query.ToList();

            if (results.Count > 0)
            {
                return Ok(results);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpGet]
    [Route("api/Books/Author/{Author}")]
    public IHttpActionResult SearchByAuthor(string Author)
    {
        using (BooksCatalogueDB_Connection_String db = new BooksCatalogueDB_Connection_String())
        {
            IQueryable<Book> query = db.Books;

            if (!string.IsNullOrEmpty(Author))
            {
                query = query.Where(b => b.Author.Contains(Author));
            }

            var results = query.ToList();

            if (results.Count > 0)
            {
                return Ok(results);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpGet]
    [Route("api/Books/Genre/{Genre}")]
    public IHttpActionResult SearchByGenre(string Genre)
    {
        using (BooksCatalogueDB_Connection_String db = new BooksCatalogueDB_Connection_String())
        {
            IQueryable<Book> query = db.Books;

            if (!string.IsNullOrEmpty(Genre))
            {
                query = query.Where(b => b.Genre.Contains(Genre));
            }

            var results = query.ToList();

            if (results.Count > 0)
            {
                return Ok(results);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpGet]
    [Route("api/Books/PublicationYear/{PublicationYear}")]
    public IHttpActionResult SearchByPublicationYear(int? PublicationYear)
    {
        using (BooksCatalogueDB_Connection_String db = new BooksCatalogueDB_Connection_String())
        {
            IQueryable<Book> query = db.Books;

            if (PublicationYear != null)
            {
                query = query.Where(b => b.PublicationYear == PublicationYear);
            }

            var results = query.ToList();

            if (results.Count > 0)
            {
                return Ok(results);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpGet]
    [Route("api/books/{BookId}")]
    public IHttpActionResult GetBookById(int BookId)
    {
        using (BooksCatalogueDB_Connection_String db = new BooksCatalogueDB_Connection_String())
        {
            var book = db.Books.Find(BookId);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpGet]
    [Route("api/books")]
    public IHttpActionResult GetAllBooks()
    {
        using (BooksCatalogueDB_Connection_String db = new BooksCatalogueDB_Connection_String())
        {
            var allBooks = db.Books.ToList();
            return Ok(allBooks);
        }
    }

}


