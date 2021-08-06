using System;
using System.Collections.Generic;

namespace MatrixTrace
{
	class Program
	{
		static void Main(string[] args)
		{
			int rows = 0;
			int columns = 0;
			string newLine = Environment.NewLine; 
			bool quitFlag = false;
			do
			{
				if (!quitFlag)
				{
					Console.Write($@"{newLine}Matrix trace{newLine}Ener number rows in martrix: ");
					var enteredRows = Console.ReadLine();
					
					Console.Write($@"Ener number columns in martrix: ");
					var enteredColumns = Console.ReadLine();
					Console.WriteLine();
					
					Int32.TryParse(enteredRows, out rows);
					Int32.TryParse(enteredColumns, out columns);

					if (rows <= 0 || columns <= 0)
					{
						Console.WriteLine("You entered invalid data! It has to positive integers value.");
					}
					else 
					{
						Matrix M = new Matrix(rows: rows, columns: columns);
						M.PrintMatrix();
						var Sum = M.GetMatrixTrace();

						Console.Write($@"{newLine}Sum of Elements Of Main Diagonal: ");
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine($"{Sum}{newLine}");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
				}

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Quit - press 'q' or 'Q'{newLine}Continue - press any key");
				Console.ForegroundColor = ConsoleColor.Gray;
				char charQuit = Console.ReadKey().KeyChar;

				quitFlag = new List<char>() { 'q', 'Q' }.Contains(charQuit);
			}
			while (!quitFlag);
		}
	}
}
