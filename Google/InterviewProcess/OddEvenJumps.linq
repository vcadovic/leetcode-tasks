<Query Kind="Program" />

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