using PracticalMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalMVVM.Services
{
    public interface ICoffeeDataService
    {
        void DeleteCoffee(Coffee coffee);
        List<Coffee> GetAllCoffees();
        Coffee GetCoffeeDetail(int coffeeId);
        void UpdateCoffee(Coffee coffee);
    }
}
