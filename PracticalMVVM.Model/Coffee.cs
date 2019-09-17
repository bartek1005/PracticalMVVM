using System;
using System.ComponentModel;

namespace PracticalMVVM.Model
{
    public class Coffee : INotifyPropertyChanged
    {
        private int coffeeID;
        private string coffeeName;
        private int price;

        public int CoffeeId
        {
            get
            {
                return coffeeID;
            }
            set
            {
                coffeeID = value;
                RaisePropertyChanged("CoffeeId");
            }
        }
        public string CoffeeName
        {
            get
            {
                return coffeeName;
            }
            set
            {
                coffeeName = value;
                RaisePropertyChanged("CoffeeName");
            }
        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }
        public string Description { get; set; }
        public Country OriginCountry { get; set; }
        public bool InStock { get; set; }
        public int AmountInStock { get; set; }
        public DateTime FirstAddedToStockDate { get; set; }
        public int ImageId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
