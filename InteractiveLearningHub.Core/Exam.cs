using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Core
{
    public class Exam
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Course Course { get; set; }
        public IList<Question> Questions { get; set; }
    }
}
