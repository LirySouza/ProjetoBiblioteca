using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    public class DataController : Controller
    {
        private readonly Contexto _context;

        public DataController(Contexto context)
        {
            _context = context;
        }

        // GET: Data
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Datas.Include(d => d.Aluno).Include(d => d.Livro);
            return View(await contexto.ToListAsync());
        }

        // GET: Data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Datas == null)
            {
                return NotFound();
            }

            var datas = await _context.Datas
                .Include(d => d.Aluno)
                .Include(d => d.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datas == null)
            {
                return NotFound();
            }

            return View(datas);
        }

        // GET: Data/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Id");
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Id");
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlunoId,LivroId,DataRetirada,DataDevolucao")] Datas datas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Id", datas.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Id", datas.LivroId);
            return View(datas);
        }

        // GET: Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Datas == null)
            {
                return NotFound();
            }

            var datas = await _context.Datas.FindAsync(id);
            if (datas == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Id", datas.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Id", datas.LivroId);
            return View(datas);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlunoId,LivroId,DataRetirada,DataDevolucao")] Datas datas)
        {
            if (id != datas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatasExists(datas.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Id", datas.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Id", datas.LivroId);
            return View(datas);
        }

        // GET: Data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Datas == null)
            {
                return NotFound();
            }

            var datas = await _context.Datas
                .Include(d => d.Aluno)
                .Include(d => d.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datas == null)
            {
                return NotFound();
            }

            return View(datas);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Datas == null)
            {
                return Problem("Entity set 'Contexto.Datas'  is null.");
            }
            var datas = await _context.Datas.FindAsync(id);
            if (datas != null)
            {
                _context.Datas.Remove(datas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatasExists(int id)
        {
          return (_context.Datas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
