using System;
using System.Collections.Generic;
using System.Linq;

namespace HopfieldNetwork
{
	public class Network
	{
		private readonly List<List<int>> _weights = new List<List<int>>();

		public void Learn(List<List<int>> images)
		{
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

		public List<int> TryToRemember(IEnumerable<int> image)
		{
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
	}
}