<Query Kind="Program" />

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