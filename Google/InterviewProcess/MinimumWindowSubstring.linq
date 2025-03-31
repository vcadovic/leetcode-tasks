<Query Kind="Program" />

void Main()
{
	string s = "aaaaaaaaaaaabbbbbcdd", t = "abcdd";
	MinWindow(s, t).Dump();
}

public string MinWindow(string input, string template)
{
	if (input.Length == 0 || template.Length == 0)
	{
		return string.Empty;
	}

	Dictionary<char, int> templateSymbolsMap = template
		.GroupBy(c => c)
		.ToDictionary(g => g.Key, g => g.Count());

	Dictionary<char, int> windowTemplateSymbolsMap = [];

	List<(int Index, char Symbol)> templateSymbolsInInput = input
		.Select((c, i) => (i, c))
		.Where(p => templateSymbolsMap.ContainsKey(p.c))
		.ToList();

	Status currentStatus = new();

	int leftPtr = 0, rightPtr = 0;
	int currentSymbolsInWindow = 0;
	int allSymbols = templateSymbolsMap.Count();

	while (rightPtr < templateSymbolsInInput.Count)
	{
		char currentSymbol = templateSymbolsInInput[rightPtr].Symbol;
		windowTemplateSymbolsMap.TryGetValue(currentSymbol, out int countInCurrentWindow);
		windowTemplateSymbolsMap[currentSymbol] = countInCurrentWindow + 1;

		if (templateSymbolsMap.ContainsKey(currentSymbol)
			&& windowTemplateSymbolsMap[currentSymbol] == templateSymbolsMap[currentSymbol])
		{
			currentSymbolsInWindow++;
		}

		while (leftPtr <= rightPtr && currentSymbolsInWindow == allSymbols)
		{
			currentSymbol = templateSymbolsInInput[leftPtr].Symbol;
			int startPtr = templateSymbolsInInput[leftPtr].Index;
			int endPtr = templateSymbolsInInput[rightPtr].Index;

			int windowSize = endPtr - startPtr + 1;

			if (!currentStatus.Length.HasValue || windowSize < currentStatus.Length)
			{
				currentStatus.Length = windowSize;
				currentStatus.Start = startPtr;
				currentStatus.End = endPtr;
			}

			windowTemplateSymbolsMap[currentSymbol]--;

			if (templateSymbolsMap.ContainsKey(currentSymbol)
				&& windowTemplateSymbolsMap[currentSymbol] < templateSymbolsMap[currentSymbol])
			{
				currentSymbolsInWindow--;
			}
			
			leftPtr++;
		}
		
		rightPtr++;
	}

	return currentStatus.Length.HasValue
		? input[currentStatus.Start..(currentStatus.End + 1)]
		: string.Empty;
}

class Status
{
	public int? Length { get; set; }
	public int Start { get; set; }
	public int End { get; set; }
}