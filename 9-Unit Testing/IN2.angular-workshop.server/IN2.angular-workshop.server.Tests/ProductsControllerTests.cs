using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IN2.angular_workshop.server.Tests.Helpers;
using IN2.angular_workshop.server.Controllers;
using IN2.angular_workshop.server.Models;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.Http;
using Moq;
using IN2.angular_workshop.server.Services;
using System.Web.Http.Results;

namespace IN2.angular_workshop.server.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void GetBestSelling_ShouldReturnCorrectNumberOfProducts()
        {
            var dummyProductsService = new DummyProductsService();

            var productsController = new ProductsController(dummyProductsService);
            productsController.Request = new HttpRequestMessage();
            productsController.Configuration = new HttpConfiguration();

            var response = productsController.GetTopThreeBestSellers();

            List<Product> products;
            Assert.IsTrue(response.TryGetContentValue<List<Product>>(out products));
            Assert.AreEqual(dummyProductsService.GetBestSellingProducts().Count, products.Count);
        }

        [TestMethod]
        public void GetProductDetails_WhenValidId_ShouldReturnCorrectProduct()
        {
            //setup service mock
            var serviceMock = new Mock<IProductsService>();
            serviceMock.Setup(service => service.GetProduct(1))
                        .Returns(
                            new Product{
                                Id = 1,
                                Name = "Test products"
                            });

            var productsController = new ProductsController(serviceMock.Object);

            var result = productsController.GetProductDetails(1);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Product>));
            var okResult = result as OkNegotiatedContentResult<Product>;

            Assert.AreEqual("Test products", okResult.Content.Name);
            Assert.AreEqual(1, okResult.Content.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Hey...somebody forgot something!?")]
        public void AddProductDiscount_OnInvalidState_ShouldThrowException()
        {
            var serviceMock = new Mock<IProductsService>();
            var controller = new ProductsController(serviceMock.Object);

            controller.AddProductDiscount(new ProductDiscount() { ProductId = 1, DiscountPrice = 1 });
        }
    }
}
