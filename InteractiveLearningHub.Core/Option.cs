using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveLearningHub.Core
{
    public class Option
    {
        public enum OptionDescriptor
        {
            A,
            B,
            C,
            D
        }
        public Guid Id { get; set; }
        public OptionDescriptor OptionDescriptorTag { get; set; }
        public string OptionContent { get; set; }
    }
}
