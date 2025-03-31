<Query Kind="Program" />

void Main()
{
	int[] nums = [7, 4, 3, 9, 1, 8, 5, 2, 6];
	int k = 3;
	
	GetAverages(nums, 3).Dump();
}

public int[] GetAverages(int[] nums, int k)
{
	if (k == 0)
	{
		return nums;
	}

	if (nums.Length < (k * 2 + 1))
	{
		return Enumerable.Repeat(-1, nums.Length).ToArray();
	}

	return Gen().ToArray();

	IEnumerable<int> Gen()
	{
		long[] prefixSum = new long[nums.Length + 1];

		for (int j = 0; j < nums.Length; j++)
		{
			prefixSum[j + 1] = prefixSum[j] + nums[j];
		}

		int windowSize = k * 2 + 1;
		for (int i = 0; i < nums.Length; i++)
		{
			if (i < k || i + k >= nums.Length)
			{
				yield return -1;
			}
			else
			{
				yield return (int)((prefixSum[i + k + 1] - prefixSum[i - k]) / windowSize);
			}
		}
	}
}