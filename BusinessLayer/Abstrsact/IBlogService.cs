using CoreLayer.Results.Abstract;
using DTOLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IBlogService
    {
        IDataResult<List<BlogDTOs>> TGetAll();
        IDataResult<List<BlogDTOs>> TGetActiv();
        IDataResult<BlogDTOs> TGetById(int id);
        IResult TAdd(BlogDTOs entity);
        IResult TUpdate(BlogDTOs entity);
        IResult TDelete(BlogDTOs entity);
        IResult THardDelete(BlogDTOs entity);
        IDataResult<BlogDTOs> TLastOrDefault();
        IDataResult<List<BlogDTOs>> TLastBlog();
    }
}
