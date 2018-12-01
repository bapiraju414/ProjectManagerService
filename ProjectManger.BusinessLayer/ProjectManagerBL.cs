using ProjectManager.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManger.BusinessLayer
{
    public class ProjectManagerBL
    {
        private readonly ProjectManagerDBEntities pmdb;

        public ProjectManagerBL()
        {
            pmdb = new ProjectManagerDBEntities();
        }

        public ProjectManagerBL(ProjectManagerDBEntities projectManager)
        {
            pmdb = projectManager;
        }

        public int AddTask(Task item)
        {
            int result = -1;
            pmdb.Tasks.Add(item);
            result = pmdb.SaveChanges();
            return result;
        }

        public int AddUsers(User item)
        {
            int result = -1;
            pmdb.Users.Add(item);
            result = pmdb.SaveChanges();
            return result;
        }

        public int AddProjects(Project item)
        {
            int result = -1;
            pmdb.Projects.Add(item);
            result = pmdb.SaveChanges();
            return result;
        }

        public List<GetTasks_Result> GetAllTasks()
        {
            List<GetTasks_Result> getTaskResult = new List<GetTasks_Result>();

            getTaskResult = pmdb.GetTasks().ToList();

            return getTaskResult;
        }

        public List<GetProjects_Result> GetAllProjects()
        {
            List<GetProjects_Result> getProjectResult = new List<GetProjects_Result>();

            getProjectResult = pmdb.GetProjects().ToList();

            return getProjectResult;
        }

        public List<GetUsers_Result> GetAllUsers()
        {
            List<GetUsers_Result> getUsersResult = new List<GetUsers_Result>();

            getUsersResult = pmdb.GetUsers().ToList();

            return getUsersResult;
        }

        public int UpdateTask(Task task)
        {

            int result = -1;
            var tTask = pmdb.Tasks.Where(t => t.Task_ID == task.Task_ID).FirstOrDefault();
            if (tTask != null)
            {
                tTask.TaskName = task.TaskName;
                task.Parent_ID = task.Parent_ID;
                tTask.Priority = task.Priority;
                tTask.Start_Date = task.Start_Date;
                tTask.End_Date = task.End_Date;
                tTask.Status = task.Status;
                result = pmdb.SaveChanges();
            }
            return result;
        }

        public int UpdateUser(User User)
        {

            int result = -1;
            var user = pmdb.Users.Where(t => t.User_ID == User.User_ID).FirstOrDefault();
            if (user != null)
            {
                user.FirstName = User.FirstName;
                user.LastName = User.LastName;
                user.Employee_Id = User.Employee_Id;               
                result = pmdb.SaveChanges();
            }
            return result;
        }
        
        public int UpdateProject(Project Project)
        {

            int result = -1;
            var project = pmdb.Projects.Where(t => t.Project_ID == Project.Project_ID).FirstOrDefault();
            if (project != null)
            {
                project.ProjectName = Project.ProjectName;              
                project.Priority = Project.Priority;
                project.Start_Date = Project.Start_Date;
                project.End_Date = Project.End_Date;
                project.Status = Project.Status;
                result = pmdb.SaveChanges();
            }
            return result;
        }

        public int DeleteUser(int id)
        {

            int result = -1;
            var user = pmdb.Users.Where(t => t.User_ID == id).FirstOrDefault();
            if (user != null)
            {
                pmdb.Users.Remove(user);
                result = pmdb.SaveChanges();
            }
            return result;
        }

    }
}
