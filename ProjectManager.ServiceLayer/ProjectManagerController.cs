using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.DataLayer;
using ProjectManger.BusinessLayer;

namespace ProjectManager.ServiceLayer
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectManagerController : ApiController
    {
         ProjectManagerBL pbl = new ProjectManagerBL();

        [Route("api/GetTasks")]
        public IEnumerable<GetTasks_Result> GetTasks()
        {
            return pbl.GetAllTasks();
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

       [Route("api/AddTask")]
        public void Post([FromBody]Task item)
        {
            pbl.AddTask(item);
        }

        [Route("api/AddProject")]
        public void Post([FromBody]Project item)
        {
            pbl.AddProjects(item);
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