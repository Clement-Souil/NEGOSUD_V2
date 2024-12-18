using NEGOSUDClient.MVVM.View;
using NEGOSUDClient.MVVM.ViewModels.Base;
using NEGOSUDClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NEGOSUDClient.MVVM.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    // Design Pattern (singleton), parce que le mainview s'ouvre à l'ouverture de l'application,
    // il n'y en aura qu'une et on injectera les autres views dedans.
    private static MainWindowViewModel instance = new MainWindowViewModel();
    public static MainWindowViewModel Instance => instance;

    // Current viewmodel contient la view actuellememnt injectée dans le main window, on l'encapsule manuellement pour lancer l'évenement
    // OnPropertyChanged lors du set d'un nouveau viewmodel, cela permet de mettre à jour la vue lors du changement du _currentViewModel
    private object _currentViewModel;
    public object CurrentViewModel
    {
        get { return _currentViewModel; }
        set
        {
            if (_currentViewModel != value)
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }

    public ICommand NavigationCommand { get; set; }

    public MainWindowViewModel()
    {
        NavigationCommand = new RelayCommand(NavigateTo);
        CurrentViewModel = null; // Pour l'instant initalisé à null 


    }

    private void NavigateTo(object obj)
    {
        if (obj is string)
        {
            switch (obj)
            {
                case "Commandes":
                    CurrentViewModel = new ListeCommandeViewModel();
                    break;
                case "Produits":
                    CurrentViewModel = new ListeProduitViewModel();
                    break;
                case "Clients":
                    CurrentViewModel = new ListeClientViewModel();
                    break;
                case "Fournisseurs":
                    CurrentViewModel = new ListeFournisseurViewModel();
                    break;
                case "Stock":
                    CurrentViewModel = new StockViewModel();
                    break;
            }
        }
    }
}
