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

public class ListeFournisseurViewModel : BaseViewModel
{
    //public ObservableCollection<FournisseurDTO> ListeFournisseur { get; set; }
    public ObservableCollection<FournisseurDTO> ListeFournisseur { get; set; } = new();


    public ListeFournisseurViewModel()
    {
        GetAllFournisseur();
    }

    private void GetAllFournisseur()
    {
        ListeFournisseur.Clear();

        Task.Run(async () =>
        {
            return await HttpClientService.GetFournisseurAll();
        })
        .ContinueWith(t =>
        {
            foreach(var fournisseur in t.Result)
            {
                ListeFournisseur.Add(fournisseur);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());

    }

 
}
