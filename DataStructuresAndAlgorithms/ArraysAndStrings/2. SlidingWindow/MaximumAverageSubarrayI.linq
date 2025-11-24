<Query Kind="Program" />

/*
 * LeetCode 643: Maximum Average Subarray I
 * 
 * Problem Description:
 * Given an array consisting of n integers, find the contiguous subarray of given length k
 * that has the maximum average value. Return the maximum average value.
 * 
 * Example: Input: nums = [1,12,-5,-6,50,3], k = 4
 *          Output: 12.75000
 *          Explanation: Maximum average is (12-5-6+50)/4 = 51/4 = 12.75
 * 
 * Solution Explanation:
 * This solution uses the sliding window technique for optimal performance:
 * 1. Handle edge cases: single element or k=1 (return max element)
 * 2. Calculate the sum of the first k elements as the initial window
 * 3. Slide the window one element at a time by:
 *    - Adding the new element entering the window (nums[right])
 *    - Subtracting the element leaving the window (nums[left])
 * 4. Calculate the average and track the maximum
 * Instead of recalculating the sum for each window (O(k) per window), we update it in O(1).
 * Time Complexity: O(n), Space Complexity: O(1)
 */

void Main()
{
	int[] nums = [1, 12, -5, -6, 50, 3];
	int k = 4;
	
	FindMaxAverage(nums, k).Dump();
}

// You can define other methods, fields, classes and namespaces here
public double FindMaxAverage(int[] nums, int k)
{
	if (nums.Length == 1) return nums[0];
	if (k == 1) return nums.Max();
	
	int currentSum = nums[0..k].Sum();
	double result = currentSum / k;
	for (int left = 0, right = k; right < nums.Length; left++, right++)
	{
		currentSum += nums[right] - nums[left];
		double currentAvg = currentSum / k;
		result = Math.Max(currentAvg, result);
	}
	
	return result;
}