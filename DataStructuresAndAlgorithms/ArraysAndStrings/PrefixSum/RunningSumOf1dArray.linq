<Query Kind="Program" />

/*
 * LeetCode 1480: Running Sum of 1d Array
 * 
 * Problem Description:
 * Given an array nums, we define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
 * Return the running sum of nums.
 * 
 * Example: Input: nums = [1,2,3,4]
 *          Output: [1,3,6,10]
 *          Explanation: Running sum is [1, 1+2, 1+2+3, 1+2+3+4]
 * 
 * Solution Explanation:
 * This solution uses LINQ's Aggregate method to build the running sum in a single pass.
 * We maintain an accumulator tuple containing:
 * - Results: A list to store running sum values
 * - CurrentSum: The cumulative sum up to the current index
 * For each number, we add it to currentSum, append it to results, and return the updated tuple.
 * Finally, we convert the results list to an array.
 * Time Complexity: O(n), Space Complexity: O(n)
 */

void Main()
{
	int[] nums = [3, 1, 2, 10, 1];
	RunningSum(nums).Dump();
}

// You can define other methods, fields, classes and namespaces here
public int[] RunningSum(int[] nums)
{
	return nums.Aggregate(
		seed: (Results: new List<int>(), CurrentSum: 0),
		func: (acc, num) =>
		{
			var (results, currentSum) = acc;
			currentSum += num;

			results.Add(currentSum);

			return (results, currentSum);
		}
	).Results.ToArray();
}