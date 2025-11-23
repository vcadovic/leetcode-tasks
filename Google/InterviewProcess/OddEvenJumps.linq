<Query Kind="Program" />

/*
 * LeetCode 975: Odd Even Jump
 * 
 * Problem Description:
 * You are given an integer array arr. From some starting index, you can make a series of jumps.
 * For odd-numbered jumps (1st, 3rd, 5th, ...), you jump to the index j such that arr[i] <= arr[j] and arr[j]
 * is the smallest possible value. If there are multiple such indices j, you can only jump to the smallest such index.
 * For even-numbered jumps (2nd, 4th, 6th, ...), you jump to the index j such that arr[i] >= arr[j] and arr[j]
 * is the largest possible value. If there are multiple such indices j, you can only jump to the smallest such index.
 * It may be that for some index i, there are no legal jumps.
 * A starting index is good if, starting from that index, you can reach the end of the array by jumping some number of times.
 * Return the number of good starting indices.
 * 
 * Example: Input: arr = [10,13,12,14,15]
 *          Output: 2
 *          Explanation: From starting index i=0, we can make jumps to reach the end.
 * 
 * Solution Explanation:
 * This solution uses dynamic programming working backward from the end:
 * 1. Use two boolean arrays:
 *    - odd[i]: can reach end starting from i with an odd jump
 *    - even[i]: can reach end starting from i with an even jump
 * 2. Base case: last index is reachable (both odd and even are true)
 * 3. For each index from right to left:
 *    - Find next valid odd jump (smallest value >= current)
 *    - Find next valid even jump (largest value <= current)
 *    - odd[i] = even[nextHigher] (odd jump leads to even state)
 *    - even[i] = odd[nextLower] (even jump leads to odd state)
 * 4. Use SortedSet for efficient range queries (next higher/lower values)
 * 5. Count how many indices have odd[i] = true (can start with odd jump)
 * Time Complexity: O(n log n), Space Complexity: O(n)
 */

void Main()
{
	int[] arr = [10, 13, 12, 14, 15];
	OddEvenJumps(arr).Dump();
}

public int OddEvenJumps(int[] arr)
{
	int len = arr.Length;

	if (len == 1) return 1;

	int count = 1;

	bool[] odd = new bool[len];
	bool[] even = new bool[len];
	SortedDictionary<int, int> indices = new();

	SortedSet<int> indicesSet = new();

	odd[len - 1] = even[len - 1] = true;
	indices[arr[len - 1]] = len - 1;
	indicesSet.Add(arr[len - 1]);

	for (int i = len - 2; i >= 0; i--)
	{
		int val = arr[i];

		bool canMoveOdd = indices.TryGetValue(FindNextHigher(indicesSet, val), out int nextHigher);
		bool canMoveEven = indices.TryGetValue(FindNextLower(indicesSet, val), out int nextLower);

		if (canMoveOdd) odd[i] = even[nextHigher];
		if (canMoveEven) even[i] = odd[nextLower];

		if (odd[i]) count++;

		indices[val] = i;
		indicesSet.Add(val);
	}

	return count;
}

int FindNextHigher(SortedSet<int> indices, int value)
{
	SortedSet<int> higher = indices.GetViewBetween(value, int.MaxValue);

	return higher.Min;
}

int FindNextLower(SortedSet<int> indices, int value)
{
	SortedSet<int> lower = indices.GetViewBetween(int.MinValue, value);

	return lower.Max;
}