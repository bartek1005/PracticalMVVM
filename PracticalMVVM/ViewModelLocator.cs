using PracticalMVVM.DAL;
using PracticalMVVM.Services;
using PracticalMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalMVVM
{
    public class ViewModelLocator
    {
        private static IDialogService dialogService = new DialogService();
        private static ICoffeeDataService coffeeDataService = new CoffeeDataService(new CoffeeRepository());
        private static CoffeeOverviewViewModel coffeeOverviewViewModel = new CoffeeOverviewViewModel(coffeeDataService,dialogService);
        private static CoffeeDetailViewModel coffeeDetailViewModel = new CoffeeDetailViewModel(coffeeDataService, dialogService);

        public CoffeeOverviewViewModel CoffeeOverviewViewModel
        {
            get
            {
                return coffeeOverviewViewModel;
            }
        }

        public CoffeeDetailViewModel CoffeeDetailViewModel
        {
            get
            {
                return coffeeDetailViewModel;
            }
        }
    }
}
