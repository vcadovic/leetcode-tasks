<Query Kind="Program" />

/*
 * LeetCode 525: Contiguous Array
 * 
 * Problem Description:
 * Given a binary array nums, return the maximum length of a contiguous subarray with an equal number
 * of 0 and 1.
 * 
 * Example: Input: nums = [0,1,0]
 *          Output: 2
 *          Explanation: [0, 1] (or [1, 0]) is the longest contiguous subarray with equal number of 0 and 1.
 * 
 * Solution Explanation:
 * This solution uses prefix sum with hashing for efficient subarray detection:
 * 1. Treat 0s as -1 and 1s as +1, so equal counts result in sum of 0
 * 2. Use a dictionary to map cumulative sum to the first index where it occurred
 * 3. Initialize with {0: -1} to handle subarrays starting from index 0
 * 4. For each index, calculate currentSum (treating 0 as -1, 1 as +1)
 * 5. If currentSum was seen before, the subarray between those indices has equal 0s and 1s
 * 6. Track the maximum length found
 * Key insight: same sum at two indices means the subarray between them sums to 0 (equal 0s and 1s).
 * Time Complexity: O(n), Space Complexity: O(n)
 */

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