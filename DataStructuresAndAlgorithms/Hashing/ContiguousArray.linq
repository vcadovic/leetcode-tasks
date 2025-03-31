<Query Kind="Program" />

void Main()
{
	int[] nums = [0,1,0];
	FindMaxLength(nums).Dump();
}

public int FindMaxLength(int[] nums)
{
	Dictionary<int, int> sumToIndex = new() { { 0, -1 } };
	int currentSum = 0, result = 0;

	for (int i = 0; i < nums.Length; i++)
	{
		currentSum += nums[i] == 0 ? -1 : 1;
		
		if (sumToIndex.TryGetValue(currentSum, out int rangeStart))
		{
			result = Math.Max(result, i - rangeStart);
		}
		else
		{
			sumToIndex[currentSum] = i;
		}
	}
	
	return result;
}