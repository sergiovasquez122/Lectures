﻿using Cecs475.Web.BooksDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cecs475.Web.BooksDemo.Controllers {
	public class BooksController : ApiController {
		private Dictionary<int, Book> mRepository = new Dictionary<int, Book>();

		public BooksController() {
			mRepository[1] = new Book() {
				Id = 1,
				Publisher = "Leanpub.com",
				Title = "C#eckmate: Learning C# and Programming Book"
			};
			mRepository[2] = new Book() {
				Id = 2,
				Publisher = "CSULB Press",
				Title = "Some CSULB Book"
			};
		}

		// GET: api/Books
		public IEnumerable<Book> Get() {
			return mRepository.Values;
		}

		// GET: api/Books/5
		public Book Get(int id) {
			if (mRepository.ContainsKey(id)) {
				return mRepository[id];
			}
			return null;
		}

		// GET: api/Books?publisher=Wrox+Press
		public IEnumerable<Book> Get(string publisher) {
			return mRepository.Values.Where(b => b.Publisher == publisher);
		}

		// POST: api/Books
		public Book Post([FromBody]Book newBook) {
			mRepository[newBook.Id] = newBook;
			return mRepository[newBook.Id];
		}

		// DELETE: api/Books/5
		public bool Delete(int id) {
			mRepository.Remove(id);
			return mRepository.ContainsKey(id);
		}
	}
}
