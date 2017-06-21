using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWorkingWithData_2.Tests.Fakes;
using MVCWorkingWithData_2.Controllers;

namespace MVCWorkingWithData_2.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTests
    {
        [TestMethod]
        public void Create_Saves_Restaurant_When_Valid()
        {
            var db = new Fakes.FakeMVCWorkingWithDataDB();
            //var controller = new RestaurantsController(db);

        }

    }
}
