using System;
using System.Collections.Generic;
using System.Linq;

namespace HopfieldNetwork
{
	public class Network
	{
		private readonly List<List<int>> _weights = new List<List<int>>();
		private List<List<int>> _images;

		public void Learn(List<List<int>> images)
		{
			#region Ensure can remember all images

			if (images.First().Count / (2 * Math.Log2(images.First().Count)) < images.Count)
			// if (images.First().Count * 0.14 < images.Count)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Network cannot remember more than {Math.Floor(images.First().Count / (2 * Math.Log2(images.First().Count)))} images");
				return;
			}

			#endregion

			#region Hamming distances

			// for (int i = 0; i < images.Count; i++)
			// {
			// 	for (int j = 0; j < images.Count; j++)
			// 	{
			// 		int distance = HammingDistance(images[i], images[j]);
			// 		if (distance < images.First().Count * .35 && distance != 0)
			// 		{
			// 			ConsoleColor color = Console.BackgroundColor;
			// 			Console.BackgroundColor = ConsoleColor.Red;
			// 			Console.Write($"{distance,8}");
			// 			Console.BackgroundColor = color;
			// 		}
			// 		else
			// 		{
			// 			Console.Write($"{distance,8}");
			// 		}
			// 	}
			//
			// 	Console.WriteLine();
			// }

			#endregion

			_images = images;

			Initialize(images);

			for (int i = 0; i < images.First().Count; i++)
			{
				for (int j = 0; j < i; j++)
				{
					int weight = images.Sum(img => img[i] * img[j]);

					_weights[i][j] = weight;
					_weights[j][i] = weight;
				}
			}
		}

		public List<int> TryToRemember(List<int> image)
		{
			#region Hamming distances

			// for (int i = 0; i < _images.Count; i++)
			// {
			// 	Console.Write($"{HammingDistance(_images[i], image),8}");
			// }
			//
			// Console.WriteLine();

			#endregion

			var neurons = new List<int>(image);

			bool isStable = false;
			while (!isStable)
			{
				var newNeurons = new List<int>(neurons);
				for (int i = 0; i < newNeurons.Count; i++)
				{
					newNeurons[i] = Math.Sign(newNeurons.Select((neuron, j) => neuron * _weights[i][j]).Sum());
				}

				isStable = newNeurons.SequenceEqual(neurons);
				neurons = new List<int>(newNeurons);
			}

			return neurons;
		}

		private void Initialize(IReadOnlyCollection<List<int>> images)
		{
			_weights.Clear();

			for (int i = 0; i < images.First().Count; i++)
			{
				var weightsLine = new List<int>(images.First().Count);
				for (int j = 0; j < images.First().Count; j++)
				{
					weightsLine.Add(0);
				}

				_weights.Add(weightsLine);
			}
		}

		private static int HammingDistance(IReadOnlyCollection<int> image1, IReadOnlyList<int> image2)
		{
			if (image1.Count != image2.Count)
			{
				return 0;
			}

			return image1.Where((bit, i) => bit != image2[i]).Count();
		}
	}
}