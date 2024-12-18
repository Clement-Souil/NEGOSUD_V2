using NEGOSUDClient.MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NEGOSUDClient.MVVM.ViewModels
{
    public class ListeCommandeViewModel
    {
        public ObservableCollection<EtatCommandeViewModel> Commandes { get; set; }

        public ListeCommandeViewModel()
        {
            // Données fictives pour test
            Commandes = new ObservableCollection<EtatCommandeViewModel>
            {
                new EtatCommandeViewModel { StatusLivraison = "Livré", StatusPaiement = "Payé" },
                new EtatCommandeViewModel { StatusLivraison = "En Cours" },
                new EtatCommandeViewModel { StatusLivraison = "Annulé", StatusPaiement = "Annulé" }
            };
        }
    }
}
