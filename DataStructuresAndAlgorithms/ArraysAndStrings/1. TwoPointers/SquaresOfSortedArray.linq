<Query Kind="Program" />

/*
 * LeetCode 977: Squares of a Sorted Array
 * 
 * Problem Description:
 * Given an integer array nums sorted in non-decreasing order, return an array of the squares
 * of each number sorted in non-decreasing order.
 * 
 * Example: Input: nums = [-4,-1,0,3,10]
 *          Output: [0,1,9,16,100]
 *          Explanation: After squaring, the array becomes [16,1,0,9,100].
 *                      After sorting, it becomes [0,1,9,16,100].
 * 
 * Solution Explanation:
 * This solution uses the two-pointer technique to achieve O(n) time complexity:
 * 1. Since the input is sorted, the largest absolute values are at the ends (negative or positive)
 * 2. Use two pointers: left at start, right at end of the array
 * 3. Fill the result array from right to left (largest to smallest)
 * 4. Compare absolute values at both pointers:
 *    - If right has larger absolute value, square it and place in result, move right left
 *    - If left has larger absolute value, square it and place in result, move left right
 * 5. Continue until all elements are processed
 * This avoids the need to square all elements and then sort, reducing time from O(n log n) to O(n).
 * Time Complexity: O(n), Space Complexity: O(n) for the result array
 */

void Main()
{
	int[] nums = [-7, -3, 2, 3, 11];
	SortedSquares(nums).Dump();
}

public int[] SortedSquares(int[] nums)
{
	int[] result = new int[nums.Length];
	int resultPos = result.Length - 1;
	int left = 0, right = nums.Length - 1;
	
	while (left <= right)
	{
		var leftVal = int.Abs(nums[left]);
		var rightVal = int.Abs(nums[right]);
		
		if (leftVal <= rightVal)
		{
			right--;
			result[resultPos--] = rightVal * rightVal;
		}
		else
		{
			left++;
			result[resultPos--] = leftVal * leftVal;
		}
	}
	
	return result;
}