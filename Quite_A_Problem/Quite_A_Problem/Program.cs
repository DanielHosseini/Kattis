using System;

namespace Quite_A_Problem
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			{
				string input;
				while ((input = Console.ReadLine()) != null) 
				{
					

						Console.WriteLine((input.ToLower().Contains("problem")) ? "yes" : "no");
					}
				}
			}
		}
	}
}