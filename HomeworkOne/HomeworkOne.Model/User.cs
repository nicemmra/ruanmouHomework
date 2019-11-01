using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.Model
{
    /// <summary>
    /// 用户类，继承BaseModel
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Account { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? CompanyId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { set; get; }
        /// <summary>
        /// 用户状态  0正常 1冻结 2删除
        /// </summary>
        public int State { set; get; }
        /// <summary>
        /// 用户类型  1 普通用户 2管理员 4超级管理员
        /// </summary>
        public int UserType { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginTime { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int CreatorId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? LastModifierId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModifyTime { set; get; }
    }
}
