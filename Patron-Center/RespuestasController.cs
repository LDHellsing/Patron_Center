﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patron_Center.Models;

namespace Patron_Center
{
    public class RespuestasController : Controller
    {
        private readonly Patron_CenterContext _context;

        public RespuestasController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Respuestas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Respuesta.ToListAsync());
        }

        // GET: Respuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuesta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // GET: Respuestas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPregunta,EsRespuestaCorrecta,EsRespuestaUnica,EsEliminado,Enunciado")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(respuesta);
        }

        // GET: Respuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuesta.FindAsync(id);
            if (respuesta == null)
            {
                return NotFound();
            }
            return View(respuesta);
        }

        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPregunta,EsRespuestaCorrecta,EsRespuestaUnica,EsEliminado,Enunciado")] Respuesta respuesta)
        {
            if (id != respuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestaExists(respuesta.Id))
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
            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuesta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respuesta = await _context.Respuesta.FindAsync(id);
            _context.Respuesta.Remove(respuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespuestaExists(int id)
        {
            return _context.Respuesta.Any(e => e.Id == id);
        }
    }
}
