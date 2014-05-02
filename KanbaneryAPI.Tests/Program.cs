using System;
using System.Linq;
using KanbaneryAPI.Core;

namespace KanbaneryAPI.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "your_api_token"
            var workspace = KanbaneryService.GetWorkspacesResources(token).First();

            var project = workspace.Projects.First(); 
                
                
            var users = KanbaneryService.GetProjectsUserResources(token,
                workspace.Name, project.ProjectId);

            var taskTypes = KanbaneryService.GetTaskTypes(token,workspace.Name,project.ProjectId);

     
            var tasks = KanbaneryService.GetTaskResourcesFromProject(token,workspace.Name, project.ProjectId);

            var userResource = KanbaneryService.GetUserResource(token, workspace.Name);

            var task = KanbaneryService.CreateTaskResource(token, workspace.Name,
                project.ProjectId, "Test of API", taskTypes.First().Name, "This is a description", "", "", "", "");

            
            Console.ReadKey();
        }
    }
}
