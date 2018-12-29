using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Get : Musics/Create
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

        //Details : Musics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var music = await _db.Musics.SingleOrDefaultAsync(m => m.Id == id);
            if(music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        //Edit : Musics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var music = await _db.Musics.SingleOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        //POST : Musics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Music music)
        {
            if(id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(music);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        //Delete : Musics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var music = await _db.Musics.SingleOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        //Post : Musics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveMusic(int id)
        {
            var music = await _db.Musics.SingleOrDefaultAsync(m => m.Id == id);
            _db.Musics.Remove(music);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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