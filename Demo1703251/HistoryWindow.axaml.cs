using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo1703251.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1703251;

public partial class HistoryWindow : Window
{
    Partner Partner { get; set; }
    public HistoryWindow()
    {
        InitializeComponent();
        SetData();
    }

    private void SetData()
    {
        PPLB.ItemsSource = DataSource.Helper.dataBase.ProductsPartners.Include(x => x.ProductsNavigation);
    }
}