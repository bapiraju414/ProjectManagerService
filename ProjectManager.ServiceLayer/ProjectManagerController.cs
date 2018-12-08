using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.DataLayer;
using ProjectManger.BusinessLayer;
using static ProjectManger.BusinessLayer.ProjectManagerBL;

namespace ProjectManager.ServiceLayer
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectManagerController : ApiController
    {
         ProjectManagerBL pbl = new ProjectManagerBL();



        [Route("api/GetTaskDetails")]
        public IEnumerable<GetTaskDetails_Result> GetTaskDetals()
        {
            return pbl.GetTaskDetails();
        }

        [Route("api/GetProjectDetails")]
        public IEnumerable<GetProjecTask_Result> GetProjectDetails()
        {
            return pbl.GetProjectDetails();
        }

        [Route("api/GetTasks")]
        public IEnumerable<GetTasks_Result> GetTasks()
        {
            return pbl.GetAllTasks();
        }

        [Route("api/GetTasksById/{id:int}")]
        public Taskset GetTasksById(int id)
        {
            return pbl.GetTaskById(id); 
        }

        [Route("api/GetProjects")]
        public IEnumerable<GetProjects_Result> GetProjects()
        {
            return pbl.GetAllProjects();
        }

        [Route("api/GetUsers")]
        public IEnumerable<GetUsers_Result> GetUsers()
        {
            return pbl.GetAllUsers();
        }

        [Route("api/GetUserById/{id:int}")]
        public UserSet GetUserById(int id)
        {          
            
            return pbl.GetUserById(id); ;

        }

        [Route("api/GetParentTask")]
        public IEnumerable<ParentTask> GetParentTask()
        {
            return pbl.GetParentTask();
        }

        [Route("api/AddTask")]
        public void Post([FromBody]Taskset item)
        {
            Task task = new Task();
            task.TaskName = item.TaskName;
            task.Parent_ID = item.Parent_ID;
            task.Priority = item.Priority;
            task.Project_ID = item.Project_ID;
            task.Priority = item.Priority;
            task.Start_Date = item.Start_Date;
            task.End_Date = item.End_Date;
            task.Status = item.Status;
            int taskid =pbl.AddTask(task);
            pbl.UpdateUserTaskId(item.User_ID, taskid);
        }

        [Route("api/AddProject")]
        public void Post([FromBody]Projectset item)
        {
            Project project = new Project();
            project.ProjectName = item.ProjectName;
            project.Start_Date = item.Start_Date;
            project.End_Date = item.End_Date;
            project.Priority = item.Priority;
            project.Status = item.Status;
            int projectid= pbl.AddProjects(project);
            pbl.UpdateUserProjectId(item.User_ID, projectid);
        }


        [Route("api/AddUser")]
        public void Post([FromBody]User item)
        {
            pbl.AddUsers(item);
        }

        [Route("api/UpdateTask")]
        public void Put([FromBody]Task item)
        {
            pbl.UpdateTask(item);
        }

        [Route("api/UpdateProject")]
        public void Put([FromBody]Project item)
        {
            pbl.UpdateProject(item);
        }

        [Route("api/UpdateUser")]
        public void Put([FromBody]User item)
        {
            pbl.UpdateUser(item);
        }

        [Route("api/DeleteUser/{id:int}")]
        public void Delete(int id)
        {
            pbl.DeleteUser(id);


        }
    }
}