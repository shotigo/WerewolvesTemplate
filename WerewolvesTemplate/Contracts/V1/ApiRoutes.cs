﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TropicalTrooperTemplate.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class Posts
        {
            public const string AuditLog = Base + "/" + "auditLog";

            public const string GetAll = Base + "/" + "_posts";
            public const string Get = Base + "/" + "posts/{postId}";
            public const string Create = Base + "/" + "posts";
        }
    }
}
