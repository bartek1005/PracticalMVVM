using MahApps.Metro.Controls;
using PracticalMVVM.Extensions;
using PracticalMVVM.Model;
using PracticalMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CoffeeOverviewView : MetroWindow
    {
        private Coffee selectedCoffee;
        private ObservableCollection<Coffee> coffees;
        public CoffeeOverviewView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            CoffeeDataService coffeeDataService = new CoffeeDataService();
            coffees = coffeeDataService.GetAllCoffees().ToObservableCollection();
            CoffeeListView.ItemsSource = coffees;
        }

        public void EditCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            CoffeeDetailView coffeeDetailView = new CoffeeDetailView();
            coffeeDetailView.SelectedCoffee = selectedCoffee;
            coffeeDetailView.Show();
        }
        public void CoffeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCoffee = e.AddedItems[0] as Coffee;

            if (e != null)
            {
                CoffeeIdLabel.Content = selectedCoffee.CoffeeId;
                CoffeeNameLabel.Content = selectedCoffee.CoffeeName;
                DescriptionLabel.Content = selectedCoffee.Description;
                PriceLabel.Content = selectedCoffee.Price;
                StockAmountLabel.Content = selectedCoffee.AmountInStock.ToString();
                FirstTimeAddedLabel.Content = selectedCoffee.FirstAddedToStockDate.ToShortDateString();

                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri("/PracticalMVVM;component/Images/coffee" + selectedCoffee.CoffeeId + ".jpg", UriKind.Relative);
                img.EndInit();
                CoffeeImage.Source = img;
            }
        }

        private void AddFakeCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            Coffee coffee = new Coffee()
            {
                CoffeeId = 100,
                CoffeeName = "New Coffee",
                Price = 1,
                AmountInStock = 10,
                FirstAddedToStockDate = DateTime.UtcNow,
                Description = "Who knows",
                InStock = true,
                OriginCountry = Country.Ethiopia,
                ImageId = 10
            };
            coffees.Add(coffee);
        }
    }
}
