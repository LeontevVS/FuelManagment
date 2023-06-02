using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FuelManagment
{
    /// <summary>
    /// Логика взаимодействия для FillOnCardWindow.xaml
    /// </summary>
    public partial class FillOnCardWindow : Window
    {
        FillOnCard _fillOnCard;
        MainWindow _mw;

        public FillOnCardWindow(MainWindow mw, FillOnCard fillOnCard = null)
        {
            _mw = mw;
            if (fillOnCard is null)
                _fillOnCard = new FillOnCard() 
                { 
                    Id = 0, 
                    Date = DateTime.Now
                };
            else
                _fillOnCard = fillOnCard;

            InitializeComponent();

            cbWaybill.ItemsSource = Context.GetContext().Waybills.ToList();
            cbGasStation.ItemsSource = Context.GetContext().GasStations.ToList();
            DataContext = _fillOnCard;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e) => Save();

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Несохраненные изменения будут утеряны.\nЗакрыть окно?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Close();
        }

        private bool Save()
        {
            StringBuilder errors = new StringBuilder();

            decimal fuelCount;

            if (string.IsNullOrWhiteSpace(tbFuelCount.Text) && !decimal.TryParse(tbFuelCount.Text, out fuelCount) && fuelCount <= 0)
                errors.AppendLine("Укажите количество топлива");
            if (string.IsNullOrWhiteSpace(cbGasStation.Text))
                errors.AppendLine("Укажите заправку");
            if (string.IsNullOrWhiteSpace(cbWaybill.Text))
                errors.AppendLine("Укажите путевой лист");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }

            _fillOnCard.SetProps();

            if (_fillOnCard.Id == 0)
                Context.GetContext().FillOnCards.Add(_fillOnCard);

            try
            {
                Context.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        private void BtnSaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            if (Save())
                Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mw.UpdateFillOnCardsList();
        }
    }
}
