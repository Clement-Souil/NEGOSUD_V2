﻿using NEGOSUDClient.MVVM.ViewModels;
using NEGOSUDClient.Services;

using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NEGOSUDClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.DataContext = MainWindowViewModel.Instance;

        Task.Run(async () => await HttpClientService.Login("franco.olivier@yahoo.fr", "Brotherhood-82"));
    }

}