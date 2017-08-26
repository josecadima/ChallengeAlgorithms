using ChallengeAlgorithms.Algorithms.SortAlgorithms;
using ChallengeAlgorithms.DataStructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeAlgorithms.Challenges.Sorting
{
	public static class JimOrders
	{
		public static void ExecuteSolution()
		{
			int orderCount = int.Parse(Console.ReadLine());

			var orderList = new List<Order>();

			//Fill order list
			for (int i = 1; i <= orderCount; i++)
			{
				string[] times = Console.ReadLine().Split(' ');

				var order = new Order(int.Parse(times[0]), int.Parse(times[1]));
				order.Id = orderList.Count + 1;

				orderList.Add(order);
			}

			// O(n2) Buble sort
			//BubleSortAlgorithm.SortItems<Order>(orderList);

			//O(nlogn)
			MergeSortAlgorithm.SortItems<Order>(orderList, 0, orderList.Count - 1);

			DisplayResults(orderList);
		}

		private static void DisplayResults(List<Order> orders)
		{
			StringBuilder builder = new StringBuilder();

			for (int i = 0; i < orders.Count; i++)
			{
				builder.Append(orders[i].Id + " ");
			}

			Console.Write(builder.ToString());
		}
	}

	public class Order : ISortableItem
	{
		private int requestTime;
		private int spendTime;

		public int Id { get; set; }

		public int Value
		{
			get { return requestTime + spendTime; }
			set { }
		}

		public Order(int requestTime, int spendTime)
		{
			this.requestTime = requestTime;
			this.spendTime = spendTime;
		}
	}
}
