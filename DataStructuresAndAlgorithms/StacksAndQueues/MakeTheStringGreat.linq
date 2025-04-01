<Query Kind="Program" />

void Main()
{
	string s = "abBAcC";
	
	MakeGood(s).Dump();
}

public string MakeGood(string s)
{
	List<char> stack = [];

	foreach (char symbol in s)
	{
		char peek = stack.LastOrDefault();

		if (peek == symbol)
		{
			stack.Add(peek);
			continue;
		}

		bool peekIsLower = char.IsLower(peek);
		bool currentIsLower = char.IsLower(symbol);
		bool charsEqualIgnoreCase = char.ToLower(peek) == char.ToLower(symbol);
		
		if ((peekIsLower ^ currentIsLower) && charsEqualIgnoreCase)
		{
			stack.RemoveAt(stack.Count - 1);
		}
		else
		{
			stack.Add(symbol);
		}
	}

	return string.Join(string.Empty, stack);
}