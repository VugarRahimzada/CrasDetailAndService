using CoreLayer.Results.Abstract;
using DTOLayer.FAQDTO;
using FluentValidation.Results;

namespace BusinessLayer.Abstrsact
{
    public interface IFAQService 
	{
		IDataResult<List<FAQDTOs>> TGetAll();
        IDataResult<List<FAQActivDTOs>> TGetActiv();
        IDataResult<FAQDTOs> TGetById(int id);
		IResult TAdd(FAQCreateDTOs entity, out List<ValidationFailure> errors);
        IResult TUpdate(FAQUpdateDTOs entity, out List<ValidationFailure> errors);
        IResult TDelete(FAQDTOs entity);
        IResult THardDelete(FAQDTOs entity);
	}
}
