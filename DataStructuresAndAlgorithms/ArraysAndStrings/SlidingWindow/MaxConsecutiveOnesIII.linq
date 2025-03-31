<Query Kind="Program" />

void Main()
{
	int[] nums = [0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1];
	int k = 3;
	
	LongestOnes(nums, k).Dump();
}

public int LongestOnes(int[] nums, int k)
{
	int result = 0, windowZeros = 0, windowSize = 0;
	int left = -1, right = 0;
	Queue<int> zeroIndices = [];
	while (right < nums.Length)
	{
		if(nums[right] == 0)
		{
			windowZeros++;
			zeroIndices.Enqueue(right);
		}
		
		if (windowZeros <= k)
		{
			windowSize++;
		}
		else
		{
			result = Math.Max(result, windowSize);

			left = zeroIndices.Dequeue();
			
			windowSize = right - left;
			windowZeros--;
		}

		right++;
	}

	return Math.Max(result, windowSize);
}