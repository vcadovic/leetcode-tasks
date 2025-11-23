<Query Kind="Program" />

/*
 * LeetCode 1438: Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit
 * 
 * Problem Description:
 * Given an array of integers nums and an integer limit, return the size of the longest non-empty subarray
 * such that the absolute difference between any two elements of this subarray is less than or equal to limit.
 * 
 * Example: Input: nums = [10,1,2,4,7,2], limit = 5
 *          Output: 4
 *          Explanation: The subarray [2,4,7,2] is the longest since the maximum absolute diff is |2-7| = 5 <= 5.
 * 
 * Solution Explanation:
 * This solution uses two monotonic deques to efficiently track min and max in sliding window:
 * 1. Maintain two monotonic deques:
 *    - Increasing deque: tracks minimum values (smallest at front)
 *    - Decreasing deque: tracks maximum values (largest at front)
 * 2. For each element, add it to both deques (they maintain their monotonic property)
 * 3. Check if max - min > limit:
 *    - If yes, shrink window from left by removing elements from deques if they match left element
 *    - Move left pointer forward
 * 4. Track maximum window size
 * Monotonic deques ensure O(1) access to min/max, avoiding O(k) for each window position.
 * Time Complexity: O(n), Space Complexity: O(k) where k is the window size
 */

void Main()
{
	int[] nums = [10, 1, 2, 4, 7, 2];
	int limit = 5;
	
	LongestSubarray(nums, limit).Dump();
}

public int LongestSubarray(int[] nums, int limit)
{
	IncreasingMonotonicDeque<int> increasing = [];
	DecreasingMonotonicDeque<int> decreasing = [];

	int left = 0;
	int result = 0;

	for (int right = 0; right < nums.Length; right++)
	{
		increasing.Push(nums[right]);
		decreasing.Push(nums[right]);

		while (decreasing.PeekFirst() - increasing.PeekFirst() > limit)
		{
			if (nums[left] == decreasing.PeekFirst())
			{
				decreasing.PopFirst();
			}
			if (nums[left] == increasing.PeekFirst())
			{
				increasing.PopFirst();
			}

			left++;
		}

		result = Math.Max(result, right - left + 1);
	}

	return result;
}

abstract class MonotonicDeque<T> : LinkedList<T> where T : IComparable
{
	public void PopFirst() => RemoveFirst();
	public T PeekFirst() => First.Value;

	public void Push(T item)
	{
		while (Count > 0 && Compare(Last.Value, item) > 0)
		{
			PopLast();
		}

		PushLast(item);
	}

	protected abstract int Compare(T x, T y);

	private void PopLast() => RemoveLast();
	private void PushLast(T item) => AddLast(item);
}

class IncreasingMonotonicDeque<T> : MonotonicDeque<T> where T : IComparable
{
	protected override int Compare(T x, T y) => x.CompareTo(y);
}

class DecreasingMonotonicDeque<T> : MonotonicDeque<T> where T : IComparable
{
	protected override int Compare(T x, T y) => y.CompareTo(x);
}