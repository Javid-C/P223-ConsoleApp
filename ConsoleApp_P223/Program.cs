using ConsoleApp_P223.Enums;
using ConsoleApp_P223.Services;
using System;

namespace ConsoleApp_P223
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("*************************");
			Console.WriteLine("Welcome to Cinema Application");
			Console.WriteLine();

			int selection;
			do
			{
				Console.WriteLine("1. Create Hall");
				Console.WriteLine("2. Edit Hall");
				Console.WriteLine("3. Get All Halls");
				Console.WriteLine("4. Get All Seats");
				Console.WriteLine("5. Reserve");
				Console.WriteLine("0. Exit");


				string selectStr = Console.ReadLine();

				bool result = int.TryParse(selectStr, out selection);

				if (result)
				{
					switch (selection)
					{
						case 1:
							MenuService.CreateHallMenu();
							break;
						case 2:
							MenuService.EditHallMenu();
							break;
						case 3:
							MenuService.GetHallsMenu();
							break;
						case 4:
							MenuService.GetSeatsMenu();
							break;
						case 5:
							MenuService.ReserveMenu();
							break;
						default:
							break;
					}
				}
			} while (selection !=0);
		}
	}
}
