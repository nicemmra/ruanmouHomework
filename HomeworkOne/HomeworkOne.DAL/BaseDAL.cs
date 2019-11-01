using HomeworkOne.IDAL;
using HomeworkOne.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.DAL
{
    /// <summary>
    /// DAL实现类
    /// </summary>
    public class BaseDAL : IBaseDAL
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string ConnectionString = @"Data Source=LAPTOP-5E161SII\SQLEXPRESS;Initial Catalog=RuanMouHomeworkOne;Persist Security Info=True;User ID=lyc;Password=123456";//ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add<T>(T t) where T : BaseModel
        {
            Type type = t.GetType();
            //插入不能插入id，id是自增属性；id在父类中
            //string columnStr = string.Join(",", type.GetProperties().Where(p=>!p.Name.Equals("Id")).Select(p => $"[{p.Name}]"));
            string columnStr = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
                .Select(p => $"[{p.Name}]"));
            //sqlserver任意值可以加单引号;但是会报错（it's）;容易被注入
            //参数化
            string valueColumn = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => $"@{p.Name}"));
            var parameterList = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new SqlParameter($"@{p.Name}", p.GetValue(t) == null ? DBNull.Value : p.GetValue(t)));//注意可空类型

            string sql = $"insert [{type.Name}] ({columnStr}) values ({valueColumn})";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                command.Parameters.AddRange(parameterList.ToArray());//添加参数数组
                return command.ExecuteNonQuery() == 1;
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Delete<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetT<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = $"select {string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"))} from [{type.Name}] where ID={id}";
            using (SqlConnection conn = new SqlConnection(ConnectionString))//新建连接对象
            {
                SqlCommand command = new SqlCommand(sql, conn);//新建执行命令的对象
                conn.Open();//打开连接
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    object oObject = Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oObject, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                    return (T)oObject;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetTs<T>() where T : BaseModel
        {
            Type type = typeof(T);
            string sql = SqlBuilder<T>.GetTsSql;    //$"select {string.Join(",", type.GetProperties().Select(p => $"{p.Name}"))} from [{type.Name}]";
            List<T> tlist = new List<T>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object oObject = Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oObject, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                    tlist.Add((T)oObject);
                }
                return tlist;
            }
        }
        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }
    }
}
