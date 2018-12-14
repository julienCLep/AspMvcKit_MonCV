using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Skillz.Db
{
    public class Repository<T> : IRepository<T> where T : class, IModel
    {
        public DbSet<T> Table { get; set; }

        public Repository(DbContext db)
        {
            Table = db.Set<T>();
        }
        public bool Delete(int id)
        {
            T dbItem = Find(id);
            if (dbItem != null)
            {
                Table.Remove(dbItem);
                return true;
            }
            return false;
        }

        public T Find(int id)
        {
            //foreach (T item in Table)
            //{
            //    if (item.Id == id)
            //    {
            //        return item;
            //    }
            //} return null;
            
            // a la place du foreach
            return Table.FirstOrDefault(item => item.Id == id);
        }

        public virtual List<T> FindAll()
        {
            return Table.ToList();
        }

        public virtual bool Insert(T item)
        {
            if (Find(item.Id)== null)
            {
                Table.Add(item);
                return true;
            }
            return false;
        }

        public virtual bool Update(T item)
        {
            T dbItem = Find(item.Id);
            if (dbItem != null)
            {
                dbItem.UpdateFrom(item);
                return true;
            }
            return false;
        }

        public virtual bool Delete(T item)
        {
            T dbItem = Find(item.Id);
            if (dbItem != null)
            {
                Table.Remove(item);
                return true;
            }
            return false;
        }
    }
}