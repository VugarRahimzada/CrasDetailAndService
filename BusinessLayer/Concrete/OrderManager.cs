using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using BusinessLayer.Validation.FluentValidations;
using ClosedXML.Excel;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderManager(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IDataResult<OrderDTOs> FirstOrDefault(string licenseplate)
        {
           
            var orderplate = _orderRepository.FirstOrDefault(x => x.LicensePlate == licenseplate && x.Delete==0);
            var orderplatedto = _mapper.Map<OrderDTOs>(orderplate);

            return new SuccessDataResult<OrderDTOs>(orderplatedto);
        }

        public IResult TAdd(OrderDTOs entity)
        {
            var validation = new OrderValidation();
            var validationresult = validation.Validate(entity);
            if (!validationresult.IsValid)
            {
                throw new Exception();
            }
            var order = _mapper.Map<Order>(entity);
            _orderRepository.Add(order);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(OrderDTOs entity)
        {
            var order = _mapper.Map<Order>(entity);
            _orderRepository.Delete(order);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IDataResult<List<OrderDTOs>> TGetActiv()
        {
            var value = _orderRepository.CheckOrderDeadline(x => x.Deadline < DateTime.Now && x.Delete == 0);
            var order = _orderRepository.GetActiv();

            var oderderdto = _mapper.Map<List<OrderDTOs>>(order);
            return new SuccessDataResult<List<OrderDTOs>>(oderderdto);

        }

        public IDataResult<List<OrderDTOs>> TGetAll()
        {

       
            var value = _orderRepository.CheckOrderDeadline(x=>x.Deadline<DateTime.Now && x.Delete == 0);
            var order = _orderRepository.GetAll();

            var oderderdto = _mapper.Map<List<OrderDTOs>>(order);
            return new SuccessDataResult<List<OrderDTOs>>(oderderdto);
        }

        public IDataResult<OrderDTOs> TGetById(int id)
        {
            var order = _orderRepository.GetById(id);

            var oderderdto = _mapper.Map<OrderDTOs>(order);
            return new SuccessDataResult<OrderDTOs>(oderderdto);
        }

        public IResult THardDelete(OrderDTOs entity)
        {
            var order = _mapper.Map<Order>(entity);
            _orderRepository.HardDelete(order);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(OrderDTOs entity)
        {
            var order = _mapper.Map<Order>(entity);
            _orderRepository.Update(order);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }

        public IDataResult<MemoryStream> ExportExelOrder()
        {

            var value = _orderRepository.GetActiv();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Order List");
                worksheet.Cell(1, 1).Value = "Ad Soyad";
                worksheet.Cell(1, 2).Value = "Email";
                worksheet.Cell(1, 3).Value = "Qeydiyyat Nişanı";
                worksheet.Cell(1, 4).Value = "Paketi";
                worksheet.Cell(1, 5).Value = "Bitiş Tarixi";

                int OrderRowCounta = 2;
                foreach (var item in value)
                {
                    worksheet.Cell(OrderRowCounta, 1).Value = item.Name + " " + item.Surname;
                    worksheet.Cell(OrderRowCounta, 2).Value = item.Email;
                    worksheet.Cell(OrderRowCounta, 3).Value = item.LicensePlate;
                    worksheet.Cell(OrderRowCounta, 4).Value = item.PricingId;
                    worksheet.Cell(OrderRowCounta, 5).Value = item.Deadline.ToString("dd/MM/yyyy");
                    OrderRowCounta++;
                }
                var stream = new MemoryStream();


                workbook.SaveAs(stream);
                stream.Position = 0;
                return new SuccessDataResult<MemoryStream>(stream);
            }
        }
    }
}
