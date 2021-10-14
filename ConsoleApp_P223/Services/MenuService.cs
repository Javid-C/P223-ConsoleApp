using ConsoleApp_P223.Enums;
using ConsoleApp_P223.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_P223.Services
{
	static class MenuService
	{
		public static CinemaServices cinemaServices = new CinemaServices();

		public static void CreateHallMenu()
		{
			Console.WriteLine("Please enter row number");

			int row;
			string rowStr = Console.ReadLine();
			bool rowResult = int.TryParse(rowStr, out row);

			Console.WriteLine("Please enter column number");

			int col;
			string colStr = Console.ReadLine();
			bool colResult = int.TryParse(colStr, out col);

			if (rowResult && colResult)
			{
				Console.WriteLine("Please choose the category you want");

				foreach (var c in Enum.GetValues(typeof(HallCategory)))
				{
					Console.WriteLine($"{(int)c}. {c}");
				}

				int category;
				string categoryStr = Console.ReadLine();
				bool categoryResult = int.TryParse(categoryStr, out category);

				if (categoryResult)
				{
					switch (category)
					{
						case 1:
							string No = cinemaServices.CreateHall(row, col, HallCategory.SciFi);
							Console.WriteLine($"{No} hall succesfully created");
							break;
						case 2:
							No = cinemaServices.CreateHall(row, col, HallCategory.Thriller);
							Console.WriteLine($"{No} hall succesfully created");
							break;
						case 3:
							No = cinemaServices.CreateHall(row, col, HallCategory.Drama);
							Console.WriteLine($"{No} hall succesfully created");
							break;
						case 4:
							No = cinemaServices.CreateHall(row, col, HallCategory.Mystery);
							Console.WriteLine($"{No} hall succesfully created");
							break;
						case 5:
							No = cinemaServices.CreateHall(row, col, HallCategory.Action);
							Console.WriteLine($"{No} hall succesfully created");
							break;
						case 6:
							No = cinemaServices.CreateHall(row, col, HallCategory.Horror);
							Console.WriteLine($"{No} hall succesfully created");
							break;
						default:
							break;
					}
				}
			}
		}

		public static void EditHallMenu()
		{
			Console.WriteLine("Please enter valid hall No");

			string hallNo = Console.ReadLine();

			Console.WriteLine("Please enter valid new hall No");

			string newHallNo = Console.ReadLine();

			cinemaServices.EditHall(hallNo,newHallNo);
		}
		public static void GetHallsMenu()
		{
			cinemaServices.GetAllHalls();
		}

		public static void GetSeatsMenu()
		{
			Console.WriteLine("Please enter hall No");

			string hallNo = Console.ReadLine();

			cinemaServices.GetAllSeats(hallNo);
		}

		public static void ReserveMenu()
		{
			cinemaServices.GetAllHalls();
			if(cinemaServices.Halls.Count != 0)
			{
				Console.WriteLine("Please choose the hall No");

				string hall = Console.ReadLine();

				Console.WriteLine("Please choose the row");

				int row;

				string rowStr = Console.ReadLine();

				bool resultRow = int.TryParse(rowStr, out row);

				Console.WriteLine("Please choose the col");

				int col;

				string colStr = Console.ReadLine();

				bool resultCol = int.TryParse(colStr, out col);
				if(resultCol && resultRow)
				{
					cinemaServices.Reserve(hall, row, col);
				}
			}
		}
	}
}
