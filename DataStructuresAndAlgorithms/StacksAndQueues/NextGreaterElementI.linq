<Query Kind="Program" />

/*
 * LeetCode 496: Next Greater Element I
 * 
 * Problem Description:
 * The next greater element of some element x in an array is the first greater element that is to the right of x
 * in the same array. You are given two distinct 0-indexed integer arrays nums1 and nums2, where nums1 is a subset
 * of nums2. For each 0 <= i < nums1.length, find the index j such that nums1[i] == nums2[j] and determine
 * the next greater element of nums2[j] in nums2. If there is no next greater element, then the answer is -1.
 * Return an array ans of length nums1.length such that ans[i] is the next greater element as described above.
 * 
 * Example: Input: nums1 = [4,1,2], nums2 = [1,3,4,2]
 *          Output: [-1,3,-1]
 *          Explanation: For 4: no next greater element. For 1: next greater is 3. For 2: no next greater.
 * 
 * Solution Explanation:
 * This solution uses a monotonic decreasing stack to find next greater elements efficiently:
 * 1. Create a dictionary to store each element's next greater element
 * 2. Use a decreasing monotonic stack while iterating through nums2:
 *    - For each number, pop all smaller elements from stack (they found their next greater)
 *    - Map each popped element to current number as their next greater element
 *    - Push current number onto stack
 * 3. Remaining elements in stack have no next greater element (map to -1)
 * 4. For nums1, lookup each element in the dictionary
 * The monotonic stack ensures we find next greater element in a single pass.
 * Time Complexity: O(n + m), Space Complexity: O(n) where n=nums2.length, m=nums1.length
 */

void Main()
{
	int[] nums1 = [4, 1, 2], nums2 = [1, 3, 4, 2];
	NextGreaterElement(nums1, nums2).Dump();
}

public int[] NextGreaterElement(int[] nums1, int[] nums2)
{
	Dictionary<int, int> nextGreaterMap = [];
	DecreasingMonotonicStackInt decreasing = [];

	foreach (int num in nums2)
	{
		foreach (int item in decreasing.Push(num))
		{
			nextGreaterMap[item] = num;
		}
	}

	while (decreasing.Count > 0)
	{
		nextGreaterMap[decreasing.Pop()] = -1;
	}

	return nums1.Select(n => nextGreaterMap.GetValueOrDefault(n, -1)).ToArray();
}

class DecreasingMonotonicStackInt : Stack<int>
{
	public new IEnumerable<int> Push(int num)
	{
		while (Count > 0 && num > Peek())
		{
			yield return Pop();
		}

		base.Push(num);
	}
}