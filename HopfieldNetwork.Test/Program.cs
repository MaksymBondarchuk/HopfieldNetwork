using System;
using System.Collections.Generic;
using System.Linq;
using HopfieldNetwork.Images;

namespace HopfieldNetwork.Test
{
	internal static class Program
	{
		private const int NoiseImagesPerTestSet = 20;
		private const int NetworksNumber = 10;

		private static void Main()
		{
			var noiseGenerator = new NoiseGenerator();

			var testSets = new List<TestSet>
			{
				new TestSet
				{
					Name = "T",
					Image = ImagesHelper.T
				},
				new TestSet
				{
					Name = "K",
					Image = ImagesHelper.K
				},
				new TestSet
				{
					Name = "V",
					Image = ImagesHelper.V
				},
				new TestSet
				{
					Name = "C",
					Image = ImagesHelper.C
				}
			};

			var networks = new List<Network>(NetworksNumber);
			for (int i = 0; i < NetworksNumber + 2; i++)
			{
				var network = new Network();
				network.Learn(testSets.Select(s => s.Image).ToList());
				networks.Add(network);
			}

			networks = networks.Skip(1).Take(NetworksNumber).ToList();

			for (int noiseLevel = 0; noiseLevel <= 18; noiseLevel++)
			{
				// Setup
				foreach (TestSet testSet in testSets)
				{
					testSet.NoiseImages = noiseGenerator.GenerateNoiseImages(testSet.Image, noiseLevel, NoiseImagesPerTestSet);
				}

				// Act, Assert
				foreach (TestSet testSet in testSets)
				{
					int rememberedNumberAverage = networks
						.Sum(network => testSet.NoiseImages.Select(network.TryToRemember)
						.Count(rememberedImage => rememberedImage.SequenceEqual(testSet.Image))) / NetworksNumber;

					Console.WriteLine($"Noise {noiseLevel,2}. Image {testSet.Name}. Remembered {rememberedNumberAverage} of {NoiseImagesPerTestSet}");
				}
			}
		}
	}
}