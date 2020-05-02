using System;
using System.Collections.Generic;

namespace HopfieldNetwork.Test
{
	public class NoiseGenerator
	{
		private readonly Random _random = new Random();
		
		public List<int> GenerateNoiseImage(List<int> image, int noiseLevel)
		{
			var noiseImage = new List<int>(image);

			var changedPositions = new List<int>(noiseLevel);
			while (changedPositions.Count != noiseLevel)
			{
				int position = _random.Next(image.Count);
				if (!changedPositions.Contains(position))
				{
					if (noiseImage[position] == -1)
					{
						noiseImage[position] = 1;
					}
					else
					{
						noiseImage[position] = -1;
					}
				}
				changedPositions.Add(position);
			}
			
			return noiseImage;
		}
		
		public List<List<int>> GenerateNoiseImages(List<int> image, int noiseLevel, int imagesNumber)
		{
			var images = new List<List<int>>(imagesNumber);
			for (int i = 0; i < imagesNumber; i++)
			{
				images.Add(GenerateNoiseImage(image, noiseLevel));
			}
			return images;
		}
	}
}