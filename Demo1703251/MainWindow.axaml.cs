using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;

namespace Demo1703251
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            addPartnerButton.Click += AddPartnerButton_Click;
            productsButton.Click += ProductsButton_Click;
            partnersButton.Click += PartnersButton_Click;
            addProductButton.Click += AddProductButton_Click;
            SetData();
        }

        private void AddProductButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            EditProductWindow editProductWindow = new EditProductWindow();
            editProductWindow.Show();
            Close();
        } 

        private void PartnersButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            title2TB.IsVisible = false;
            titleTB.IsVisible = true;

            productsButton.IsEnabled = true;
            partnersButton.IsEnabled = false;

            partnersLB.IsVisible = true;
            productsLB.IsVisible = false;

            addPartnerButton.IsVisible = true;
            addProductButton.IsVisible = false;
        } 

        private void ProductsButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            title2TB.IsVisible = true;
            titleTB.IsVisible = false;

            productsButton.IsEnabled = false;
            partnersButton.IsEnabled = true;

            partnersLB.IsVisible = false;
            productsLB.IsVisible = true;

            addPartnerButton.IsVisible = false;
            addProductButton.IsVisible = true;
        } 

        private void AddPartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            EditPartnerWindow editPartnerWindow = new EditPartnerWindow();
            editPartnerWindow.Show();
            Close();
        } 

        private void SetData()
        {
            partnersLB.ItemsSource = DataSource.Helper.dataBase.Partners;
            productsLB.ItemsSource = DataSource.Helper.dataBase.Products.Include(x => x.ProductsTypeNavigation);

            if (partnersLB.IsVisible == true)
            {
                partnersButton.IsEnabled = false;
            }
        }

        private void Border_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            int id = (int)(sender as Border)?.Tag!;
            var partners = DataSource.Helper.dataBase.Partners.Find(id);
            if (partners != null)
            {
                EditPartnerWindow partnerWindow = new EditPartnerWindow(partners);
                partnerWindow.Show();
                Close();
            }
        }

        private void Border_DoubleTapped_1(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            /*int id = (int)(sender as Border)?.Tag!;
            var product = DataSource.Helper.dataBase.Partners.Find(id);
            if (product != null)
            {
                EditPartnerWindow partnerWindow = new EditPartnerWindow(product);
                partnerWindow.Show();
                Close();
            }*/
        }
    }
}