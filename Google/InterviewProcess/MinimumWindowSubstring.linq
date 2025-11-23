<Query Kind="Program" />

/*
 * LeetCode 76: Minimum Window Substring
 * 
 * Problem Description:
 * Given two strings s and t of lengths m and n respectively, return the minimum window substring of s
 * such that every character in t (including duplicates) is included in the window.
 * If there is no such substring, return the empty string "".
 * A substring is a contiguous sequence of characters within the string.
 * 
 * Example: Input: s = "ADOBECODEBANC", t = "ABC"
 *          Output: "BANC"
 *          Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
 * 
 * Solution Explanation:
 * This solution uses the sliding window technique with two pointers:
 * 1. Preprocessing:
 *    - Create frequency map for template characters
 *    - Filter input to only include template-relevant characters with their indices
 * 2. Expand window (right pointer):
 *    - Add characters to window frequency map
 *    - When a character's count matches template count, increment currentSymbolsInWindow
 * 3. Contract window (left pointer) when all symbols found:
 *    - Track minimum window size and its boundaries
 *    - Remove characters from left until window becomes invalid
 *    - This ensures we find the minimal window
 * 4. Return the substring at tracked boundaries or empty string
 * The optimization of filtering input reduces unnecessary iterations.
 * Time Complexity: O(m + n), Space Complexity: O(m + n)
 */

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