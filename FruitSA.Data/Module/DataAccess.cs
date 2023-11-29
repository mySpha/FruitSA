using FruitSA.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSA.Data.Module
{
    public class DataAccess : IDataAccess
    {
        public ConnectionContext DbContext  {
            get => new ConnectionContext();
        }

        public void CreateDatabase()
        {
            using(var context  = new ConnectionContext()) 
            { 
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
        }
    }
}
