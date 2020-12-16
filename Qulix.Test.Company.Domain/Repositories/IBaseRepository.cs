using System;
using System.Collections.Generic;
using System.Text;

namespace Qulix.Test.Company.Domain.Repositories
{
   public interface IBaseRepository<T>
        where T : class
    {
        void Add(T item); // add item

        List<T> GetAll(); // get all items

        void Delete(int id); // delete item by id

        T Get(int id); // get item by id

        void Edit(T item); // edit item
    }
}
