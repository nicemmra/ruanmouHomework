using HomeworkOne.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.DAL
{
    /// <summary>
    /// 缓存固定Sql语句
    /// </summary>
    public class SqlBuilder<T> where T : BaseModel
    {
        /// <summary>
        /// 查询单个实体的sql语句
        /// </summary>
        public static string GetTSql = null;
        /// <summary>
        /// 查询所有实体的sql语句
        /// </summary>
        public static string GetTsSql = null;
        /// <summary>
        /// 增加一个实体的sql语句
        /// </summary>
        public static string AddSql = null;

        static SqlBuilder()
        {
            Type type = typeof(T);

            GetTSql = $"select {string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"))} from [{type.Name}] where ID=@Id";

            GetTsSql = $"select {string.Join(",", type.GetProperties().Select(p => $"{p.Name}"))} from [{type.Name}]";

            string columnStr = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => $"[{p.Name}]"));
            string valueColumn = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => $"@{p.Name}"));
            AddSql = $"insert [{type.Name}] ({columnStr}) values ({valueColumn})";
        }
    }
}
