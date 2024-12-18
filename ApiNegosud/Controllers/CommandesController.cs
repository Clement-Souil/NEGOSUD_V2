using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NegosudLibrary.DAO;
using NegosudLibrary.DBContext;

namespace ApiNegosud.Controllers
{
    public class CommandesController : Controller
    {
        private readonly NegosudContext _context;
        //private readonly CommandeService _service;

        public CommandesController(NegosudContext context)
        {
            _context = context;
        }

        // GET: Commandes
        public async Task<IActionResult> Index()
        {
            var negosudContext = _context.Commandes.Include(c => c.Fournisseur).Include(c => c.StatutCommande).Include(c => c.User);
            return View(await negosudContext.ToListAsync());
        }

        // GET: Commandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes
                .Include(c => c.Fournisseur)
                .Include(c => c.StatutCommande)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // GET: Commandes/Create
        public IActionResult Create()
        {
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseurs, "Id", "NomDomaine");
            ViewData["StatutCommandeId"] = new SelectList(_context.Set<StatutCommande>(), "Id", "Statut");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Adresse");
            return View();
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,UserId,StatutCommandeId,FournisseurId")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseurs, "Id", "NomDomaine", commande.FournisseurId);
            ViewData["StatutCommandeId"] = new SelectList(_context.Set<StatutCommande>(), "Id", "Statut", commande.StatutCommandeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Adresse", commande.UserId);
            return View(commande);
        }

        // GET: Commandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseurs, "Id", "NomDomaine", commande.FournisseurId);
            ViewData["StatutCommandeId"] = new SelectList(_context.Set<StatutCommande>(), "Id", "Statut", commande.StatutCommandeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Adresse", commande.UserId);
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,UserId,StatutCommandeId,FournisseurId")] Commande commande)
        {
            if (id != commande.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandeExists(commande.Id))
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
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseurs, "Id", "NomDomaine", commande.FournisseurId);
            ViewData["StatutCommandeId"] = new SelectList(_context.Set<StatutCommande>(), "Id", "Statut", commande.StatutCommandeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Adresse", commande.UserId);
            return View(commande);
        }

        // GET: Commandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes
                .Include(c => c.Fournisseur)
                .Include(c => c.StatutCommande)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            if (commande != null)
            {
                _context.Commandes.Remove(commande);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return _context.Commandes.Any(e => e.Id == id);
        }
    }
}
