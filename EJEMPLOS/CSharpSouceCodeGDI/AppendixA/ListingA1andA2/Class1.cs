using System;
using System.IO;

namespace ListingA1andA2
{
	class Class1
	{
		static void Main(string[] args)
		{
			try
			{
				File.Open("c:\\abc.txt", FileMode.Open);
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
			}			
		}
	}
}



