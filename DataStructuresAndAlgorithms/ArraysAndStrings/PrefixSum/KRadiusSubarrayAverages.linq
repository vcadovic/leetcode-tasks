<Query Kind="Program" />

/*
 * LeetCode 2090: K Radius Subarray Averages
 * 
 * Problem Description:
 * Given a 0-indexed array nums of n integers and an integer k, return an array where the
 * i-th element is the average of the subarray centered at index i with a radius of k.
 * The radius k means the subarray includes k elements on each side of index i (total 2k+1 elements).
 * If there are less than k elements before or after index i, the average for that index is -1.
 * 
 * Example: Input: nums = [7,4,3,9,1,8,5,2,6], k = 3
 *          Output: [-1,-1,-1,5,4,4,-1,-1,-1]
 * 
 * Solution Explanation:
 * This solution uses the prefix sum technique for efficient range sum queries:
 * 1. First, handle edge cases: if k=0 return original array, if array too small return all -1s
 * 2. Build a prefix sum array where prefixSum[i] = sum of first i elements
 * 3. For each index i, check if a full window (2k+1 elements) can be formed around it
 * 4. If yes, calculate average using: (prefixSum[i+k+1] - prefixSum[i-k]) / windowSize
 * 5. If no, return -1 for that index
 * This avoids recalculating sums for each window, reducing time from O(n*k) to O(n).
 * Time Complexity: O(n), Space Complexity: O(n)
 */

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