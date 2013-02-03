using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRMS.BusinessLogic.Manager
{
    interface IBaseManager<E> where E:class 
    {
        void Save(E model);
        void Delete(E model);
        void Delete(List<E> collection);
        List<E> FetchAll();
        E FetchById(int key);
    }
}
