using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientData2;
using PatientData2.Controllers;
using System.Net.Http;
using MongoDB.Bson;

namespace PatientData2.Tests.Controllers
{
    [TestClass]
    public class PatientsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            PatientsController controller = new PatientsController();

            // Act
            HttpResponseMessage result = controller.Get(ObjectId.Parse("59643fcea45c9d056cd1d2a0").ToString()) as HttpResponseMessage;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Medications NOOOOT Found...", result);
        }
    }
}
