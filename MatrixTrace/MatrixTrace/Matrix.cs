using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixTrace
{
	public class Matrix
	{
		private int Rows { get; set; }
		private int Columns { get; set; }
		public int MaxValueElement { get; private set; }
		public int[,] MatrixElements { get; private set; }
		public int[] MainDiagonal { get; private set; }

		public Matrix(int rows, int columns, int startRandomRange = 0, int finishRandomRange = 100)
		{
			Rows = rows;
			Columns = columns;
			int indexMainDiagonal = 0;
			MainDiagonal = new int[Rows];

			MatrixElements = new int[rows, columns];
			MaxValueElement = Int32.MinValue;

			for (int row = 0; row < rows; row++)
			{
				for (int column = 0; column < columns; column++)
				{
					MatrixElements[row, column] = new Random().Next(startRandomRange, finishRandomRange);
					MaxValueElement = MatrixElements[row, column] > MaxValueElement ? MatrixElements[row, column] : MaxValueElement;
					MainDiagonal[indexMainDiagonal] = row == column ? MatrixElements[row, column] : MainDiagonal[indexMainDiagonal];
				}
				
				indexMainDiagonal++;
			}
		}


		public string PrintMatrix()
		{
			string newLine = Environment.NewLine; 
			int maxLength = MaxValueElement.ToString().Length + 1;
			StringBuilder matrixStr = new StringBuilder();

			for (int row = 0; row < Rows; row++)
			{
				for (int column = 0; column < Columns; column++)
				{
					string elementStr = new string(' ', maxLength - MatrixElements[row, column].ToString().Length) + MatrixElements[row, column];
					matrixStr.Append(elementStr);

					if (column + 1 == Columns)
					{
						matrixStr.Append(newLine);
						elementStr += newLine;
					}

					bool isElementMainDiagonal = row == column;
					Console.ForegroundColor = isElementMainDiagonal ? ConsoleColor.Green : ConsoleColor.White;

					Console.Write(elementStr);
					Console.ForegroundColor = ConsoleColor.White;
				}
			}

			return matrixStr.ToString();
		}


		public int GetMatrixTrace()
		{
			int sum = MainDiagonal != null ?  MainDiagonal.Sum() : 0; 
			return sum;
		}
	}
}
