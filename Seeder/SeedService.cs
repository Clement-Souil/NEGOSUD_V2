using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using NegosudLibrary.DAO;
using NegosudLibrary.DBContext;
using static NegosudLibrary.DBContext.NegosudContext;

namespace Seeder
{
    //1 - Creer dans la Solution une application console C# appelée Seeder

    //2 - Dans le Negosud context de la librairie, ajouter la factory suivante: 

    //public class NegoSudDBContextFactory : IDesignTimeDbContextFactory<NegosudContext>
    //{
    //    public NegosudContext CreateDbContext(string[] args)
    //    {
    //        var connexionString = "server=localhost;port=3306;userid=root;password=;database=negosud_V2;";
    //        var optionsBuilder = new DbContextOptionsBuilder<NegosudContext>();
    //        optionsBuilder.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString));

    //        return new NegosudContext(optionsBuilder.Options);
    //    }
    //}

    //Cela permettra au Seeder d'instancier un DBContext pour faire l'insertion

    //3 - Creer la classe Seed Service et copier le contenu de ce fichier dedans

    //4 - dans le program.cs du Seeder, remplacer le contenu par le code suivant : 


    //using Seeder;

    //internal class Program
    //{
    //    private static void Main(string[] args)
    //    {
    //        var ss = new SeedService();
    //        ss.SeedDatabase();
    //    }
    //}

    //5 - Mettre le Seeder en projet de démarrage et lancer. L'insertion dans la BDD se fait instantanément (ne pas oublier de lancer xamp ;) )


    public class SeedService
    {

