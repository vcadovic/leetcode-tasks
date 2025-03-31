<Query Kind="Program" />

void Main()
{
	int[] nums = [3, 1, 2, 10, 1];
	RunningSum(nums).Dump();
}

// You can define other methods, fields, classes and namespaces here
public int[] RunningSum(int[] nums)
{
	return nums.Aggregate(
		seed: (Results: new List<int>(), CurrentSum: 0),
		func: (acc, num) =>
		{
			var (results, currentSum) = acc;
			currentSum += num;

			results.Add(currentSum);

			return (results, currentSum);
		}
	).Results.ToArray();
}