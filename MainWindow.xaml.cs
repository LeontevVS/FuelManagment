using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FuelManagment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;
            AuthorisationWindow authorisation = new AuthorisationWindow(this);
            authorisation.Show();
            UpdateFillOnCardsList();
        }

        public void UpdateFillOnCardsList() => DGridFillOnCards.ItemsSource = Context.GetContext().FillOnCards.ToList();

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FillOnCardWindow wind = new FillOnCardWindow(this, DGridFillOnCards.SelectedItem as FillOnCard);
            wind.Show();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            FillOnCardWindow wind = new FillOnCardWindow(this);
            wind.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    Context.GetContext().FillOnCards.Remove(DGridFillOnCards.SelectedItem as FillOnCard);
                    Context.GetContext().SaveChanges();
                    UpdateFillOnCardsList();
                    MessageBox.Show("Данные удалены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
