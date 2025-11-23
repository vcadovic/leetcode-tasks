<Query Kind="Program" />

/*
 * LeetCode 239: Sliding Window Maximum
 * 
 * Problem Description:
 * You are given an array of integers nums, and there is a sliding window of size k which is moving from
 * the very left of the array to the very right. You can only see the k numbers in the window.
 * Each time the sliding window moves right by one position, return the max sliding window.
 * 
 * Example: Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
 *          Output: [3,3,5,5,6,7]
 *          Explanation: Window [1,3,-1] max=3, [3,-1,-3] max=3, [-1,-3,5] max=5, etc.
 * 
 * Solution Explanation:
 * This solution uses a monotonic decreasing deque to efficiently track maximum:
 * 1. Use a LinkedList as a deque to store indices (not values)
 * 2. Maintain deque in decreasing order of values:
 *    - When adding new element, remove all smaller elements from back
 *    - This ensures front always has the maximum
 * 3. Remove front element if it's outside the current window (index check)
 * 4. Once window is full (i >= k-1), yield the value at front index (the maximum)
 * 5. Using indices instead of values allows us to check if elements are still in window
 * The deque maintains potential maximums; smaller elements after a larger one can never be max.
 * Time Complexity: O(n), Space Complexity: O(k)
 */

void Main()
{
	int[] nums = [1, 3, -1, -3, -2, 3, 6, 7];
	int k = 3;
	
	MaxSlidingWindow(nums, k).Dump();
}

public int[] MaxSlidingWindow(int[] nums, int k) 
{
	LinkedList<int> deque = [];
	
	return Gen().ToArray();
	
	IEnumerable<int> Gen()
	{
		for (int i = 0; i < nums.Length; i++)
		{
			while (deque.Last is not null && nums[deque.Last.Value] < nums[i])
			{
				deque.RemoveLast();
			}
			
			deque.AddLast(i);
			
			if (deque.First.Value + k == i)
			{
				deque.RemoveFirst();
			}
			
			if (i >= k - 1)
			{
				yield return nums[deque.First.Value];
			}
		}
	}
}