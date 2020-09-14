using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Core
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string IdentityUserId { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public IList<Course> Course { get; set; }
    }
}
