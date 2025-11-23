<Query Kind="Program" />

/*
 * LeetCode 31: Next Permutation
 * 
 * Problem Description:
 * A permutation of an array of integers is an arrangement of its members into a sequence or linear order.
 * The next permutation of an array is the next lexicographically greater permutation of its integers.
 * If such arrangement is not possible, the array must be rearranged as the lowest possible order (sorted ascending).
 * The replacement must be in place and use only constant extra memory.
 * 
 * Example: Input: nums = [1,2,3]
 *          Output: [1,3,2]
 * 
 * Solution Explanation:
 * This solution uses a two-step algorithm to find the next permutation:
 * 1. Find the rightmost pair where nums[i] < nums[i+1] (the "pivot"):
 *    - Scan from right to left
 *    - This is the first decreasing element from the right
 *    - If no such pair exists, array is in descending order (largest permutation)
 * 2. If pivot found:
 *    - Find the smallest element to the right of pivot that is larger than pivot
 *    - Swap pivot with this element
 *    - This ensures we get the next larger permutation
 * 3. Reverse the subarray to the right of pivot:
 *    - This subarray is in descending order
 *    - Reversing it gives the smallest arrangement
 *    - Combined with step 2, this gives the next permutation
 * 4. If no pivot found, reverse entire array (wrap to smallest permutation)
 * Time Complexity: O(n), Space Complexity: O(1)
 */

void Main()
{
	int[] nums = [2, 4, 1, 3];
	NextPermutation(nums);
	
	nums.Dump();
}

public void NextPermutation(int[] nums)
{
	if (nums.Length <= 1) return;
	
	int i = nums.Length - 2;
	while (i >= 0 && nums[i] >= nums[i + 1]) i--;
	
	if (i >= 0)
	{
		int j = nums.Length - 1;
		while (j >= i && nums[i] >= nums[j]) j--;

		Swap(ref nums[i], ref nums[j]);
	}	
	
	Array.Reverse(nums, i + 1, nums.Length - i - 1);
}

private void Swap(ref int a, ref int b)
{
	int temp = b;
	b = a;
	a = temp;
}