using System.Collections.ObjectModel;
using NEGOSUDClient.MVVM.ViewModels.Base;
using NegosudLibrary.DTO;

namespace NEGOSUDClient.MVVM.ViewModels
{
    public class ListeInventaireViewModel : BaseViewModel
    {
        public ObservableCollection<ArticleDTO> Articles { get; set; }

        public ListeInventaireViewModel()
        {
            // Initialiser les articles avec des données fictives
            Articles = new ObservableCollection<ArticleDTO>
            {
                new ArticleDTO { Id = 1, Nom = "Château Margaux", Famille = "Vin Rouge", Annee = 2019, Quantite = 20 },
                new ArticleDTO { Id = 2, Nom = "Domaine Uby", Famille = "Vin Blanc", Annee = 2020, Quantite = 35 },
                new ArticleDTO { Id = 3, Nom = "Château Lafite", Famille = "Vin Rouge", Annee = 2018, Quantite = 15 }
            };
        }
    }
}
