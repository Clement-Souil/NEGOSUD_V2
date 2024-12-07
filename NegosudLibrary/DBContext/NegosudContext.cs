using Microsoft.EntityFrameworkCore;
using NegosudLibrary.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegosudLibrary.DBContext;

public class NegosudContext : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public DbSet<Commande> Commandes { get; set; }

    public DbSet<Facture> Factures { get; set; }

    public DbSet<FamilleArticle> FamilleArticles { get; set; }

    public DbSet<Fournisseur> Fournisseurs { get; set; }

    public DbSet<Inventaire> Inventaires { get; set; }

    public DbSet<LigneCommande> LigneCommandes { get; set; }

    public DbSet<MouvementStock> MouvementStocks { get; set; }

    public DbSet<TypeMouvement> TypeMouvements { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connexionString = "server=localhost;port=3306;userid=root;password=;database=negosud_V2;";
        optionsBuilder.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString));
    }

}

