<Query Kind="Program" />

/*
 * LeetCode 1133: Largest Unique Number
 * 
 * Problem Description:
 * Given an integer array nums, return the largest integer that only occurs once.
 * If no integer occurs once, return -1.
 * 
 * Example: Input: nums = [5,7,3,9,4,9,8,3,1]
 *          Output: 8
 *          Explanation: The maximum integer that appears exactly once is 8.
 * 
 * Solution Explanation:
 * This solution uses LINQ with GroupBy and Dictionary for a functional approach:
 * 1. Group elements by their value to get counts
 * 2. Convert to Dictionary with value as key and count as value
 * 3. Filter to keep only entries with count == 1 (unique elements)
 * 4. Select the keys (the unique numbers)
 * 5. Use DefaultIfEmpty(-1) to handle the case when no unique numbers exist
 * 6. Return the maximum value
 * This is a concise, declarative approach using LINQ method chaining.
 * Time Complexity: O(n), Space Complexity: O(n)
 */

void Main()
{
	int[] nums = [5, 7, 3, 9, 4, 9, 8, 3, 1];
	LargestUniqueNumber(nums).Dump();
}

public int LargestUniqueNumber(int[] nums) => nums
	.GroupBy(n => n)
	.ToDictionary(g => g.Key, g => g.Count())
	.Where(g => g.Value == 1)
	.Select(g => g.Key)
	.DefaultIfEmpty(-1)
	.Max();