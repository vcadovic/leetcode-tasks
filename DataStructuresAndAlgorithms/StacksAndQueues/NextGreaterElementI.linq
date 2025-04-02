<Query Kind="Program" />

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