using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWorkingWithData_2.Models;

namespace MVCWorkingWithData_2.Tests.Fakes
{
    class FakeMVCWorkingWithDataDB : IMVCWorkingWithData_2
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public void AddSet<T>(IQueryable<T> objects)
        {
            Sets.Add(typeof(T), objects);
        }

        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();

    }
}
