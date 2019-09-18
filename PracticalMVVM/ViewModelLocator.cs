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
        private static CoffeeOverviewViewModel coffeeOverviewViewModel = new CoffeeOverviewViewModel();
        private static CoffeeDetailViewModel coffeeDetailViewModel = new CoffeeDetailViewModel();

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
