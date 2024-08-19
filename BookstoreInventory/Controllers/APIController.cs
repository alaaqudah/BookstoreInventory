using BookstoreInventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BookstoreInventory.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [System.Web.Http.HttpGet, System.Web.Http.Route("")]
        public IEnumerable<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        [System.Web.Http.HttpGet, System.Web.Http.Route("{id}")]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [System.Web.Http.HttpPost, Microsoft.AspNetCore.Mvc.Route("")]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Books.Add(book);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        }

        [System.Web.Http.HttpPut, System.Web.Http.Route("{id}")]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != book.BookId) return BadRequest();

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id)) return NotFound();
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [System.Web.Http.HttpDelete, System.Web.Http.Route("{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null) return NotFound();

            db.Books.Remove(book);
            db.SaveChanges();
            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookId == id) > 0;
        }
    }

}