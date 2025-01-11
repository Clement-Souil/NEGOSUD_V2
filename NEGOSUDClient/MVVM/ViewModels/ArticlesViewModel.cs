using NEGOSUDClient.MVVM.ViewModels.Base;
using NEGOSUDClient.MVVM.ViewModels.Items;
using NEGOSUDClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NEGOSUDClient.MVVM.ViewModels
{
    public class ArticlesViewModel : BaseViewModel
    {
        public ObservableCollection<ArticleItemViewModel> Articles { get; set; } = new();


        public ArticlesViewModel()
        {
            GetArticles();
        }

        private void GetArticles()
        {
            Articles.Clear();

            Task.Run(async () =>
            {
                return await HttpClientService.GetArticles();

            })
            .ContinueWith(t =>
            {
                foreach (var art in t.Result)
                {
                    var item = new ArticleItemViewModel(art);
                    //item.EH_ConsultSalarie += Item_EH_ConsultSalarie;
                    //item.EH_Deleted += Reload;
                    Articles.Add(item);


                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
