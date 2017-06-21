using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWorkingWithData_2;
using MVCWorkingWithData_2.Controllers;
using MVCWorkingWithData_2.ViewModels;

namespace MVCWorkingWithData_2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var db = new Fakes.FakeMVCWorkingWithDataDB();
            db.AddSet(TestData.Restaurants);
                //Instantiate with FAKE data overload
            HomeController controller = new HomeController(db);
                //Use Faked Context, Request and Headers so we do not get Exceptions 
                //with .IsAjaxRequest when the Context is missing in a UNIT TEST
            controller.ControllerContext = new Fakes.FakeControllerContext();

            // Act
            ViewResult result = controller.Index() as ViewResult;
                //Using this for the Assert
            IEnumerable<RestaurantListViewModel> model = result.Model as IEnumerable<RestaurantListViewModel>;

            // Assert
            //Assert.IsNotNull(result);
            Assert.AreEqual(10, model.Count());
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
