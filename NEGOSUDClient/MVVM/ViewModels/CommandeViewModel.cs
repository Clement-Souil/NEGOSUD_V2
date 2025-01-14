using NEGOSUDClient.MVVM.ViewModels.Base;
using NEGOSUDClient.Services;
using NegosudLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NEGOSUDClient.MVVM.ViewModels;

public class CommandeViewModel : BaseViewModel
{
    public ObservableCollection<EtatCommandeViewModel> Commandes { get; set; }
    public ObservableCollection<CommandeItemViewModel> ListeCommande { get; set; } = new();

    public CommandeViewModel()
    {
        GetCommandAll();
        //// Données fictives pour test
        //Commandes = new ObservableCollection<EtatCommandeViewModel>
        //{
        //    new EtatCommandeViewModel { StatusLivraison = "Livré", StatusPaiement = "Payé" },
        //    new EtatCommandeViewModel { StatusLivraison = "En Cours" },
        //    new EtatCommandeViewModel { StatusLivraison = "Annulé", StatusPaiement = "Annulé" }
        //};
    }

    private void GetCommandAll()
    {
        ListeCommande.Clear();

        Task.Run(async () =>
        {
            // Récupère les commandes et les utilisateurs en parallèle
            var commandes = await HttpClientService.GetCommandAll();
            var users = await HttpClientService.GetAllUsers();

            return commandes.Select(commande =>
            {
                // Trouve l'utilisateur correspondant
                var user = users.FirstOrDefault(u => u.Id == commande.UserId)
                           ?? new UserDTO { Nom = "Inconnu", Prenom = "" };

                return new CommandeItemViewModel(commande) { User = user };
            }).ToList();
        })
        .ContinueWith(t =>
        {
            foreach (var commandeItem in t.Result)
            {
                ListeCommande.Add(commandeItem);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}