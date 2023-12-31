﻿using System;
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
        public async Task<IActionResult> Index(string pesquisa)
        {
            //var contexto = _context.Datas.Include(d => d.Aluno).Include(d => d.Livro);
            //return View(await contexto.ToListAsync());

            if (pesquisa == null)
            {
                return _context.Datas.Include(d => d.Aluno).Include(d => d.Livro) != null ?
                          View(await _context.Datas.Include(d => d.Aluno).Include(d => d.Livro).ToListAsync()) :
                          Problem("Entity set 'Contexto.Aluno'  is null.");
            }
            else
            {
                var aluno =
                    _context.Datas.Include(d => d.Aluno).Include(d => d.Livro)
                    .Where(x => x.Aluno.Nome.Contains(pesquisa) || x.Livro.Nome.Contains(pesquisa));                  

                return View(aluno);
            }
        }

        // GET: Data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Datas == null)
            {
                return NotFound();
            }

            var data = await _context.Datas
                .Include(d => d.Aluno)
                .Include(d => d.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // GET: Data/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Nome");
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlunoId,LivroId,DataRetirada,DataDevolucao,Devolvido")] Data data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", data.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Nome", data.LivroId);
            return View(data);
        }

        // GET: Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Datas == null)
            {
                return NotFound();
            }

            var data = await _context.Datas.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", data.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Nome", data.LivroId);
            return View(data);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlunoId,LivroId,DataRetirada,DataDevolucao,Devolvido")] Data data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataExists(data.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", data.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Nome", data.LivroId);
            return View(data);
        }

        // GET: Data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Datas == null)
            {
                return NotFound();
            }

            var data = await _context.Datas
                .Include(d => d.Aluno)
                .Include(d => d.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
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
            var data = await _context.Datas.FindAsync(id);
            if (data != null)
            {
                _context.Datas.Remove(data);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataExists(int id)
        {
          return (_context.Datas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
