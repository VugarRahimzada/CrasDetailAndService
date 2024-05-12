using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using EntityLayer.Models;
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
		private readonly IMapper _mapper;

		public FAQManager(IFAQRepository faqrepository, IMapper mapper)
		{
			_faqrepository = faqrepository;
			_mapper = mapper;
		}

		public IResult TAdd(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
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

		public IResult TUpdate(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
			_faqrepository.Update(faq);
			return new SuccessResult(UIMessage.UPDATE_SUCCESS);
		}

		public IDataResult<List<FAQDTOs>> TGetActiv()
		{
			var faq = _faqrepository.GetActiv();
			var faqdtos = _mapper.Map<List<FAQDTOs>>(faq);

			return new SuccessDataResult<List<FAQDTOs>>(faqdtos);
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
