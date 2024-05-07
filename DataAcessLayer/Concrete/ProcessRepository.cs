using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ProcessRepository : GenericRepository<Process , AppDbContext> , IProcessRepository
    {
    }
}
