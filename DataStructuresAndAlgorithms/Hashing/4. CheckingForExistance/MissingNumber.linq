<Query Kind="Program" />

/*
 * LeetCode 268: Missing Number
 * 
 * Problem Description:
 * Given an array nums containing n distinct numbers in the range [0, n], return the only number
 * in the range that is missing from the array.
 * 
 * Example: Input: nums = [3,0,1]
 *          Output: 2
 *          Explanation: n = 3 since there are 3 numbers, so all numbers are in [0,3]. 2 is missing.
 * 
 * Solution Explanation:
 * Two approaches are provided:
 * 
 * Approach 1 (MissingNumber): Gauss Formula
 * - Calculate sum of indices 1 to n: 1+2+...+n
 * - Calculate sum of array elements
 * - The difference is the missing number
 * - Uses mathematical property: sum of first n natural numbers = n*(n+1)/2
 * 
 * Approach 2 (MissingNumberXor): XOR Bit Manipulation
 * - Initialize missing with n (handles case where n is missing)
 * - XOR all indices with all array values: missing ^= i ^ nums[i]
 * - XOR properties: a^a=0, a^0=a, so all paired numbers cancel out
 * - Only the missing number remains
 * 
 * Both approaches: Time Complexity: O(n), Space Complexity: O(1)
 */

void Main()
{
	int[] nums = [9,6,4,2,3,5,7,0,1];
	MissingNumberXor(nums).Dump();
	MissingNumber(nums).Dump();
}

public int MissingNumber(int[] nums) // Gauss formula
{
	int sum = 0, indicesSum = 0;
	
	for (int i = 0; i < nums.Length; i++)
	{
		indicesSum += i + 1;
		sum += nums[i];
	}
	
	return indicesSum - sum;
}

public int MissingNumberXor(int[] nums)
{
	int missing = nums.Length;
	for (int i = 0; i < nums.Length; i++)
	{
		missing ^= i ^ nums[i];
	}
	
	return missing;
}