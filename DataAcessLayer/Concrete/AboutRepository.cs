using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DTOLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class AboutRepository : GenericRepository<About, AppDbContext>, IAboutRepository
    {
        //public AboutRepository(AppDbContext context) : base(context)
        //{
        //}
    }
}


