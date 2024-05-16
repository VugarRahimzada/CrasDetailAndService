using CoreLayer.Results.Abstract;
using DTOLayer.FAQDTO;

namespace BusinessLayer.Abstrsact
{
    public interface IFAQService 
	{
		IDataResult<List<FAQDTOs>> TGetAll();
        IDataResult<List<FAQActivDTOs>> TGetActiv();
        IDataResult<FAQDTOs> TGetById(int id);
		IResult TAdd(FAQCreateDTOs entity);
        IResult TUpdate(FAQDTOs entity);
        IResult TDelete(FAQDTOs entity);
        IResult THardDelete(FAQDTOs entity);
	}
}
