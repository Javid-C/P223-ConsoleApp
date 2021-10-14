using ConsoleApp_P223.Enums;
using ConsoleApp_P223.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_P223.Interfaces
{
	interface ICinemaServices
	{
		public List<Hall> Halls { get;}

		string CreateHall(int row, int column, HallCategory category);

		void EditHall(string no, string newNo);

		void GetAllHalls();

		void GetAllSeats(string no);

		void Reserve(string no, int row, int column);

	}
}
