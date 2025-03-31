<Query Kind="Program" />

void Main()
{
	int[] nums = [1,-2,-3];
	MinStartValue(nums).Dump();
}

public int MinStartValue(int[] nums)
{
	int startMin = nums[0] > 0 ? 0 : Math.Abs(nums[0]) + 1;
	if (nums.Length == 1) return startMin;

	int acc = startMin;
	int minPrefixSum = int.MaxValue;

	for (int i = 0; i < nums.Length; i++)
	{
		acc += nums[i];
		minPrefixSum = Math.Min(minPrefixSum, acc);
	}

	int min = startMin + (1 - minPrefixSum);
	return min > 0 ? min : 1;
}