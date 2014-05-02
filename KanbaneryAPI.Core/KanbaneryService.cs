using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using System.Web;
using KanbaneryAPI.Core.Models;
using Newtonsoft.Json;

namespace KanbaneryAPI.Core
{
    public static class KanbaneryService
    {

        public static List<TaskType> GetTaskTypes(string token, string workspace, int projectid)
        {
            string apiCall = string.Format("https://{1}.kanbanery.com/api/v1/projects/{2}/task_types.json?api_token={0}", new object[] { token, workspace, projectid });

            string response = ApiCall(apiCall, WebRequestMethods.Http.Get);
            return JsonConvert.DeserializeObject<List<TaskType>>(response);
        }

        public static UserResource GetUserResource(string token, string workspace)
        {
            string apiCall = string.Format("https://{0}.kanbanery.com/api/v1/user.json?api_token={1}", new object[] { workspace, token });

            string response = ApiCall(apiCall, WebRequestMethods.Http.Get);

            return JsonConvert.DeserializeObject<UserResource>(response);
        }

        public static List<UserResource> GetProjectsUserResources(string token, string workspace, int projectid)
        {
            string apiCall = string.Format("https://{0}.kanbanery.com/api/v1/projects/{2}/users.json?api_token={1}", new object[] { workspace, token, projectid });

            string response = ApiCall(apiCall, WebRequestMethods.Http.Get);

            return JsonConvert.DeserializeObject<List<UserResource>>(response);
        }

        public static List<ProjectMembershipResource> GetProjectsMembershipResources(string token, string workspace, int projectid)
        {
            string apiCall = string.Format("https://{0}.kanbanery.com/api/v1/projects/{2}/memberships.json?api_token={1}", new object[] { workspace, token, projectid });

            string response = ApiCall(apiCall, WebRequestMethods.Http.Get);

            return JsonConvert.DeserializeObject<List<ProjectMembershipResource>>(response);
        }

        public static ProjectMembershipResource CreateProjectsMembershipResources(string token, string workspace, int projectid, string email, string permission)
        {
            string apiCall =
                string.Format(
                    "https://{0}.kanbanery.com/api/v1/projects/{2}/memberships.json?api_token={1}&project_membership[email]={3}&project_membership[permission]={4}",
                    new object[] {workspace, token, projectid, HttpUtility.UrlEncode(email), permission});
           
            string response = ApiCall(apiCall, WebRequestMethods.Http.Post);

            return JsonConvert.DeserializeObject<ProjectMembershipResource>(response);
        }

        public static List<TaskResource> GetTaskResourcesFromProject(string token, string workspace, int projectid)
        {
            string apiCall = string.Format("https://{0}.kanbanery.com/api/v1/projects/{2}/tasks.json?api_token={1}", new object[] { workspace, token, projectid });

            string response = ApiCall(apiCall, WebRequestMethods.Http.Get);

            return JsonConvert.DeserializeObject<List<TaskResource>>(response);
        }

        public static List<WorkspaceResource> GetWorkspacesResources(string token)
        {
            string apiCall = string.Format("https://kanbanery.com/api/v1/user/workspaces.json?api_token={0}",
                new object[] {token});

            string response = ApiCall(apiCall, WebRequestMethods.Http.Get);
            
            return JsonConvert.DeserializeObject<List<WorkspaceResource>>(response);
        }

        public static TaskResource CreateTaskResource(string token, string workspace, int projectid, string title, string taskTypeName, string description
            , string estimateId = null, string priority = null, string readyToPull = null, string position = null)
        {

            if(string.IsNullOrEmpty(title))
                throw new KanbaneryApiException("Title is required");

            var queryData = new ArrayList{
				string.Format("{0}={1}", "task[title]", HttpUtility.UrlEncode(title)),
				string.Format("{0}={1}", "task[task_type_name]", HttpUtility.UrlEncode(taskTypeName)),
				string.Format("{0}={1}", "task[description]", HttpUtility.UrlEncode(description))
			};

            if(!string.IsNullOrEmpty(estimateId))
                queryData.Add(string.Format("{0}={1}", "task[estimate_id]", estimateId));

            if (!string.IsNullOrEmpty(priority))
                queryData.Add(string.Format("{0}={1}", "task[priority]", priority));

            if (!string.IsNullOrEmpty(readyToPull))
                queryData.Add(string.Format("{0}={1}", "task[ready_to_pull]", readyToPull));

            if (!string.IsNullOrEmpty(position))
                queryData.Add(string.Format("{0}={1}", "task[position]", position));

            var parameters = string.Join("&", (string[])queryData.ToArray(typeof(string)));

            string apiCall = string.Format(
                "https://{0}.kanbanery.com/api/v1/projects/{2}/tasks.json?api_token={1}&" + parameters,
                new object[] {workspace, token, projectid});
            
            string response = ApiCall(apiCall, WebRequestMethods.Http.Post);

            TaskResource task = null;

            if (response.Contains("201"))
                task = JsonConvert.DeserializeObject<TaskResource>(response);

            return task;
        }

        private static string ApiCall(string apiCall, string method)
        {
            string response;
            try
            {
                var req = WebRequest.Create(apiCall);
                req.Method = method;

                using (var r = (HttpWebResponse) req.GetResponse())
                using (var s = new StreamReader(r.GetResponseStream()))
                {
                    response = s.ReadToEnd();
                }
            }
            catch (NotSupportedException ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            catch (SecurityException ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            catch (UriFormatException ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            catch (NotImplementedException ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            catch (OutOfMemoryException ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            catch (IOException ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            catch (Exception ex)
            {
                throw new KanbaneryApiException("Could not complete the api call " + apiCall, ex);
            }
            return response;
        }
    }
}
