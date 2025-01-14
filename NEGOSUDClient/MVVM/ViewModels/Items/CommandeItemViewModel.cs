using NEGOSUDClient.MVVM.ViewModels.Base;
using NEGOSUDClient.Tools;
using NegosudLibrary.DAO;
using NegosudLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace NEGOSUDClient.MVVM.ViewModels;

public class CommandeItemViewModel : BaseViewModel
{
    public CommandeDTO Commande { get; set; }
    public UserDTO User { get; set; }

    public ICommand ClickSupprimerCommande {  get; set; }

    public ICommand ClickVoirDetailsCommande { get; set; }

    public event EventHandler Supprimer;
    public event EventHandler Modifier;

    public CommandeItemViewModel(CommandeDTO _commande, UserDTO _user)
    {
        Commande = _commande;
        User = _user;

        ClickSupprimerCommande = new RelayCommand(SupprimerItem);
        ClickVoirDetailsCommande = new RelayCommand(ModifierItem);
    }

    public CommandeItemViewModel(CommandeDTO commande)
    {
        Commande = commande;
    }

    private void SupprimerItem(object obj)
    {
        throw new NotImplementedException();
    }
    private void ModifierItem(object obj)
    {
        throw new NotImplementedException();    
    }

}

