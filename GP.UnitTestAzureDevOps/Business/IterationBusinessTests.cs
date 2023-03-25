// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using GP.AzureDevOps.Business;
using GP.AzureDevOps.Business.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GPUnitTestAzureDevOps.Business.Tests
{
    [TestClass()]
    public class IterationBusinessTests
    {
        public AzureConfig Config;
        public string ProjectName { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            Config = new AzureConfig();
            ProjectName = Config.ProjectName;
        }

        [TestMethod()]
        public void GetIterationsTest()
        {
            try
            {
                // Act
                var iterationBusiness = new IterationBusiness();
                var iterations = iterationBusiness.GetIterations(ProjectName);
                var result = iterations.Result;

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