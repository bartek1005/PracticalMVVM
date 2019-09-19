using System;
using System.Collections.Generic;
using System.Text;
using PracticalMVVM.Model;

namespace PracticalMVVM.DAL
{
    public interface ICoffeeRepository
    {
        void DeleteCoffee(Coffee coffee);
        Coffee GetACoffee();
        Coffee GetCoffeeById(int id);
        List<Coffee> GetCoffees();
        void UpdateCoffee(Coffee coffee);
    }
}
