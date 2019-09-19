using PracticalMVVM.Extensions;
using PracticalMVVM.Messages;
using PracticalMVVM.Model;
using PracticalMVVM.Services;
using PracticalMVVM.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticalMVVM.ViewModel
{
    public class CoffeeOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICoffeeDataService coffeeDataService;
        private IDialogService dialogService;

        public ICommand EditCommand { get; set; }

        private ObservableCollection<Coffee> coffees;
        public ObservableCollection<Coffee> Coffees
        {
            get
            {
                return coffees;
            }
            set
            {
                coffees = value;
                RaisePropertyChanged("Coffees");
            }
        }

        private Coffee selectedCoffee;
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

        public CoffeeOverviewViewModel(ICoffeeDataService coffeeDataService, IDialogService dialogService)
        {
            this.coffeeDataService = coffeeDataService;
            this.dialogService = dialogService;
            LoadData();
            LoadCommands();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            dialogService.CloseDetailDialog();
            RaisePropertyChanged("SelectedCoffee");
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCoffee, CanEditCoffee);
        }

        private void EditCoffee(object obj)
        {
            Messenger.Default.Send<Coffee>(selectedCoffee);
            dialogService.ShowDetailDialog();
        }

        private bool CanEditCoffee(object obj)
        {
            if (SelectedCoffee != null)
                return true;
            return false;
        }

        private void LoadData()
        {
            Coffees = coffeeDataService.GetAllCoffees().ToObservableCollection();
        }
    }
}
