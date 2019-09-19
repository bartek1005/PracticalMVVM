using PracticalMVVM.Messages;
using PracticalMVVM.Model;
using PracticalMVVM.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticalMVVM.ViewModel
{
    public class CoffeeDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Coffee selectedCoffee;
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public Coffee SelectedCoffee
        {
            get
            {
                return selectedCoffee;
            }
            set
            {
                selectedCoffee = value;
                RaisePropertyChanged("SelectedCoffee");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public CoffeeDetailViewModel()
        {
            DeleteCommand = new CustomCommand(DeleteCoffee, CanDeleteCoffee);
            SaveCommand = new CustomCommand(SaveCoffee, CanSaveCoffee);

            Messenger.Default.Register<Coffee>(this, OnCoffeeReceived);
        }

        private void OnCoffeeReceived(Coffee coffee)
        {
            SelectedCoffee = coffee;
        }

        private void DeleteCoffee(object obj)
        {
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanDeleteCoffee(object obj)
        {
            return true;
        }

        private void SaveCoffee(object obj)
        {
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanSaveCoffee(object obj)
        {
            return true;
        }
    }
}
