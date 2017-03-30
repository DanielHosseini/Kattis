using System;

namespace Int_To_Binary_Reverse
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var number = Console.ReadLine();
			var num = Convert.ToInt32(number);
			string binary = Convert.ToString(num, 2);
			Console.WriteLine(Convert.ToInt32(ReverseString(binary),2));
		}
		public static string ReverseString(string s)
		{
			char[] arr = s.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
		}
	}
}
