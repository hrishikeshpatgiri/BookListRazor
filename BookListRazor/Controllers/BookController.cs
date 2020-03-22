﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult  GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            var bookFromDB = await _db.Book.FirstOrDefaultAsync(m => m.Id == id);
            if(bookFromDB==null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            else
            {
                _db.Book.Remove(bookFromDB);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Delete successful" });    
            }
        }
    }
}