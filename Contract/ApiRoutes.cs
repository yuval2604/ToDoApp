using System;
namespace ToDoApp.Contract
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class Tasks
        {
            public const string GetAll = Base + "/tasks";
            public const string Create = Base + "/tasks";

            public const string Get = Base + "/tasks/{taskId}";
            public const string Update = Base + "/tasks/{taskId}";

            public const string Delete = Base + "/tasks/{taskId}";
            public const string UnDone = Base + "/tasks/Undone/{taskId}";

        }
    }
}
