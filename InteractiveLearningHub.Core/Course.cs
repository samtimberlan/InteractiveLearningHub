using System;

namespace InteractiveLearningHub.Core
{
    public class Course
    {
        public Guid Id { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public ApplicationUser Author { get; set; }
    }
}