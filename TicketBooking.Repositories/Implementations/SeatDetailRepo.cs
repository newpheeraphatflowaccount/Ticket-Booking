using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Entities;
using TicketBooking.Repositories.Interfaces;

namespace TicketBooking.Repositories.Implementations
{
	public class SeatDetailRepo : ISeatDetailRepo
	{
		private readonly ApplicationDbContext _context;

		public SeatDetailRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Delete(BusSeatDetail seatDetail)
		{
			_context.SeatDetails.Remove(seatDetail);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<BusSeatDetail>> GetAll()
		{
			return await _context.SeatDetails.ToListAsync();	
		}

		public async Task<BusSeatDetail> GetById(int id)
		{
			return await _context.SeatDetails.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task Insert(BusSeatDetail seatDetail)
		{
			await _context.SeatDetails.AddAsync(seatDetail);
			await _context.SaveChangesAsync();
		}

		public async Task Update(BusSeatDetail seatDetail)
		{
			throw new NotImplementedException();
		}
	}
}
