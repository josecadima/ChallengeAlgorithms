using ChallengeAlgorithms.DataStructures.Interfaces;
using System.Collections.Generic;

namespace ChallengeAlgorithms.Algorithms.SortAlgorithms
{
	public static class BubleSortAlgorithm
	{
		// Sort Hash table by the OrderValue ascending
		public static void SortItems<T>(List<T> items) where T : ISortableItem
		{
			for (int i = 0; i < items.Count - 1; i++)
			{
				for (int j = i + 1; j < items.Count; j++)
				{
					if (items[i].Value > items[j].Value)
					{
						var tempOrder = items[i];
						items[i] = items[j];
						items[j] = tempOrder;
					}
				}
			}
		}
	}
}
