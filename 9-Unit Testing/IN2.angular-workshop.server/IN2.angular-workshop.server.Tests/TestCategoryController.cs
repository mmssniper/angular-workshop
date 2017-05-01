using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IN2.angular_workshop.server.Tests.Helpers;
using IN2.angular_workshop.server.Services;
using IN2.angular_workshop.server.Controllers;
using System.Web.Http.Results;
using IN2.angular_workshop.server.Models;

namespace IN2.angular_workshop.server.Tests
{
    /// <summary>
    /// Summary description for TestCategoryController
    /// </summary>
    [TestClass]
    public class TestCategoryController
    {
        public TestCategoryController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAllCategories_ShouldReturnCorrectResultAndCollection()
        {
            var testCategories = CategoriesDbHelper.InitForBasicTest();

            ICategoryService catService = new CategoryService(testCategories);

            var categoryController = new CategoriesController(catService);

            var result = categoryController.GetAllCategories() as OkNegotiatedContentResult<List<Category>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(testCategories.Count, result.Content.Count);
        }

        [TestMethod]
        public void GetCategoryDetails_ShouldNotFindProduct()
        {
            var testCategories = CategoriesDbHelper.InitForBasicTest();

            ICategoryService catService = new CategoryService(testCategories);

            var categoryController = new CategoriesController(catService);

            var result = categoryController.GetCategory(1000);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCategoryDetails_ShouldReturnCorrentCategory()
        {
            var testCategories = CategoriesDbHelper.InitForBasicTest();

            ICategoryService catService = new CategoryService(testCategories);

            var categoryController = new CategoriesController(catService);

            var result = categoryController.GetCategory(1) as OkNegotiatedContentResult<Category>;

            Assert.IsNotNull(result);
            Assert.AreEqual(testCategories[0].Id, result.Content.Id);
            Assert.AreEqual(testCategories[0].Name, result.Content.Name);
        }
    }
}
