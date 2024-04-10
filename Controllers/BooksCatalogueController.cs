using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BooksCatalogue_API.Models;

namespace BooksCatalogue_API.Controllers
{
    public class BooksCatalogueController : ApiController
    {
        [Route("api/search/{BookName}")]
        public Book Get(string BookName)
        {
            using (BooksCatalogueDB_Connection_String db = new BooksCatalogueDB_Connection_String())
            {

                return db.Books.FirstOrDefault(s => s.Title == BookName);
            }
        }
    }
}
