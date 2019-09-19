using PracticalMVVM.DAL;
using PracticalMVVM.Model;
using PracticalMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalMVVM.Tests.Mocks
{
    public class MockCoffeeDataService : ICoffeeDataService
    {
        private ICoffeeRepository repository;
        public MockCoffeeDataService(ICoffeeRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteCoffee(Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public List<Coffee> GetAllCoffees()
        {
            return repository.GetCoffees();
        }

        public Coffee GetCoffeeDetail(int coffeeId)
        {
            return repository.GetCoffeeById(coffeeId);
        }

        public void UpdateCoffee(Coffee coffee)
        {
            throw new NotImplementedException();
        }
    }
}
