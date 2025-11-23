<Query Kind="Program" />

/*
 * LeetCode 904: Fruit Into Baskets
 * 
 * Problem Description:
 * You are visiting a farm that has a single row of fruit trees. The trees are represented by an integer array
 * fruits where fruits[i] is the type of fruit the ith tree produces.
 * You want to collect as much fruit as possible. However, the owner has some strict rules:
 * - You only have two baskets, and each basket can only hold a single type of fruit.
 * - Once you reach a tree, you must pick exactly one fruit from that tree if you can.
 * - Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree)
 *   while moving to the right. The picked fruits must fit in one of your baskets.
 * - Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
 * Return the maximum number of fruits you can pick.
 * 
 * Example: Input: fruits = [1,2,1]
 *          Output: 3
 *          Explanation: We can pick from all 3 trees.
 * 
 * Solution Explanation:
 * This is a sliding window problem where the window can contain at most 2 distinct types:
 * 1. Use two Pocket records to track the two types of fruits in current window:
 *    - first: most recently seen fruit type
 *    - second: the other fruit type in the window
 * 2. For each fruit, track Value (total count) and LastRow (consecutive count from end)
 * 3. When encountering a third fruit type:
 *    - Move second to become previous first (keeping only its LastRow consecutive fruits)
 *    - Make new fruit the first
 * 4. When seeing an existing type, update counts and potentially swap first/second
 * 5. Track maximum sum of fruits in both baskets
 * LastRow is crucial for knowing how many fruits to keep when sliding window.
 * Time Complexity: O(n), Space Complexity: O(1)
 */

#nullable enable
void Main()
{
	int[] fruits = [1, 2, 3, 2, 2];
	TotalFruit(fruits).Dump();
}

public int TotalFruit(int[] fruits)
{
	if (fruits.Length == 1) return 1;

	Pocket first = new() { Type = fruits[0], Value = 1, LastRow = 1 };
	Pocket? second = null;

	int maxSum = 0;

	for (int i = 1; i < fruits.Length; i++)
	{
		int currentFirstFruit = first.Type;
		int currentSecondFruit = second?.Type ?? -1;

		if (fruits[i] != currentFirstFruit && fruits[i] != currentSecondFruit)
		{
			second = first with { Value = first.LastRow, LastRow = 1 };
			first = new() { Type = fruits[i], Value = 1, LastRow = 1 };
		}
		else
		{
			if (fruits[i] == currentFirstFruit)
			{
				first.Value++;
				first.LastRow++;
			}
			else if (fruits[i] == currentSecondFruit)
			{
				Pocket temp = first with { };
				first = second! with { Value = second.Value + 1, LastRow = 1 };
				second = temp;
			}
		}

		maxSum = Math.Max(first.Value + (second?.Value ?? 0), maxSum);
	}

	return maxSum;
}

record Pocket
{
	public int Type { get; set; }
	public int Value { get; set; }
	public int LastRow { get; set; }
}