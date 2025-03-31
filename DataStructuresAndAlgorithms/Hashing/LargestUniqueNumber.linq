<Query Kind="Program" />

void Main()
{
	int[] nums = [5, 7, 3, 9, 4, 9, 8, 3, 1];
	LargestUniqueNumber(nums).Dump();
}

public int LargestUniqueNumber(int[] nums) => nums
	.GroupBy(n => n)
	.ToDictionary(g => g.Key, g => g.Count())
	.Where(g => g.Value == 1)
	.Select(g => g.Key)
	.DefaultIfEmpty(-1)
	.Max(g => g);