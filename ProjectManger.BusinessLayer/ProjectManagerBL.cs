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


        public partial class UserSet
        {
            public int userId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public Nullable<int> employeeId { get; set; }
            public Nullable<int> projectId { get; set; }
            public Nullable<int> taskId { get; set; }
        }
        public partial class Projectset
        {
            public int Project_ID { get; set; }
            public string ProjectName { get; set; }
            public Nullable<System.DateTime> Start_Date { get; set; }
            public Nullable<System.DateTime> End_Date { get; set; }
            public Nullable<int> Priority { get; set; }
            public bool Status { get; set; }
            public int User_ID { get; set; }
        }

        public partial class Taskset
        {
            public int Task_ID { get; set; }
            public Nullable<int> Parent_ID { get; set; }
            public Nullable<int> Project_ID { get; set; }
            public string TaskName { get; set; }
            public Nullable<System.DateTime> Start_Date { get; set; }
            public Nullable<System.DateTime> End_Date { get; set; }
            public Nullable<int> Priority { get; set; }
            public bool Status { get; set; }
            public int User_ID { get; set; }
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
            int projectid = -1;
            item.Project_ID = -1;
            pmdb.Projects.Add(item);
            pmdb.SaveChanges();
            projectid = item.Project_ID;
            return projectid;
        }

        public List<ParentTask> GetParentTask()
        {
            return pmdb.ParentTasks.ToList();
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

        public UserSet GetUserById(int Id)
        {
            UserSet userset = new UserSet();
            userset = pmdb.Users.Where(x => x.userId == Id).Select(t => new UserSet()
            {
                userId = t.userId,
                firstName = t.firstName,
                lastName = t.lastName,
                employeeId = t.employeeId,
               
            }).FirstOrDefault();
            return userset;
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
            var user = pmdb.Users.Where(t => t.userId == User.userId).FirstOrDefault();
            if (user != null)
            {
                user.firstName = User.firstName;
                user.lastName = User.lastName;
                user.employeeId = User.employeeId;               
                result = pmdb.SaveChanges();
            }
            return result;
        }

        public int UpdateUserProjectId(int userId,int ProjectId)
        {

            int result = -1;
            var user = pmdb.Users.Where(t => t.userId == userId).FirstOrDefault();
            if (user != null)
            {
                user.projectId = ProjectId;                
                result = pmdb.SaveChanges();
            }
            return result;
        }

        public int UpdateUserTaskId(int userId, int TaskId)
        {

            int result = -1;
            var user = pmdb.Users.Where(t => t.userId == userId).FirstOrDefault();
            if (user != null)
            {
                user.taskId = TaskId;
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
            var user = pmdb.Users.Where(t => t.userId == id).FirstOrDefault();
            if (user != null)
            {
                pmdb.Users.Remove(user);
                result = pmdb.SaveChanges();
            }
            return result;
        }

    }
}

