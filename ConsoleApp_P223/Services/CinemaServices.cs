using ConsoleApp_P223.Enums;
using ConsoleApp_P223.Interfaces;
using ConsoleApp_P223.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_P223.Services
{
	class CinemaServices : ICinemaServices
	{
		private List<Hall> _halls = new List<Hall>();
		public List<Hall> Halls => _halls;

		//Diger variant
		//public List<Hall> Halls
		//{
		//	get
		//	{
		//		return _halls;
		//	}
		//}

		public string CreateHall(int row, int column, HallCategory category)
		{
			if(row<=0 || column <= 0)
			{
				return "Please enter valid row or column number";
			}

			Hall hall = new Hall(row,column,category);

			_halls.Add(hall);

			return hall.No;
		}

		public void EditHall(string no,string newNo)
		{
			Hall existedHall = FindHall(no);
			
			if(existedHall == null)
			{
				Console.WriteLine($"{no} hall does not exist");
				return;
			}
			foreach (Hall hall in _halls)
			{
				if(hall.No.ToLower().Trim() == newNo.ToLower().Trim())
				{
					Console.WriteLine($"{newNo} hall already existed");
					return;
				}
			}
			existedHall.No = newNo.ToUpper();

			Console.WriteLine($"{no.ToUpper()} succesfully updated to {newNo.ToUpper()}");
		}

		public Hall FindHall(string no)
		{
			foreach (Hall hall in _halls)
			{
				if (hall.No.ToLower().Trim() == no.ToLower().Trim())
				{
					return hall;
				}
			}
			return null;
		}

		public void GetAllHalls()
		{
			if(_halls.Count == 0)
			{
				Console.WriteLine("There is no hall");
				return;
			}
			foreach (Hall hall in _halls)
			{
				Console.WriteLine(hall);
			}
		}

		public void GetAllSeats(string no)
		{
			Hall hall = _halls.Find(h => h.No.ToLower().Trim() == no.ToLower().Trim());
			if(hall == null)
			{
				Console.WriteLine($"{no} hall does not exist");
				return;
			}
			foreach (Seat seat in hall.Seats)
			{
				Console.WriteLine(seat);
			}
		}

		public void Reserve(string no, int row,int column)
		{
			if (string.IsNullOrEmpty(no))
			{
				Console.WriteLine("Please enter valid hall No");
				return;
			}
			if(row<=0 || column <= 0)
			{
				Console.WriteLine("Please enter valid row or column number");
				return;
			}
			Hall hall = _halls.Find(h => h.No.ToLower().Trim() == no.ToLower().Trim());

			if(hall == null)
			{
				Console.WriteLine("There is no hall you searched");
				return;
			}
			if(row>hall.Seats.GetLength(0) || column > hall.Seats.GetLength(1))
			{
				Console.WriteLine("Please enter valid row or column");
				return;
			}

			if (!hall.Seats[row - 1, column - 1].IsFull)
			{
				hall.Seats[row - 1, column - 1].IsFull = true;
				Console.WriteLine($"You succesfully reserved");
			}
			else
			{
				Console.WriteLine("This seat already reserved please choose another seat");
				Console.WriteLine();
				GetAllSeats(no);
			}

		}
	}
}
