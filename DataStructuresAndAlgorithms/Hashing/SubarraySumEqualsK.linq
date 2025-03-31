<Query Kind="Program" />

void Main()
{
	int[] nums = { 3, 4, 7, 2, -3, 1, 4, 2, 1 };
	int k = 7;
	
	SubarraySum(nums, k).Dump();
	
	nums = [1, 1, 2, 1, 1];
	k = 3;
	SubarrayOddsCount(nums, k).Dump();
}

public int SubarraySum(int[] nums, int k)
{
	Dictionary<int, int> sumsMet = new() { { 0, 1 } };
	int currentSum = 0, result = 0;

	foreach (var num in nums)
	{
		currentSum += num;
		result += sumsMet.GetValueOrDefault(currentSum - k);
		sumsMet.TryAdd(currentSum, 0);
		sumsMet[currentSum]++;
	}
	
	return result;
}

public int SubarrayOddsCount(int[] nums, int k)
{
	Dictionary<int, int> countsMet = new() { { 0, 1 } };
	int currentCount = 0, result = 0;

	foreach (var num in nums)
	{
		currentCount += num % 2;
		result += countsMet.GetValueOrDefault(currentCount - k);
		countsMet.TryAdd(currentCount, 0);
		countsMet[currentCount]++;
	}

	return result;
}