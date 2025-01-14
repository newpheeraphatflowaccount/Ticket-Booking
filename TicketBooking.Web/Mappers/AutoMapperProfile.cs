using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TicketBooking.Entities;
using TicketBooking.Web.ViewModels.BusVM;

namespace TicketBooking.Web.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Bus, BusViewModel>();
			CreateMap<CreateBusViewModel, Bus>()
				.ForMember(dest => dest.BusImage, opt => opt.Ignore());
			CreateMap<Bus, EditBusViewModel>()
				.ForMember(dest => dest.BusImageFile, opt => opt.Ignore());
			CreateMap<EditBusViewModel, Bus>()
				.ForMember(dest => dest.BusImage, opt => opt.Ignore());
		}
	}
}
