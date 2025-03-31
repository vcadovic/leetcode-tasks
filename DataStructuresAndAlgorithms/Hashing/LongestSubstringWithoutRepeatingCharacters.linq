<Query Kind="Program" />

void Main()
{
	string s = "abcabcbb";
	LengthOfLongestSubstring(s).Dump();
}

// You can define other methods, fields, classes and namespaces here
public int LengthOfLongestSubstring(string s)
{
	if (s.Length == 1) return 1;

	List<char> usedSymbols = new();
	int max = 0, current = 0;

	for (int i = 0; i < s.Length; i++)
	{
		int index = usedSymbols.IndexOf(s[i]);

		if (index < 0)
		{
			current++;
			usedSymbols.Add(s[i]);
		}
		else
		{
			usedSymbols.RemoveRange(0, index + 1);
			usedSymbols.Add(s[i]);
			current = usedSymbols.Count;
		}

		max = Math.Max(max, current);
	}

	return max;
}