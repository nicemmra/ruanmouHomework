using HomeworkOne.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne.IDAL
{
    /// <summary>
    /// DAL层接口,泛型接口
    /// </summary>
    public interface IBaseDAL
    {
        T GetT<T>(int id) where T : BaseModel;

        List<T> GetTs<T>() where T : BaseModel;

        bool Add<T>(T t) where T : BaseModel;

        bool Update<T>(T t) where T : BaseModel;

        bool Delete<T>(T t) where T : BaseModel;
    }
}
