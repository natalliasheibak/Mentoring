using Reflection_Task.Attributes;
using Reflection_Task.Interfaces;

namespace Module5_Reflection
{
    [ImportConstructor]
    public class CustomerBLL
    {
        public CustomerBLL(ICustomerDAL dal, Logger logger) { }

        [Import]
        public ICustomerDAL CustomerDAL { get; set; }

        [Import]
        public Logger logger { get; set; } 
    }
}
