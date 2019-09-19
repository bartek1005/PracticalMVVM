using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalMVVM.DAL;
using PracticalMVVM.Services;
using PracticalMVVM.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalMVVM.Tests
{
    [TestClass]
    public class CoffeeDataServiceTest
    {
        private ICoffeeRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockRepository();
        }

        [TestMethod]
        public void GetCoffeeDetailTest()
        {
            //arrange
            var service = new CoffeeDataService(repository);

            //act
            var coffee = service.GetCoffeeDetail(1);

            //assert
            Assert.IsNotNull(coffee);

        }
    }
}
