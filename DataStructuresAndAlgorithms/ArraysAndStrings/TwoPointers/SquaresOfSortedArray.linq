<Query Kind="Program" />

void Main()
{
	int[] nums = [-7, -3, 2, 3, 11];
	SortedSquares(nums).Dump();
}

public int[] SortedSquares(int[] nums)
{
	int[] result = new int[nums.Length];
	int resultPos = result.Length - 1;
	int left = 0, right = nums.Length - 1;
	
	while (left <= right)
	{
		var leftVal = int.Abs(nums[left]);
		var rightVal = int.Abs(nums[right]);
		
		if (leftVal <= rightVal)
		{
			right--;
			result[resultPos--] = rightVal * rightVal;
		}
		else
		{
			left++;
			result[resultPos--] = leftVal * leftVal;
		}
	}
	
	return result;
}