using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core.Entities;

namespace Dapper.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
       

    }
}
