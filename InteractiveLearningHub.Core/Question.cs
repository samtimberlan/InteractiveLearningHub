using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Core
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public IList<Option> QuestionOptions { get; set; }
        public Option Answer { get; set; }
    }
}
