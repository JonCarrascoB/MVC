using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using firstExercise.Data;
using firstExercise.Models;

namespace firstExercise.Controllers
{
    public class MamiferosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MamiferosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mamiferos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mamiferos.ToListAsync());
        }

        // GET: Mamiferos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mamifero = await _context.Mamiferos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mamifero == null)
            {
                return NotFound();
            }

            return View(mamifero);
        }

        // GET: Mamiferos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mamiferos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Patas,NombreCientifico,Ecolocalizacion")] Mamifero mamifero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mamifero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mamifero);
        }

        // GET: Mamiferos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mamifero = await _context.Mamiferos.FindAsync(id);
            if (mamifero == null)
            {
                return NotFound();
            }
            return View(mamifero);
        }

        // POST: Mamiferos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Patas,NombreCientifico,Ecolocalizacion")] Mamifero mamifero)
        {
            if (id != mamifero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mamifero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MamiferoExists(mamifero.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mamifero);
        }

        // GET: Mamiferos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mamifero = await _context.Mamiferos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mamifero == null)
            {
                return NotFound();
            }

            return View(mamifero);
        }

        // POST: Mamiferos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mamifero = await _context.Mamiferos.FindAsync(id);
            _context.Mamiferos.Remove(mamifero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MamiferoExists(int id)
        {
            return _context.Mamiferos.Any(e => e.Id == id);
        }
    }
}
