using ChallengeAlgorithms.DataStructures.Interfaces;
using System;
using System.Collections.Generic;

namespace ChallengeAlgorithms.Algorithms.SortAlgorithms
{
	public static class MergeSortAlgorithm
	{
		public static void SortItems<T>(List<T> items, int startIndex, int endIndex) where T : ISortableItem
		{
			if (startIndex >= endIndex)
				return;

			int midleIndex = startIndex + (endIndex - startIndex) / 2;

			//Left items
			SortItems<T>(items, startIndex, midleIndex);

			//Right items
			SortItems<T>(items, midleIndex + 1, endIndex);

			//Merge both sides
			Merge(items, startIndex, midleIndex, endIndex);

			//Display Partial Merges
			//for (int i = startIndex; i <= endIndex; i++)
			//	Console.Write(items[i].Value + " ");
			//Console.WriteLine();
		}

		private static void Merge<T>(List<T> items, int startIndex, int midleIndex, int endIndex) where T : ISortableItem
		{
			var left = new List<T>();
			var right = new List<T>();

			int leftCount = midleIndex - startIndex + 1;
			int rightCount = endIndex - midleIndex;

			//Split into temp lists
			for (int i = 0; i < leftCount; i++)
				left.Add(items[startIndex + i]);

			for (int i = 0; i < rightCount; i++)
				right.Add(items[midleIndex + 1 + i]);

			int leftIndex = 0;
			int rightIndex = 0;
			int listIndex = startIndex;

			while (leftIndex < leftCount && rightIndex < rightCount)
			{
				if (left[leftIndex].Value <= right[rightIndex].Value)
				{
					items[listIndex] = left[leftIndex];
					leftIndex++;
				}
				else {
					items[listIndex] = right[rightIndex];
					rightIndex++;
				}

				listIndex++;
			}

			// Copy remaining left items
			while (leftIndex < leftCount)
			{
				items[listIndex] = left[leftIndex];

				leftIndex++;
				listIndex++;
			}

			// Copy remaining right items
			while (rightIndex < rightCount)
			{
				items[listIndex] = right[rightIndex];

				rightIndex++;
				listIndex++;
			}
		}
	}
}