        public void SeedDatabase()
        {
            var factory = new NegoSudDBContextFactory();
            var context = factory.CreateDbContext([""]);

            if (!context.Fournisseurs.Any())
            {
                context.Fournisseurs.Add(new Fournisseur { Id = 1, Contact = "0786515658", NomDomaine = "Domaine de La Roche", Region = "Charente-Maritime" });
                context.Fournisseurs.Add(new Fournisseur { Id = 2, Contact = "0666666666", NomDomaine = "Domaine de La Villependière", Region = "Aquitaine" });
                context.Fournisseurs.Add(new Fournisseur { Id = 3, Contact = "0999999999", NomDomaine = "Domaine de Santa Duc", Region = "Haute-Savoie" });
                context.Fournisseurs.Add(new Fournisseur { Id = 4, Contact = "0999999999", NomDomaine = "Domaine des Roches Neuves", Region = "Ile de France" });
                context.Fournisseurs.Add(new Fournisseur { Id = 5, Contact = "0999999999", NomDomaine = "Domaine D'Uby Tortues", Region = "Haute-Garonne" });
            }

            if (!context.TypeMouvements.Any())
            {
                context.TypeMouvements.Add(new TypeMouvement { Id = 1, Nom = "Vol" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 2, Nom = "Casse" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 3, Nom = "Vente" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 4, Nom = "Achat" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 5, Nom = "Dégustation" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 6, Nom = "Retour client" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 7, Nom = "Ajustement positif après inventaire" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 8, Nom = "Ajustement négatif après inventaire" });
                context.TypeMouvements.Add(new TypeMouvement { Id = 9, Nom = "Retour fournisseur" });
            }

            if (!context.StatutCommandes.Any())
            {
                context.StatutCommandes.Add(new StatutCommande { Id = 1, Statut = "Envoyé" });
                context.StatutCommandes.Add(new StatutCommande { Id = 2, Statut = "En cours" });
                context.StatutCommandes.Add(new StatutCommande { Id = 3, Statut = "Annulé" });
            }

            if (!context.FamilleArticles.Any())

            {
                context.FamilleArticles.Add(new FamilleArticle { Id = 1, Nom = "Rouge" });
                context.FamilleArticles.Add(new FamilleArticle { Id = 2, Nom = "Blanc" });
                context.FamilleArticles.Add(new FamilleArticle { Id = 3, Nom = "Rosé" });
                context.FamilleArticles.Add(new FamilleArticle { Id = 4, Nom = "Champagne" });
                context.FamilleArticles.Add(new FamilleArticle { Id = 5, Nom = "Digestif" });
            }

            if (!context.Articles.Any())
            {
                context.Articles.Add(new Article
                {
                    Id = 1,
                    Nom = "Gros et Petit Manseng",
                    Annee = 1999,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 11.5,
                    Description = "Domaine D'Uby Tortues Gros Et Petit Manseng Blanc 1999",
                    PrixAchat = 6,
                    PrixVente = 7,
                    Quantite = 8,
                    FamilleArticleId = 2,
                    FournisseurId = 5,
                    SeuilReappro = 4

                });
                context.Articles.Add(new Article
                {
                    Id = 2,
                    Nom = "Colombard Sauvignon Blanc",
                    Annee = 2020,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 11.5,
                    Description = "Domaine D'Uby Tortues Colombard Sauvignon Blanc 2020",
                    PrixAchat = 6,
                    PrixVente = 7,
                    Quantite = 8,
                    FamilleArticleId = 2,
                    FournisseurId = 5,
                    SeuilReappro = 4

                });
                context.Articles.Add(new Article
                {
                    Id = 3,
                    Nom = "Saumur L'Insolite Blanc 2019",
                    Annee = 2019,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 11.5,
                    Description = "Domaine Des Roches Neuves Saumur L'Insolite Blanc 2019",
                    PrixAchat = 6,
                    PrixVente = 7,
                    Quantite = 8,
                    FamilleArticleId = 2,
                    FournisseurId = 4,
                    SeuilReappro = 4

                });
                context.Articles.Add(new Article
                {
                    Id = 4,
                    Nom = "Saumur Champigny Terres Chaudes",
                    Annee = 2018,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Domaine Des Roches Neuves Saumur Champigny Terres Chaudes Rouge 2018",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 1,
                    FournisseurId = 4,
                    SeuilReappro = 4

                });
                context.Articles.Add(new Article
                {
                    Id = 5,
                    Nom = "La Marginale",
                    Annee = 2018,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Domaine Des Roches Neuves La Marginale Rouge 2018",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 1,
                    FournisseurId = 4,
                    SeuilReappro = 4

                });
                context.Articles.Add(new Article
                {
                    Id = 6,
                    Nom = "Les Mémoires",
                    Annee = 2018,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Domaine Des Roches Neuves Les Memoires Rouge 2018",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 1,
                    FournisseurId = 4,
                    SeuilReappro = 4

                });

                context.Articles.Add(new Article
                {
                    Id = 7,
                    Nom = "L'Echelier",
                    Annee = 2018,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Domaine Des Roches Neuves L'Echelier Blanc 2018",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 2,
                    FournisseurId = 4,
                    SeuilReappro = 4

                });

                context.Articles.Add(new Article
                {
                    Id = 8,
                    Nom = "Le Serre du Rieu",
                    Annee = 2020,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Domaine De Santa Duc Le Serre Du Rieu Blanc 2020",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 2,
                    FournisseurId = 3,
                    SeuilReappro = 4

                });

                context.Articles.Add(new Article
                {
                    Id = 9,
                    Nom = "Les Quatres Terres",
                    Annee = 2020,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Domaine De Santa Duc Les Quatre Terres Rouge 2019",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 1,
                    FournisseurId = 3,
                    SeuilReappro = 4

                });

                context.Articles.Add(new Article
                {
                    Id = 10,
                    Nom = "Les Hautes Garrigues",
                    Annee = 2010,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Domaine De Santa Duc Les Hautes Garrigues 2010",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 1,
                    FournisseurId = 3,
                    SeuilReappro = 4

                });

                context.Articles.Add(new Article
                {
                    Id = 11,
                    Nom = "Grand Vintage Rosé",
                    Annee = 2010,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Un Grand Vintage naît de l’interprétation libre du Chef de Cave, à partir d’une sélection des vins les plus remarquables produits au cours d’une année unique. L’année 1842 est celle de la création des champagnes Grand Vintage, par Moët & Chandon, élaborés pour le plaisir des connaisseurs anglais et américains à la recherche de vins plus matures. Depuis, chaque millésime reflète la vision personnelle du Chef de Cave, ainsi que son respect pour l’individualité de chaque millésime, à chaque année donnée.",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 3,
                    FournisseurId = 1,
                    SeuilReappro = 4

                });

                context.Articles.Add(new Article
                {
                    Id = 12,
                    Nom = "Réserve Impérial étui",
                    Annee = 2010,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 12.5,
                    Description = "Un Grand Vintage naît de l’interprétation libre du Chef de Cave, à partir d’une sélection des vins les plus remarquables produits au cours d’une année unique. L’année 1842 est celle de la création des champagnes Grand Vintage, par Moët & Chandon, élaborés pour le plaisir des connaisseurs anglais et américains à la recherche de vins plus matures. Depuis, chaque millésime reflète la vision personnelle du Chef de Cave, ainsi que son respect pour l’individualité de chaque millésime, à chaque année donnée.",
                    PrixAchat = 6.8,
                    PrixVente = 9.5,
                    Quantite = 8,
                    FamilleArticleId = 4,
                    FournisseurId = 2,
                    SeuilReappro = 4

                });

                context.Articles.Add(new Article
                {
                    Id = 13,
                    Nom = "Diplomatico",
                    Annee = 2010,
                    Cepage = "Je sais pas c'est de la merde cette colonne",
                    Degre = 38.3,
                    Description = "Rhum sucré et caramélisé originaire des caraïbes",
                    PrixAchat = 19,
                    PrixVente = 39,
                    Quantite = 8,
                    FamilleArticleId = 5,
                    FournisseurId = 1,
                    SeuilReappro = 4

                });

            }


            context.SaveChanges();
        }

    }
}
