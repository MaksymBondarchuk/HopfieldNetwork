using System;
using System.Collections.Generic;

namespace HopfieldNetwork
{
	internal static class Program
	{
		private static readonly List<int> T = new List<int>
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
			01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
		};

		private static void Main()
		{
			var network = new Network();
			network.Learn(new List<List<int>>{T});

			List<int> image = network.TryToRemember(new List<int>
			{
				-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
				01, 01, 01, 01, 01, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01, 01, -1, 01,
				01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
				-1, 01, 01, 01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01, 01, 01, -1,
			});
			PrintImage(image);
		}

		private static void PrintImage(IReadOnlyList<int> image)
		{
			int dimension = Convert.ToInt32(Math.Ceiling(Math.Sqrt(image.Count)));
			for (int i = 0; i < image.Count; i++)
			{
				Console.Write(image[i] == -1 ? "-1 " : " 1 ");

				if ((i + 1) % dimension == 0)
				{
					Console.WriteLine();
				}
			}
		}
	}
}