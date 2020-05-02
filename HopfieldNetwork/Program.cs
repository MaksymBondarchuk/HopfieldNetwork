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
			// network.Learn(new List<List<int>>
			// {
			// 	ImagesHelper.A,
			// 	ImagesHelper.B,
			// 	ImagesHelper.C,
			// 	ImagesHelper.F,
			// 	ImagesHelper.K,
			// 	ImagesHelper.L,
			// 	ImagesHelper.N,
			// 	ImagesHelper.O,
			// 	ImagesHelper.P,
			// 	ImagesHelper.S,
			// 	ImagesHelper.T,
			// 	ImagesHelper.V,
			// 	ImagesHelper.X,
			// 	ImagesHelper.Z,
			// });
			network.Learn(new List<List<int>>
			{
				ImagesHelper.T,
				ImagesHelper.K,
				ImagesHelper.V,
				ImagesHelper.C,
			});


			// // A
			// Console.WriteLine("A");
			// PrintImage(network.TryToRemember(new List<int>
			// {
			// 	01, 01, 01, -1, 01, 01, 01,
			// 	01, 01, -1, 01, -1, 01, 01,
			// 	01, 01, -1, -1, -1, 01, 01,
			// 	01, -1, 01, 01, 01, -1, 01,
			// 	01, -1, -1, -1, -1, -1, 01,
			// 	01, -1, 01, 01, 01, -1, 01,
			// 	-1, 01, 01, 01, 01, 01, -1,
			// 	-1, 01, 01, 01, 01, -1, 01
			// }));

			// C
			Console.WriteLine("C");
			PrintImage(network.TryToRemember(new List<int>
			{
				-1, -1, -1, -1, -1, -1, -1,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, 01, -1, 01, 01, 01,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, 01, 01, -1, 01, 01,
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, -1, -1, -1, -1, -1
			}));


			// K
			Console.WriteLine("K");
			PrintImage(network.TryToRemember(new List<int>
			{
				-1, 01, 01, 01, 01, 01, 01,
				-1, 01, -1, 01, 01, -1, 01,
				-1, 01, 01, 01, -1, 01, 01,
				-1, -1, -1, -1, 01, 01, 01,
				-1, 01, 01, 01, -1, 01, 01,
				-1, 01, -1, 01, -1, -1, 01,
				-1, 01, 01, 01, 01, 01, -1,
				-1, 01, 01, 01, 01, 01, -1
			}));

			// // L
			// Console.WriteLine("L");
			// PrintImage(network.TryToRemember(new List<int>
			// {
			// 	-1, 01, 01, 01, 01, 01, 01,
			// 	-1, 01, 01, 01, 01, 01, 01,
			// 	-1, 01, -1, 01, 01, 01, 01,
			// 	-1, 01, 01, 01, 01, 01, -1,
			// 	-1, 01, 01, 01, 01, 01, 01,
			// 	01, 01, 01, 01, 01, 01, 01,
			// 	-1, 01, 01, 01, 01, 01, 01,
			// 	-1, -1, -1, -1, -1, -1, -1
			// }));

			// // N
			// Console.WriteLine("N");
			// PrintImage(network.TryToRemember(new List<int>
			// {
			// 	-1, 01, 01, 01, -1, 01, -1,
			// 	-1, 01, 01, 01, 01, -1, -1,
			// 	-1, 01, 01, 01, -1, 01, -1,
			// 	-1, 01, 01, -1, 01, 01, -1,
			// 	-1, 01, 01, 01, 01, 01, -1,
			// 	-1, 01, -1, 01, 01, 01, -1,
			// 	-1, -1, 01, 01, 01, 01, -1,
			// 	-1, 01, 01, 01, 01, -1, -1
			// }));

			// // O
			// Console.WriteLine("O");
			// PrintImage(network.TryToRemember(new List<int>
			// {
			// 	-1, -1, -1, -1, -1, -1, -1,
			// 	-1, 01, 01, 01, 01, 01, -1,
			// 	-1, 01, 01, 01, 01, 01, -1,
			// 	-1, 01, 01, -1, 01, 01, -1,
			// 	-1, 01, 01, -1, 01, 01, -1,
			// 	-1, 01, 01, -1, 01, 01, -1,
			// 	-1, 01, 01, 01, 01, 01, -1,
			// 	-1, -1, -1, 01, -1, -1, -1
			// }));

			// // S
			// Console.WriteLine("S");
			// PrintImage(network.TryToRemember(new List<int>
			// {
			// 	01, -1, -1, -1, -1, -1, -1,
			// 	-1, 01, 01, 01, -1, 01, 01,
			// 	-1, 01, 01, 01, 01, 01, 01,
			// 	01, -1, 01, -1, -1, -1, 01,
			// 	01, 01, 01, 01, 01, 01, -1,
			// 	01, 01, 01, 01, 01, 01, -1,
			// 	01, 01, 01, 01, 01, 01, -1,
			// 	-1, -1, 01, -1, -1, -1, 01,
			// }));

			// T
			Console.WriteLine("T");
			PrintImage(network.TryToRemember(new List<int>
			{
				-1, -1, 01, -1, -1, -1, -1,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, -1,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01,
				01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01
			}));

			// V
			Console.WriteLine("V");
			PrintImage(network.TryToRemember(new List<int>
			{
				-1, 01, 01, 01, 01, 01, -1,
				-1, 01, 01, -1, 01, 01, -1,
				01, -1, 01, 01, 01, -1, 01,
				01, -1, 01, 01, 01, 01, 01,
				01, 01, 01, 01, -1, 01, 01,
				01, 01, -1, 01, -1, 01, 01,
				01, 01, 01, -1, 01, 01, 01,
				01, 01, 01, -1, 01, 01, 01
			}));

			// // X
			// Console.WriteLine("X");
			// PrintImage(network.TryToRemember(new List<int>
			// {
			// 	-1, 01, 01, 01, 01, 01, -1,
			// 	01, -1, 01, 01, 01, 01, 01,
			// 	01, 01, -1, 01, -1, 01, 01,
			// 	01, -1, 01, -1, 01, 01, 01,
			// 	01, 01, 01, -1, 01, 01, 01,
			// 	01, 01, -1, 01, -1, 01, 01,
			// 	01, 01, 01, 01, 01, -1, 01,
			// 	-1, 01, 01, 01, 01, 01, -1
			// }));
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