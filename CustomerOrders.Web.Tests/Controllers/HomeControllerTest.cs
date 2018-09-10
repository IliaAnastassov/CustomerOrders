﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerOrders.Web;
using CustomerOrders.Web.Controllers;
using System.Threading.Tasks;

namespace CustomerOrders.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            Task<ActionResult> result = controller.Index() as Task<ActionResult>;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
