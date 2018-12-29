using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicList.Models;

namespace MusicList.Controllers
{
    public class MusicsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MusicsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Musics.ToList());
        }

        //Get : Music/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Music music)
        {
            if (ModelState.IsValid)
            {
                _db.Add(music);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}