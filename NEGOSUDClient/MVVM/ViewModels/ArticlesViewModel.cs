using NEGOSUDClient.MVVM.ViewModels.Base;
using NEGOSUDClient.MVVM.ViewModels.Items;
using NEGOSUDClient.Services;
using NEGOSUDClient.Tools;
using NegosudLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NEGOSUDClient.MVVM.ViewModels
{
    public class ArticlesViewModel : BaseViewModel
    {
        public ObservableCollection<ArticleItemViewModel> Articles { get; set; } = new();

        public ICommand CloseArticleCommand { get; set; }
        public ICommand OpenArticleCreationFormCommand { get; set; }
        public ICommand OpenArticleModificationFormCommand { get; set; }

        public Visibility _createUpdateArticleFormVisibility = Visibility.Hidden;

        public Visibility CreateUpdateArticleFormVisibility
        {
            get { return _createUpdateArticleFormVisibility; }
            set
            {
                _createUpdateArticleFormVisibility = value;
                OnPropertyChanged(nameof(CreateUpdateArticleFormVisibility));
            }
        }

        private Visibility _isFormArticleVisible = Visibility.Hidden;
        public Visibility IsFormArticleVisible
        {
            get { return _isFormArticleVisible; }
            set
            {
                _isFormArticleVisible = value;
                OnPropertyChanged(nameof(IsFormArticleVisible));
            }
        }

        private ArticleItemViewModel _currentArticle;
        public ArticleItemViewModel CurrentArticle
        {
            get { return _currentArticle; }
            set
            {
                _currentArticle = value;
                OnPropertyChanged(nameof(CurrentArticle));
            }
        }

        public ArticlesViewModel()
        {
            GetArticles();
            CloseArticleCommand = new RelayCommand(CloseArticleForm);
            OpenArticleCreationFormCommand = new RelayCommand(OpenArticleCreation);
            OpenArticleModificationFormCommand = new RelayCommand(OpenArticleModification);
        }

        private void OpenArticleModification(object obj)
        {
            if (CreateUpdateArticleFormVisibility == Visibility.Hidden)
            {
                IsFormArticleVisible = Visibility.Hidden;
                //if (sender != null)
                //{
                //    CurrentArticle = (ArticleItemViewModel)sender;
                //    //IsDeleteButtonVisible = Visibility.Visible;
                //    //modify = true;
                //}
                CreateUpdateArticleFormVisibility = Visibility.Visible;

            }
        }

        private void OpenArticleCreation(object obj)
        {
            if (CreateUpdateArticleFormVisibility == Visibility.Hidden)
            {
                CurrentArticle = new ArticleItemViewModel(new ArticleDTO{Nom = "Nom du Produit"});
                //if (sender != null)
                //{
                //    CurrentArticle = (ArticleItemViewModel)sender;
                //    //IsDeleteButtonVisible = Visibility.Visible;
                //    //modify = true;
                //}
                CreateUpdateArticleFormVisibility = Visibility.Visible;

            }
        }

        private void CloseArticleForm(object obj)
        {
            IsFormArticleVisible = Visibility.Hidden;
            CreateUpdateArticleFormVisibility = Visibility.Hidden;
            CurrentArticle = null;
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
                    item.openDetails += OpenArticleForm;
                    item.deleted += DeleteArticle;
                    Articles.Add(item);


                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void DeleteArticle(object? sender, EventArgs e)
        {
            ArticleItemViewModel item = (ArticleItemViewModel)sender;

            Task.Run(async () =>
            {
                return await HttpClientService.DeleteArticle(item.Article.Id);

            })
            .ContinueWith(t =>
            {
                if(t.Result) 
                {
                    MessageBox.Show("Article supprimé avec succès");
                    Articles.Remove(item);
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la suppression de l'article");
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());

            
        }

        private void OpenArticleForm(object? sender, EventArgs e)
        {
            if (IsFormArticleVisible == Visibility.Hidden)
            {
                
                if (sender != null)
                {
                    CurrentArticle = (ArticleItemViewModel)sender;
                    //IsDeleteButtonVisible = Visibility.Visible;
                    //modify = true;
                }
                IsFormArticleVisible = Visibility.Visible;

            }
        }
    }
}
