// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using GP.AzureDevOps.Business;
using GP.AzureDevOps.Business.Configuration;

namespace GPUnitTestAzureDevOps.Business.Tests
{
    [TestClass()]
    public class WorkItemBusinessTests
    {
        public AzureConfig Config;
        public string ProjectName { get; set; }

        public string Iteration { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            Config = new AzureConfig();
            ProjectName = Config.ProjectName;
            Iteration = Config.IterationName;
        }

        [TestMethod()]
        public void GetEpicTest()
        {
            try
            {
                // Act
                var workItemBusiness = new WorkItemBusiness(ProjectName, Iteration);
                var resultItem = workItemBusiness.GetEpic();
                var result = resultItem.Result;

                // Assert
                Assert.IsTrue(result != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod()]
        public void GetIssueTest()
        {
            try
            {
                // Act
                var workItemBusiness = new WorkItemBusiness(ProjectName, Iteration);
                var resultItem = workItemBusiness.GetIssue();
                var result = resultItem.Result;

                // Assert
                Assert.IsTrue(result != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void GetTaskTest()
        {
            try
            {
                // Act
                var workItemBusiness = new WorkItemBusiness(ProjectName, Iteration);
                var resultItem = workItemBusiness.GetTasks();
                var result = resultItem.Result;

                // Assert
                Assert.IsTrue(result != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod()]
        public void GetWorkItemsTest()
        {
            try
            {
                // Act
                var workItemBusiness = new WorkItemBusiness(ProjectName, Iteration);
                var resultItem = workItemBusiness.GetWorkItems();
                var result = resultItem.Result;

                // Assert
                Assert.IsTrue(result != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void GetIssueWithWorkItemsTest()
        {
            try
            {
                // Act
                var workItemBusiness = new WorkItemBusiness(ProjectName, Iteration);
                var resultItem = workItemBusiness.GetIssueWithWorkItem();
                var result = resultItem.Result;

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