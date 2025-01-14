﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegosudLibrary.DAO;
using NegosudLibrary.DBContext;
using NegosudLibrary.DTO;

namespace ApiNegosud.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly NegosudContext _context;

        public CommandesController(NegosudContext context)
        {
            _context = context;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandeDTO>>> GetCommandes()
        {
            List<CommandeDTO> commandeDTOs = new List<CommandeDTO>();
            int i = 1;

            var L = await _context.Commandes.Include(n => n.StatutCommande).Include(a => a.User).Include(v => v.Fournisseur).Include(c => c.LignesCommande).ThenInclude(x => x.Article).ToListAsync();

            foreach (var item in L)
            {
                double prixtotal = 0;
                foreach (var ligne in item.LignesCommande)
                {
                    prixtotal += ligne.Quantite * ligne.Article.PrixVente;
                }

                CommandeDTO dto = new CommandeDTO
                {
                    Id = item.Id,
                    Date = item.Date,
                    UserId = item.UserId,
                    StatutCommandeId = item.StatutCommandeId,
                    FournisseurId = item.FournisseurId,
                    FournisseurNom = item.Fournisseur.NomDomaine,
                    PrixTotal = prixtotal,
                    UserNom = item.User.Nom + " " + item.User.Prenom,
                    StatutCommande = item.StatutCommande.Statut



                };
                commandeDTOs.Add(dto);

            }
            return commandeDTOs;
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);

            if (commande == null)
            {
                return NotFound();
            }

            return commande;
        }

        // PUT: api/Commandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.Id)
            {
                return BadRequest();
            }

            _context.Entry(commande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Commandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommande", new { id = commande.Id }, commande);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }

            _context.Commandes.Remove(commande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandeExists(int id)
        {
            return _context.Commandes.Any(e => e.Id == id);
        }
    }
}
