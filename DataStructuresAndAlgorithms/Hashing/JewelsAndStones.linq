<Query Kind="Program" />

void Main()
{
	string jewels = "aA", stones = "aAAbbbb";
	NumJewelsInStones(jewels, stones).Dump();
}

public int NumJewelsInStones(string jewels, string stones)
{
	int result = 0;
	Dictionary<char, int> stonesMap = stones
		.GroupBy(s => s)
		.ToDictionary(g => g.Key, g => g.Count());
	
	foreach (var item in jewels)
	{
		result += stonesMap.GetValueOrDefault(item);
	}
	
	return result;
}