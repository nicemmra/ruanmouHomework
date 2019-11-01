using HomeworkOne.Factory;
using HomeworkOne.Framework;
using HomeworkOne.IDAL;
using HomeworkOne.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.APP
{
    class Program
    {
        static void Main(string[] args)
        {
            IBaseDAL dAL = SimpleFactory.CreateInstance();
            dAL.GetT<Company>(1).Show();

            dAL.GetT<User>(1).Show();
            Console.Read();
        }
    }
}
