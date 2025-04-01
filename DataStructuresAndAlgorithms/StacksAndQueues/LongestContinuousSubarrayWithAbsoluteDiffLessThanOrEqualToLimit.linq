<Query Kind="Program" />

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