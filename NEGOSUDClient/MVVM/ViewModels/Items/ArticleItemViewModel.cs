using NEGOSUDClient.MVVM.ViewModels.Base;
using NegosudLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOSUDClient.MVVM.ViewModels.Items
{
    public class ArticleItemViewModel : BaseViewModel
    {

        public ArticleDTO Article { get; set; }

        public ArticleItemViewModel(ArticleDTO _article)
        {
            Article = _article;
        }
    }
}
