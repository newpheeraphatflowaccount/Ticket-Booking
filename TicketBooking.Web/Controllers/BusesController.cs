using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Entities;
using TicketBooking.Repositories.Interfaces;
using TicketBooking.Web.ViewModels.BusVM;

namespace TicketBooking.Web.Controllers
{
	public class BusesController : Controller
	{
		private readonly IBusRepo _busRepo;
		private readonly IMapper _mapper;
		private readonly IUtilityRepo _utilityRepo;
		private string BusImage = "BusImage";

		public BusesController(IBusRepo busRepo, IMapper mapper, IUtilityRepo utilityRepo)
		{
			_busRepo = busRepo;
			_mapper = mapper;
			_utilityRepo = utilityRepo;
		}

		public async Task<IActionResult> Index()
		{
			var buses = await _busRepo.GetAll();
			var vm = _mapper.Map<List<BusViewModel>>(buses);
			return View(vm);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateBusViewModel vm)
		{
			var model = _mapper.Map<Bus>(vm);
			if (vm.BusImage != null)
			{
				model.BusImage = await _utilityRepo.SaveImagePath(BusImage, vm.BusImage);
			}
			await _busRepo.Insert(model);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var busDetail = await _busRepo.GetById(id);
			var vm = _mapper.Map<EditBusViewModel>(busDetail);
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditBusViewModel vm)
		{
			var bus = await _busRepo.GetById(vm.Id);
			if (vm.BusImageFile != null)
			{
				bus.BusImage = await _utilityRepo.EditFilePath(BusImage, vm.BusImageFile, bus.BusImage);
			}
			bus = _mapper.Map(vm, bus);
			await _busRepo.Update(bus);
			return RedirectToAction("Index");
		}
	}
}
