using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.Model
{
    /// <summary>
    /// 公司类，继承BaseModel
    /// </summary>
    public class Company : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { set; get; }
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
