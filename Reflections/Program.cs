using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Get the Current Executing Assembly
            /// System.Reflections
            ///
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.GetType());

            ///
            /// Get all the Types of assembly
            /// to get the individual type
            /// use GetType()
            ///

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                //Console.WriteLine(type.Name);
                //Console.WriteLine(type.Namespace);
                //Console.WriteLine(type.Module);
                //Console.WriteLine(type.MemberType);
                //Console.WriteLine(type.FullName);
                //Console.WriteLine(type.Attributes);
                //Console.WriteLine(type.BaseType);
                //Console.WriteLine(type.Assembly);

                Console.WriteLine("Type : " + type.Name);

                ///
                /// Working With Methods
                /// 

                var methods = type.GetMethods();
                var methodsLength = methods.Length;

                for (int i = 0; i < methodsLength; i++)
                {
                    Console.WriteLine("Method : " + methods[i].Name);
                    Console.WriteLine("Method : " + methods[i].ReturnType);
                }

                ///
                /// Working With Properties
                ///

                var properties = type.GetProperties();
                foreach (var prop in  properties)
                {
                    Console.WriteLine("Properties : " + prop.Name);
                    Console.WriteLine("Properties : " + prop.PropertyType);
                    Console.WriteLine("Properties : " + prop.DeclaringType);
                }


                ///
                /// Working With Fields
                ///

                var fields = type.GetFields();
                foreach (var prop in fields)
                {
                    Console.WriteLine("Properties : " + prop.Name);
                    Console.WriteLine("Properties : " + prop.FieldType);
                    Console.WriteLine("Properties : " + prop.DeclaringType);
                }


                var sample = new Sample { Name = "Md. Alamin Mahamud", Age = 21 };
                var typeofSample = typeof(Sample);

                var nameProperty = typeofSample.GetProperty("Name");
                Console.WriteLine("Name : "+ nameProperty.GetValue(sample));

                var ageField = typeofSample.GetField("Age");
                Console.WriteLine("Age : " + ageField.GetValue(sample));

                var mycustomMethod = typeofSample.GetMethod("MyMethod");
                mycustomMethod.Invoke(sample,null);
            }
        }
    }


    public class Sample
    {
        /// <summary>
        ///  Field
        /// </summary>
        public int Age;

        /// <summary>
        /// Property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Method
        /// </summary>
        public void MyMethod()
        {
            Console.WriteLine("Hello From MyMethod");
        }
    }
}
