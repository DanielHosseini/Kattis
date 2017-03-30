using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Winning_Streak_3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			for (int i = 0; i < 5; i++)
			{
				
				var games = Console.ReadLine();
				var probability = Console.ReadLine();
				int numberOfMatches = Convert.ToInt32(games);
				double winProb = Convert.ToDouble(probability);
				if (string.IsNullOrEmpty(numberOfMatches.ToString()) || string.IsNullOrEmpty(winProb.ToString()))
				{
					break;
				}
				//int numberOfGames = Convert.ToInt32(numberOfMatches);
				//double winProb = Convert.ToDouble(winProbability);
				double result = Calculate(numberOfMatches, winProb);
				Console.WriteLine(result.ToString("0.0##"));			
			}

			//Console.WriteLine("Please enter number of consecutive matches");
			//int numberOfMatches = Convert.ToInt32(Console.ReadLine());
			//Console.WriteLine("Please enter win probability");
			//double winProb = Convert.ToDouble(Console.ReadLine());

		}


		public static double Calculate(int numberOfMatches, double winProbability)
		{
			List<string> matches = new List<string>();

			Permutations("", numberOfMatches, matches);

			List<double> probabilities = calculateProbability(matches, winProbability);
			List<int> streaks = calculateLongestWinStreak(matches);
			double result = calculateResult(probabilities, streaks);
			return result;
		}
		public static void Permutations(string text, int numberOfGames, List<String> matches)
		{
			if (numberOfGames > 0)
				for (int j = 0; j < 2; j++)
					Permutations(text + j.ToString(), numberOfGames - 1, matches);
			else
			{
				matches.Add(text.ToString());
				System.GC.Collect();
			}

		}
		public static List<int> calculateLongestWinStreak(List<string> matches)
		{
			List<int> winStreaks = new List<int>();
			foreach (string s in matches)
			{
				if (s.Contains("1"))
				{
					MatchCollection mc = Regex.Matches(s, "[1]+");
					int longest = (from Match m in mc select m.Value.Length).ToArray<int>().Max();
					winStreaks.Add(longest);
				}
				else winStreaks.Add(0);
			}
			return winStreaks;
		}
		public static List<double> calculateProbability(List<string> matches, double winProbability)
		{
			List<double> probability = new List<double>();
			double loseProbability = 1 - winProbability;
			foreach (string s in matches)
			{
				char[] s1 = s.ToCharArray();
				double temp = 1;
				foreach (char c in s1)
				{
					if (c == '1') temp = temp * winProbability;
					else temp = temp * loseProbability;
				}
				probability.Add(temp);
			}
			return probability;
		}

		public static double calculateResult(List<double> probability, List<int> winStreaks)
		{
			double result = 0.0;

			for (int i = 0; i < probability.Count; i++)
			{

						result = result + (probability[i] * winStreaks[i]);
					
				}
			return result;

			}

		}




}