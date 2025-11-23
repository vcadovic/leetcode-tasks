<Query Kind="Program" />

/*
 * LeetCode 560: Subarray Sum Equals K
 * 
 * Problem Description:
 * Given an array of integers nums and an integer k, return the total number of subarrays
 * whose sum equals to k. A subarray is a contiguous non-empty sequence of elements within an array.
 * 
 * Example: Input: nums = [1,1,1], k = 2
 *          Output: 2
 *          Explanation: Subarrays [1,1] at index 0-1 and [1,1] at index 1-2 both sum to 2.
 * 
 * Solution Explanation:
 * Two similar solutions using prefix sum with hashing:
 * 
 * SubarraySum: Counts subarrays with sum equal to k
 * 1. Use dictionary to track how many times each prefix sum has occurred
 * 2. Initialize with {0: 1} to handle subarrays starting from index 0
 * 3. For each element, add it to currentSum
 * 4. Check if (currentSum - k) exists in dictionary (means a subarray sums to k)
 * 5. Add that count to result
 * 6. Update dictionary with current sum
 * 
 * SubarrayOddsCount: Counts subarrays with exactly k odd numbers
 * - Same approach but counts odd numbers instead of sums
 * 
 * Key insight: if prefixSum[j] - prefixSum[i] = k, then subarray from i+1 to j sums to k.
 * Time Complexity: O(n), Space Complexity: O(n)
 */

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