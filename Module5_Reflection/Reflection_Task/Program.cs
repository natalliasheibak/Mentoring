using Module5_Reflection;
using Reflection_Task.Interfaces;
using System;
using System.Reflection;

namespace Reflection_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var container1 = new Container();
            container1.AddType(typeof(CustomerBLL));
            container1.AddType(typeof(Logger));
            container1.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));

            var customerBLL1 = (CustomerBLL)container1.CreateInstance(typeof(CustomerBLL));

            if (customerBLL1 != null && customerBLL1.GetType().Equals(typeof(CustomerBLL)))
            {
                Console.WriteLine("First instance of CustomerBLL was created."); 
            }

            var container2 = new Container();
            container2.AddAssembly(Assembly.GetExecutingAssembly());

            var customerBLL2 = container2.CreateInstance<CustomerBLL>();

            if (customerBLL2 != null && customerBLL2.GetType().Equals(typeof(CustomerBLL)))
            {
                Console.WriteLine("Second instance of CustomerBLL was created."); 
            }

            Console.ReadKey();
        }
    }
}
