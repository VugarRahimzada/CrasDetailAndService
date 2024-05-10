using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
	public interface IFAQService 
	{
		IDataResult<List<FAQDTOs>> TGetAll();
        IDataResult<List<FAQDTOs>> TGetActiv();
        IDataResult<FAQDTOs> TGetById(int id);
		IResult TAdd(FAQDTOs entity);
        IResult TUpdate(FAQDTOs entity);
        IResult TDelete(FAQDTOs entity);
        IResult THardDelete(FAQDTOs entity);
	}
}
