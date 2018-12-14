using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillz.Db
{
    interface IRepository<T> where T : IModel
    {
        T Find(int id);
        List<T> FindAll();
        bool Insert(T item);
        bool Update(T item);
        bool Delete(int id);

    }
}

