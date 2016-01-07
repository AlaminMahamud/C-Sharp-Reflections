using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections_With_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t=>t.GetCustomAttributes<MyCustomClassAttribute>().Count()>0);

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
                var methods = type.GetMethods().Where(m=>m.GetCustomAttributes<MyCustomMethodAttribute>().Count()>0);
                foreach (var method in methods)
                {
                    Console.WriteLine(method.Name);
                    method.Invoke(new Sample(), null);
                }
            }
        }

    }
    [MyCustomClass]
    public class Sample
    {
        public int Age;
        public string Name { get; set; }

        [MyCustomMethod]
        public void MyMethod()
        {
            Console.WriteLine("Hello World!");
        }

        public void NoAttributeMethod() { }

    }

    /// Creating an Attribute
    /// AttributeUsage are used for targeting the desired types

    [AttributeUsage(AttributeTargets.Class)]
    public class MyCustomClassAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method)]
    public class MyCustomMethodAttribute : Attribute { }
}
