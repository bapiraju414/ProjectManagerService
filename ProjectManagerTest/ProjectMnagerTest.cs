using Moq;
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
            Assert.IsNotNull(tasks);
            Assert.IsTrue(tasks.Count > 0);
        }

        [TestMethod]
        public void GetUserTestBL()
        {
            Mock<ProjectManagerDBEntities> mockContext = MockUserSP();
            var taskManagerBL = new ProjectManagerBL(mockContext.Object);
            List<GetUsers_Result> users = taskManagerBL.GetAllUsers();
            NUnit.Framework.Assert.IsNotNull(users);
            foreach (var user in users)
            {
                Assert.IsNotNull(user.userId);
                Assert.IsNotNull(user.firstName);
                Assert.IsNotNull(user.lastName);
                Assert.IsNotNull(user.employeeId);

            }
        }

        [TestMethod]
        public void GetTaskTestBL()
        {
            Mock<ProjectManagerDBEntities> mockContext = MockTasksSP();
            var taskManagerBL = new ProjectManagerBL(mockContext.Object);
            List<GetTasks_Result> tasks = taskManagerBL.GetAllTasks();
            NUnit.Framework.Assert.IsNotNull(tasks);
            foreach (var task in tasks)
            {
                Assert.IsNotNull(task.TaskName);
                Assert.IsNotNull(task.Task_ID);
                Assert.IsNotNull(task.Project_ID);
                Assert.IsNotNull(task.Parent_ID);

            }
        }

        [TestMethod]
        public void GetProjectTestBL()
        {
            Mock<ProjectManagerDBEntities> mockContext = MockProjectsSP();
            var taskManagerBL = new ProjectManagerBL(mockContext.Object);
            List<GetProjects_Result> projects = taskManagerBL.GetAllProjects();
            NUnit.Framework.Assert.IsNotNull(projects);
            foreach (var project in projects)
            {
                Assert.IsNotNull(project.Project_ID);
                Assert.IsNotNull(project.ProjectName);
                Assert.IsNotNull(project.Status);
                Assert.IsNotNull(project.Priority);

            }
        }

        [TestMethod]
        public void AddTaskTest()
        {
            Mock<ProjectManagerDBEntities> mockContext = MockDataSetList();
            var projectManagerBL = new ProjectManagerBL(mockContext.Object);
            Task model = new Task()
            {
                Task_ID = 1,
                TaskName = "Task 1",
                Parent_ID = 1,
                Priority = 10,
                Start_Date = DateTime.Now.Date,
                End_Date = DateTime.Now.AddDays(10)
            };
            int result = projectManagerBL.AddTask(model);

            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void UpdateTaskTest()
        {
            Mock<ProjectManagerDBEntities> mockContext = MockDataSetList();
            var projectManagerBL = new ProjectManagerBL(mockContext.Object);
            Task model = new Task()
            {
                Task_ID = 1,
                TaskName = "Task 1",
                Priority = 10,
                Parent_ID = 1,
                Start_Date = DateTime.Now.Date,
                End_Date = DateTime.Now.AddDays(10)
            };
            int result = projectManagerBL.UpdateTask(model);

            Assert.IsTrue(result == 0);
        }

        private static Mock<ProjectManagerDBEntities> MockDataSetList()
        {
            var data = new List<Task>()
            {
               new Task()
                {
                    Task_ID = 1,
                    TaskName = "Task 1",
                       Priority =10,
                        Parent_ID=1,
                       Start_Date = DateTime.Now.Date,
                       End_Date = DateTime.Now.AddDays(10)
                },
               new Task()
                {
                    Task_ID = 2,
                    TaskName = "Task 2",
                       Priority =20,
                        Parent_ID=2,
                       Start_Date = DateTime.Now.Date,
                       End_Date = DateTime.Now.AddDays(10)
                },
                 new Task()
                {
                    Task_ID = 3,
                    TaskName = "Task 3",
                       Priority =10,
                        Parent_ID=3,
                       Start_Date = DateTime.Now.Date,
                       End_Date = DateTime.Now.AddDays(10)
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Task>>();          
            mockset.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.Tasks).Returns(mockset.Object);

            return mockContext;
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

        private static Mock<ProjectManagerDBEntities> MockUserSP()
        {
            var data = new List<GetUsers_Result>()
            {
               new GetUsers_Result()
                {
                   userId =1,
                   firstName = "Bapi",
                   lastName="raju",
                   employeeId=1234

                },
               new GetUsers_Result()
                {
                   userId =1,
                   firstName = "Bapi",
                   lastName="raju",
                   employeeId=1234

                },
                 new GetUsers_Result()
                {
                  userId =1,
                   firstName = "Bapi",
                   lastName="raju",
                   employeeId=1234

                }
            }.AsQueryable();


            var mocksp = new Mock<ObjectResult<GetUsers_Result>>();
            mocksp.As<IQueryable<GetUsers_Result>>().Setup(m => m.Provider).Returns(data.Provider);
            mocksp.As<IQueryable<GetUsers_Result>>().Setup(m => m.Expression).Returns(data.Expression);
            mocksp.As<IQueryable<GetUsers_Result>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocksp.As<IQueryable<GetUsers_Result>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.GetUsers()).Returns(mocksp.Object);

            return mockContext;
        }

        private static Mock<ProjectManagerDBEntities> MockTasksSP()
        {
            var data = new List<GetTasks_Result>()
            {
               new GetTasks_Result()
                {
                   TaskName ="Task1",
                   Task_ID=1,
                   End_Date=null,
                   Start_Date=null,
                   Priority=20,
                   Parent_ID=1,
                   Project_ID=2,
                   Status=false

                },
                new GetTasks_Result()
                {
                   TaskName ="Task1",
                   Task_ID=1,
                   End_Date=null,
                   Start_Date=null,
                   Priority=20,
                   Parent_ID=1,
                   Project_ID=2,
                   Status=false

                },
            }.AsQueryable();


            var mocksp = new Mock<ObjectResult<GetTasks_Result>>();
            mocksp.As<IQueryable<GetTasks_Result>>().Setup(m => m.Provider).Returns(data.Provider);
            mocksp.As<IQueryable<GetTasks_Result>>().Setup(m => m.Expression).Returns(data.Expression);
            mocksp.As<IQueryable<GetTasks_Result>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocksp.As<IQueryable<GetTasks_Result>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.GetTasks()).Returns(mocksp.Object);

            return mockContext;
        }

        private static Mock<ProjectManagerDBEntities> MockProjectsSP()
        {
            var data = new List<GetProjects_Result>()
            {
               new GetProjects_Result()
                {
                   Project_ID=1,
                   ProjectName="Project1",
                   Start_Date=null,
                   End_Date=null,
                   Priority=20,
                   Status=true

                },
               new GetProjects_Result()
                {
                   Project_ID=1,
                   ProjectName="Project1",
                   Start_Date=null,
                   End_Date=null,
                   Priority=20,
                   Status=true

                }
            }.AsQueryable();


            var mocksp = new Mock<ObjectResult<GetProjects_Result>>();
            mocksp.As<IQueryable<GetProjects_Result>>().Setup(m => m.Provider).Returns(data.Provider);
            mocksp.As<IQueryable<GetProjects_Result>>().Setup(m => m.Expression).Returns(data.Expression);
            mocksp.As<IQueryable<GetProjects_Result>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocksp.As<IQueryable<GetProjects_Result>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.GetProjects()).Returns(mocksp.Object);

            return mockContext;
        }
    }
}
