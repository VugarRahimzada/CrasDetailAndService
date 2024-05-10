using AutoMapper;
using BusinessLayer.Abstrsact;
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

		public Result TAdd(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
			_faqrepository.Add(faq);
			return new Result("Uğurla Əlavə Edildi", true);
		}

		public Result TDelete(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
			_faqrepository.Delete(faq);
			return new Result("Uğurla Silindi ", true);
		}

		public DataResult<List<FAQDTOs>> TGetActiv()
		{
			var faq = _faqrepository.GetActiv();
			var faqdtos = _mapper.Map<List<FAQDTOs>>(faq);

			return new DataResult<List<FAQDTOs>>(faqdtos, "Uğurlu", true);
		}

		public DataResult<List<FAQDTOs>> TGetAll()
		{
			var faq = _faqrepository.GetAll();
			var faqdtos = _mapper.Map<List<FAQDTOs>>(faq);

			return new DataResult<List<FAQDTOs>>(faqdtos, "Uğurlu", true);
		}

		public DataResult<FAQDTOs> TGetById(int id)
		{
			var faq = _faqrepository.GetById(id);
			var faqdtos = _mapper.Map<FAQDTOs>(faq);

			return new DataResult<FAQDTOs>(faqdtos, "Uğurlu", true);
		}

		public Result THardDelete(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
			_faqrepository.HardDelete(faq);
			return new Result("Uğurla DataBasadan Silindi", true);
		}

		public Result TUpdate(FAQDTOs entity)
		{
			var faq = _mapper.Map<FAQ>(entity);
			_faqrepository.Update(faq);
			return new Result("Uğurla Yenil'ndi", true);
		}
	}
}
