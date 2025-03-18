using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo1703251.Models;

namespace Demo1703251;

public partial class EditPartnerWindow : Window
{
    Partner Partner { get; set; }

    public EditPartnerWindow()
    {
        InitializeComponent();
        Partner = new Partner();
        partnerGrid.DataContext = Partner;
        back.Click += Back_Click;
        saveButton.Click += SaveButton_Click;
        SetData();
    }

    public EditPartnerWindow(Partner partner)
    {
        InitializeComponent();
        Partner = partner;
        partnerGrid.DataContext = Partner;
        back.Click += Back_Click;
        saveButton.Click += SaveButton_Click;
        toHistory.Click += ToHistory_Click;
        SetData();
    }

    private void ToHistory_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //HistoryWindow historyWindow = new HistoryWindow(Partner);
        //historyWindow.Show();
        //Close();
    } 

    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (emailTB.Text.Contains("@gmail") == false || emailTB.Text.Contains("@mail") == false)
        {
            attention.IsVisible = true;
            attention.Text = "Неверно заполнено поле с электронной почтой Ввдеите @mail/@gmail!";           
        }
        else
        {
            if (Partner.PartnersId == 0)
            {
                nameTB.Text += Partner.PartnersName;
                directorNameTB.Text += Partner.PartnersDirectorName;
                adressTB.Text += Partner.PartnersAdress;
                phoneTB.Text += Partner.PartnersPhone;
                emailTB.Text += Partner.PartnersEmail;

                DataSource.Helper.dataBase.Partners.Add(Partner!);
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

    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    } 

    private void SetData()
    {
        if (Partner.PartnersId == 0)
        {
            toHistory.IsVisible = false;
        }
        else
        {
            toHistory.IsVisible = true;
        }
    }
}