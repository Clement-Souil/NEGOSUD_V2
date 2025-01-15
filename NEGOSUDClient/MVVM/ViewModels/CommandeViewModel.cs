using NEGOSUDClient.MVVM.ViewModels.Base;
using NEGOSUDClient.MVVM.ViewModels;
using NEGOSUDClient.Services;
using NEGOSUDClient.Tools;
using NegosudLibrary.DTO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using NEGOSUDClient.MVVM.ViewModels.Items;

namespace NEGOSUDClient.MVVM.ViewModels;
public class CommandeViewModel : BaseViewModel
{
    public ObservableCollection<CommandeItemViewModel> ListeCommande { get; set; } = new();

    public ICommand OpenCommandCreationFormCommand { get; set; }

    private Visibility _createUpdateCommandeFormVisibility = Visibility.Hidden;
    public Visibility CreateUpdateCommandeFormVisibility
    {
        get { return _createUpdateCommandeFormVisibility; }
        set
        {
            _createUpdateCommandeFormVisibility = value;
            OnPropertyChanged(nameof(CreateUpdateCommandeFormVisibility));
        }
    }

    private CommandeItemViewModel _currentCommande;
    public CommandeItemViewModel CurrentCommande
    {
        get { return _currentCommande; }
        set
        {
            _currentCommande = value;
            OnPropertyChanged(nameof(CurrentCommande));
        }
    }

    public CommandeViewModel()
    {
        GetCommandAll();

        // Initialisation de la commande
        OpenCommandCreationFormCommand = new RelayCommand(OpenCommandCreation);
    }

    private void OpenCommandCreation(object obj)
    {
        if (CreateUpdateCommandeFormVisibility == Visibility.Hidden)
        {
            CurrentCommande = new CommandeItemViewModel(new CommandeDTO { FournisseurNom = "Nom du Fournisseur" });
            //if (sender != null)
            //{
            //    CurrentArticle = (ArticleItemViewModel)sender;
            //    //IsDeleteButtonVisible = Visibility.Visible;
            //    //modify = true;
            //}
            CreateUpdateCommandeFormVisibility = Visibility.Visible;

        }
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
