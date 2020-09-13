using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Core
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public Course Course { get; set; }
        public ApplicationUser CertificateOwner { get; set; }
    }
}
