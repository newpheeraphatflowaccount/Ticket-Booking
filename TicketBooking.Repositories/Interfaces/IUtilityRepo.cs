﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TicketBooking.Repositories.Interfaces
{
	public interface IUtilityRepo
	{
		Task<string> SaveImagePath(string DirName, IFormFile file);
		Task<string> EditFilePath(string DirName, IFormFile file, string fullPath);
		Task DeleteFile(string filePath, string DirName);
	}
}
