using ConsoleApp_P223.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_P223.Models
{
	class Hall
	{
		public static int count = 1;
		public string No { get; set; }
		public HallCategory Category { get; set; }
		public Seat[,] Seats { get; set; }

		public Hall(int row, int column, HallCategory category)
		{
			switch (category)
			{
				case HallCategory.SciFi:
					No = "SF" + "-" + count;
					break;
				case HallCategory.Thriller:
					No = "T" + "-" + count;
					break;
				case HallCategory.Drama:
					No = "D" + "-" + count;
					break;
				case HallCategory.Mystery:
					No = "M" + "-" + count;
					break;
				case HallCategory.Action:
					No = "A" + "-" + count;
					break;
				case HallCategory.Horror:
					No = "H" + "-" + count;
					break;
				default:
					break;
			}


			Category = category;

			Seats = new Seat[row, column];

			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					Seat seat = new Seat(i + 1, j + 1);
					Seats[i, j] = seat;
				}
			}
			count++;
		}

		public override string ToString()
		{
			return $"No: {No}, Category: {Category}";
		}
	}
}
