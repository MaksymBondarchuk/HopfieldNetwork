using System;
using System.Collections.Generic;
using System.Linq;
using HopfieldNetwork.Images;

namespace HopfieldNetwork.Test
{
	internal static class Program
	{
		private const int NoiseImagesPerTestSet = 20; 
		
		private static void Main()
		{
			var noiseGenerator = new NoiseGenerator();
			for (int noiseLevel = 0; noiseLevel <= 18; noiseLevel++)
			{
				// Setup
				var testSets = new List<TestSet>
				{
					new TestSet
					{
						Name = "T",
						Image = ImagesHelper.T,
						NoiseImages = noiseGenerator.GenerateNoiseImages(ImagesHelper.T, noiseLevel, NoiseImagesPerTestSet)
					},
					new TestSet
					{
						Name = "K",
						Image = ImagesHelper.K,
						NoiseImages = noiseGenerator.GenerateNoiseImages(ImagesHelper.K, noiseLevel, NoiseImagesPerTestSet)
					},
					new TestSet
					{
						Name = "V",
						Image = ImagesHelper.V,
						NoiseImages = noiseGenerator.GenerateNoiseImages(ImagesHelper.V, noiseLevel, NoiseImagesPerTestSet)
					},
					new TestSet
					{
						Name = "C",
						Image = ImagesHelper.C,
						NoiseImages = noiseGenerator.GenerateNoiseImages(ImagesHelper.C, noiseLevel, NoiseImagesPerTestSet)
					}
				};
				
				// Act
				var network = new Network();
				network.Learn(testSets.Select(s => s.Image).ToList());

				// Assert
				foreach (TestSet testSet in testSets)
				{
					// Console.WriteLine(testSet.Name);
					int rememberedNumber = 0;
					foreach (List<int> noiseImage in testSet.NoiseImages)
					{
						List<int> rememberedImage = network.TryToRemember(noiseImage);
						if (rememberedImage.SequenceEqual(testSet.Image))
						{
							rememberedNumber++;
						}	
					}
					Console.WriteLine($"Noise {noiseLevel,2}. Image {testSet.Name}. Remembered {rememberedNumber} of {NoiseImagesPerTestSet}");
				}
			}
		}
	}
}