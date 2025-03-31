<Query Kind="Program" />

void Main()
{
	int[] arr = [1,2,3];
	
	CountElements(arr).Dump();
}

public int CountElements(int[] arr)
{
	HashSet<int> uniques = arr.ToHashSet(); // O(n)
	
	return arr.Where(n => uniques.Contains(n + 1)).Count(); // O(n)
	
	// overall: O(2n) => O(n).
	// additional memory: O(n).
}