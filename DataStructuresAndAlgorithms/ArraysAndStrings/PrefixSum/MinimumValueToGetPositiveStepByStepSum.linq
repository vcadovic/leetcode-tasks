<Query Kind="Program" />

/*
 * LeetCode 1413: Minimum Value to Get Positive Step by Step Sum
 * 
 * Problem Description:
 * Given an array of integers nums, you start with an initial positive value startValue.
 * In each iteration, you calculate the step by step sum of startValue plus elements in nums (from left to right).
 * Return the minimum positive value of startValue such that the step by step sum is never less than 1.
 * 
 * Example: Input: nums = [-3,2,-3,4,2]
 *          Output: 5
 *          Explanation: If you choose startValue = 4, step sums are [4,1,4,1,5,7]
 *                      The minimum startValue must be 5: [5,2,5,2,6,8]
 * 
 * Solution Explanation:
 * This solution uses prefix sum to find the minimum cumulative sum:
 * 1. Initialize startMin to handle the first element (0 if positive, abs(first)+1 otherwise)
 * 2. Calculate all prefix sums while tracking the minimum prefix sum
 * 3. If minimum prefix sum is less than 1, we need to add (1 - minPrefixSum) to startMin
 * 4. Return the calculated minimum or 1 (whichever is larger)
 * The key insight: the minimum startValue is determined by the most negative prefix sum.
 * Time Complexity: O(n), Space Complexity: O(1)
 */

void Main()
{
	int[] nums = [1,-2,-3];
	MinStartValue(nums).Dump();
}

public int MinStartValue(int[] nums)
{
	int startMin = nums[0] > 0 ? 0 : Math.Abs(nums[0]) + 1;
	if (nums.Length == 1) return startMin;

	int acc = startMin;
	int minPrefixSum = int.MaxValue;

	for (int i = 0; i < nums.Length; i++)
	{
		acc += nums[i];
		minPrefixSum = Math.Min(minPrefixSum, acc);
	}

	int min = startMin + (1 - minPrefixSum);
	return min > 0 ? min : 1;
}