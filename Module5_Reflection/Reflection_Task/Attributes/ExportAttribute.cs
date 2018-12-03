using System;

namespace Reflection_Task.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        public ExportAttribute(Type type)
        {
            Contractor = type;
        }

        public ExportAttribute()
        {
        }

        public Type Contractor { get; private set; }
    }
}
