using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<T> where T: class
    {
        ApplicationContext db = new ApplicationContext();
        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            DbSet = db.Set<T>();
        }

        public void insert(T t)
        {
            DbSet.Add(t);
            db.SaveChanges();
        }

        public T get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> getAll()
        {
            return DbSet.ToList();
        }

        public void update(T t)
        {
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void remove(int id)
        {
            var t = get(id);
            DbSet.Remove(t);
            db.SaveChanges();
        }
    }
}
