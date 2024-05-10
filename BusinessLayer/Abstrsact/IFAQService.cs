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
		DataResult<List<FAQDTOs>> TGetAll();
		DataResult<List<FAQDTOs>> TGetActiv();
		DataResult<FAQDTOs> TGetById(int id);
		Result TAdd(FAQDTOs entity);
		Result TUpdate(FAQDTOs entity);
		Result TDelete(FAQDTOs entity);
		Result THardDelete(FAQDTOs entity);
	}
}
