﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Entities;
using TicketBooking.Repositories.Interfaces;

namespace TicketBooking.Repositories.Implementations
{
	public class BusRepo : IBusRepo
	{
		private readonly ApplicationDbContext _context;

		public BusRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Insert(Bus bus)
		{
			await _context.BusInfo.AddAsync(bus);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Bus bus)
		{
			_context.BusInfo.Remove(bus);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Bus>> GetAll()
		{
			return await _context.BusInfo.ToListAsync();
		}

		public async Task<Bus> GetById(int id)
		{
			return await _context.BusInfo.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task Update(Bus bus)
		{
			await _context.SaveChangesAsync();
		}
	}
}
