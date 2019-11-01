using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.Framework
{
    public static class ConsoleExtend
    {
        /// <summary>
        /// 泛型扩展方法，将一个实体打印到控制台
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Show<T>(this T t)
        {
            Type type = t.GetType();
            Console.WriteLine($"*****************--START--{type.Name}--SHOW--***************");
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine($"{type.Name}.{prop.Name}={prop.GetValue(t)}");
            }
            Console.WriteLine($"*****************--START--{type.Name}--SHOW--***************");
        }
    }
}
