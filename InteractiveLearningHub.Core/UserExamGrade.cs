using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Core
{
    public class UserExamGrade
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public string Grade { get; set; }
        public Guid ApplicationUserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
