using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Core
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public Guid IdentityUserId { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
