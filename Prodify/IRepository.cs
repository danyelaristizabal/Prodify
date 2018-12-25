using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodify
{
    interface IRepository<IUser>
    {
        bool Add(IUser user);
        bool Delete(IUser entity);
        void Update(IUser entity);
        bool FindById(IUser Id); 
    }
}
