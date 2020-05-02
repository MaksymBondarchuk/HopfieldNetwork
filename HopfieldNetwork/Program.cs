using System;
using System.Collections.Generic;
using HopfieldNetwork.Images;

namespace HopfieldNetwork
{
	internal static class Program
	{
		private static void Main()
		{
			var network = new Network();
			// K and N
			// C and O
			// Z
			network.Learn(new List<List<int>> {ImagesHelper.T, ImagesHelper.K, ImagesHelper.V, ImagesHelper.C, ImagesHelper.P});

			
			// K
			List<int> image = network.TryToRemember(new List<int>
			{
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, -1, 01, 01, -1, 01,
				-1, 01, 01, 01, -1, 01, 01,
				-1, -1, -1, -1, 01, 01, 01,
				-1, 01, 01, 01, -1, 01, 01,
				-1, 01, -1, 01, -1, -1, 01,
				-1, 01, 01, 01, 01, 01, -1,
				-1, 01, 01, 01, 01, 01, -1
			});
			PrintImage(image);

			// C
			image = network.TryToRemember(new List<int>
			{
				-1, -1, -1, -1, -1, -1, -1,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, 01, -1, 01, 01, 01,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, 01, 01, -1, 01, 01,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, -1, -1, -1, -1, -1
			});
			PrintImage(image);

			// T
			image = network.TryToRemember(new List<int>
			{
				-1, -1, 01, -1, -1, -1, -1,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, -1,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01,
				01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01
			});
			PrintImage(image);

			// V
			image = network.TryToRemember(new List<int>
			{
				-1, 01, 01, 01, 01, 01, -1,
				-1, 01, 01, -1, 01, 01, -1,
				01, -1, 01, 01, 01, -1, 01,
				01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01,
				01, 01, -1, 01, -1, 01, 01,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01
			});
			PrintImage(image);

			// P
			image = network.TryToRemember(new List<int>
			{
				01, -1, -1, -1, -1, 01, 01,
				01, -1, 01, -1, -1, 01, -1,
				01, -1, 01, 01, -1, 01, 01,
				01, -1, 01, 01, -1, 01, 01,
				01, -1, 01, -1, -1, 01, 01,
				01, -1, 01, 01, 01, 01, 01,
				01, -1, 01, 01, 01, 01, 01,
				01, -1, 01, 01, 01, 01, 01
			});
			PrintImage(image);
		}

		private static void PrintImage(IReadOnlyList<int> image)
		{
			const int dimension = 7;
			// int dimension = Convert.ToInt32(Math.Ceiling(Math.Sqrt(image.Count)));
			for (int i = 0; i < image.Count; i++)
			{
				Console.Write(image[i] == -1 ? "-1 " : " 1 ");

				if ((i + 1) % dimension == 0)
				{
					Console.WriteLine();
				}
			}

			Console.WriteLine();
		}
	}
}