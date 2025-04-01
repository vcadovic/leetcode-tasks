<Query Kind="Program" />

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