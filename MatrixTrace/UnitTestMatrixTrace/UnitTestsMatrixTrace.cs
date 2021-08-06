using MatrixTrace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixTrace.Tests
{
	[TestClass()]
	public class UnitTestsMatrixTrace
	{
		[TestMethod()]
		public void PrintMatrixTest()
		{
			Matrix M = new Matrix(1, 1);
			string actual = M.PrintMatrix();
			string expected = $" {M.MaxValueElement}\r\n";

			Assert.AreEqual(expected: expected, actual: actual);
		}



		[TestMethod()]
		public void GetMatrixTraceTest()
		{
			Matrix M = new Matrix(3, 3);
			int actual = M.GetMatrixTrace();
			int expected = M.MatrixElements[0,0] + M.MatrixElements[1, 1] + M.MatrixElements[2, 2];

			Assert.AreEqual(expected: expected, actual: actual);
		}
	}
}


