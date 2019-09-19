using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalMVVM.Model;
using PracticalMVVM.Services;
using PracticalMVVM.Tests.Mocks;
using PracticalMVVM.ViewModel;

namespace PracticalMVVM.Tests
{
    [TestClass]
    public class CoffeeOverviewViewModelTest
    {
        private ICoffeeDataService coffeeDataService;
        private IDialogService dialogService;

        [TestInitialize]
        public void Init()
        {
            coffeeDataService = new MockCoffeeDataService(new MockRepository());
            dialogService = new MockDialogService();
        }
        [TestMethod]
        public void LoadAllCoffees()
        {
            //Arrange
            ObservableCollection<Coffee> coffees = null;
            var expectedCoffees = coffeeDataService.GetAllCoffees();

            //Act
            var viewModel = new CoffeeOverviewViewModel(this.coffeeDataService, this.dialogService);
            coffees = viewModel.Coffees;

            //Assert
            CollectionAssert.Equals(expectedCoffees, coffees);
        }
    }
}
