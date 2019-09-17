using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticalMVVM.DAL;
using PracticalMVVM.Model;

namespace PracticalMVVM.Services
{
    public class CoffeeDataService : IDataService
    {
        CoffeeRepository repository = new CoffeeRepository();
        public CoffeeDataService()
        {
            this.repository = repository;
        }
        public void DeleteCoffee(Coffee coffee)
        {
            repository.DeleteCoffee(coffee);
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
            repository.UpdateCoffee(coffee);
        }
    }
}
