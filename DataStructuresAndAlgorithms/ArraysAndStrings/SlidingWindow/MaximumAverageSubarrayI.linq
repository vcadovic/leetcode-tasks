<Query Kind="Program" />

void Main()
{
	int[] nums = [1, 12, -5, -6, 50, 3];
	int k = 4;
	
	FindMaxAverage(nums, k).Dump();
}

// You can define other methods, fields, classes and namespaces here
public double FindMaxAverage(int[] nums, int k)
{
	if (nums.Length == 1) return nums[0];
	if (k == 1) return nums.Max();
	
	int currentSum = nums[0..k].Sum();
	double result = currentSum / k;
	for (int left = 0, right = k; right < nums.Length; left++, right++)
	{
		currentSum += nums[right] - nums[left];
		double currentAvg = currentSum / k;
		result = Math.Max(currentAvg, result);
	}
	
	return result;
}