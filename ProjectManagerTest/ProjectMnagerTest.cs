using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using ProjectManager.DataLayer;
using ProjectManager.ServiceLayer;
using ProjectManger.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectManagerTest
{
    [TestClass]
    public class ProjectMnagerTest
    {
       
        [TestMethod]
        public void GetParentTasksTest_WithoutID()
        {
            Mock<ProjectManagerDBEntities> mockContext = MockparentTask();
            var taskManagerBL = new ProjectManagerBL(mockContext.Object);
            List<ParentTask> tasks = taskManagerBL.GetParentTask();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(tasks);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(tasks.Count > 0);
        }


        private static Mock<ProjectManagerDBEntities> MockparentTask()
        {
            var data = new List<ParentTask>()
            {
               new ParentTask()
                {
                   Parent_ID =1,
                   Parent_Task="ygfugu"

                },
               new ParentTask()
                {
                    Parent_ID =1,
                   Parent_Task="ygfugu"
                },
                 new ParentTask()
                {
                    Parent_ID =1,
                   Parent_Task="ygfugu"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<ParentTask>>();
            mockset.As<IQueryable<ParentTask>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<ParentTask>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<ParentTask>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<ParentTask>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.ParentTasks).Returns(mockset.Object);

            return mockContext;
        }

    }
}
