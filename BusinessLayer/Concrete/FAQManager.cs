using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using DTOLayer.FAQDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class FAQManager : IFAQService
	{
		private readonly IFAQRepository _faqrepository;
		private readonly IValidator<FAQ> _validator;
		private readonly IMapper _mapper;

        public FAQManager(IFAQRepository faqrepository, IMapper mapper, IValidator<FAQ> validator)
        {
            _faqrepository = faqrepository;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult TAdd(FAQCreateDTOs entity, out List<ValidationFailure> errors)
		{
			var faq = _mapper.Map<FAQ>(entity);
            var validationResult = _validator.Validate(faq);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _faqrepository.Add(faq);
			return new SuccessResult(UIMessage.ADD_SUCCESS);
		}

		public IResult TDelete(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
			_faqrepository.Delete(faq);
			return new SuccessResult(UIMessage.DELETE_SUCCESS);
		}
		public IResult THardDelete(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
			_faqrepository.HardDelete(faq);
			return new SuccessResult(UIMessage.DELETE_SUCCESS);
		}

		public IResult TUpdate(FAQDTOs entity, out List<ValidationFailure> errors)
		{
			var faq = _mapper.Map<FAQ>(entity);
            var validationResult = _validator.Validate(faq);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _faqrepository.Update(faq);
			return new SuccessResult(UIMessage.UPDATE_SUCCESS);
		}

		public IDataResult<List<FAQActivDTOs>> TGetActiv()
		{
			var faq = _faqrepository.GetActiv();
			var faqdtos = _mapper.Map<List<FAQActivDTOs>>(faq);

			return new SuccessDataResult<List<FAQActivDTOs>>(faqdtos);
		}

		public IDataResult<List<FAQDTOs>> TGetAll()
		{
			var faq = _faqrepository.GetAll();
			var faqdtos = _mapper.Map<List<FAQDTOs>>(faq);

			return new SuccessDataResult<List<FAQDTOs>>(faqdtos);
		}

		public IDataResult<FAQDTOs> TGetById(int id)
		{
			var faq = _faqrepository.GetById(id);
			var faqdtos = _mapper.Map<FAQDTOs>(faq);

			return new SuccessDataResult<FAQDTOs>(faqdtos);
		}

	}
}
