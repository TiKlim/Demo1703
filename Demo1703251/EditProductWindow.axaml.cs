using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo1703251.Models;
using System;

namespace Demo1703251;

public partial class EditProductWindow : Window
{
    Product Product { get; set; }
    public EditProductWindow()
    {
        InitializeComponent();
        saveButton.Click += SaveButton_Click;
        back.Click += Back_Click;
        Product = new Product();
    }
    public EditProductWindow(Product product)
    {
        InitializeComponent();
        saveButton.Click += SaveButton_Click;
        back.Click += Back_Click;
        Product = product;
    }

    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    } 

    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (costTB.Text.Contains("-") == true)
        {
            attention.IsVisible = true;
            attention.Text = "Не может цена быть отрицательной!";
        }
        else
        {
            if (Product.ProductsArticul == null)
            {
                nameTB.Text += Product.ProductsName;
                //typeCB. += Product.PartnersDirectorName;
                articulTB.Text += Product.ProductsArticul;
                costTB.Text += Convert.ToDecimal(Product.ProductsMinCostForPartner);

                DataSource.Helper.dataBase.Products.Add(Product!);
                DataSource.Helper.dataBase.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                DataSource.Helper.dataBase.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    } 
}