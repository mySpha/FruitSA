using FruitSA.Data.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSA.Data.Interface
{
    public interface IDataAccess
    {
        void CreateDatabase();
        ConnectionContext DbContext { get; }
    }
}
