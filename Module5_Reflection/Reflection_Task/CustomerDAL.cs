using Reflection_Task.Attributes;
using Reflection_Task.Interfaces;

namespace Module5_Reflection
{
    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL { }
}
