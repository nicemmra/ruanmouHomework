using HomeworkOne.Framework;
using HomeworkOne.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.Factory
{
    /// <summary>
    /// 创建实体的简单工厂
    /// </summary>
    public class SimpleFactory
    {
        //public static string IBaseDALConfig = ConfigurationManager.AppSettings["IBaseDAL"];
        private static string DllName = StaticConstraint.IBaseDALConfig.Split(',')[1];
        private static string TypeName = StaticConstraint.IBaseDALConfig.Split(',')[0];
        /// <summary>
        /// 根据配置文件创建一个IBaseDAL的子类
        /// </summary>
        /// <returns></returns>
        public static IBaseDAL CreateInstance()
        {
            Assembly assembly = Assembly.Load(DllName);//此处报错，无法加载dll或其引用---应该引用HomeworkOne.DAL
            Type type = assembly.GetType(TypeName);
            return (IBaseDAL)Activator.CreateInstance(type);
        }
    }
}
