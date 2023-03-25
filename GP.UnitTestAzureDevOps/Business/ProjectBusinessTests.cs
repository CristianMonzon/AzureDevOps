// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using Microsoft.VisualStudio.TestTools.UnitTesting;
using GP.AzureDevOps.Business.Configuration;
using System;

namespace GP.AzureDevOps.Business.Tests
{
    [TestClass()]
    public class ProjectBusinessTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
        }

        [TestMethod()]
        public void GetProjectTest()
        {
            try
            {
                // Act
                var projectBusiness = new ProjectBusiness();
                var projects = projectBusiness.GetProjects();
                var result = projects.Result;

                // Assert
                Assert.IsTrue(result != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}