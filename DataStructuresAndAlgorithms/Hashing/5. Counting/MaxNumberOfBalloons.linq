<Query Kind="Program" />

/*
 * LeetCode 1189: Maximum Number of Balloons
 * 
 * Problem Description:
 * Given a string text, you want to use the characters of text to form as many instances of the word "balloon" as possible.
 * You can use each character in text at most once. Return the maximum number of instances that can be formed.
 * 
 * Example: Input: text = "loonbalxballpoon"
 *          Output: 2
 *          Explanation: The word "balloon" can be formed twice using the letters: "loonbalxballpoon"
 * 
 * Solution Explanation:
 * This solution uses a custom Entry struct with stack allocation for efficiency:
 * 1. Create 5 Entry structs on the stack (one for each unique letter in "balloon")
 * 2. Each Entry tracks ExpectedAmount (b=1, a=1, l=2, o=2, n=1) and actual Amount found
 * 3. Count occurrences of each relevant character in the text
 * 4. Calculate how many complete "balloon" words can be formed: Amount / ExpectedAmount
 * 5. Return the minimum value among all entries (the bottleneck character)
 * Using stackalloc Span<Entry> instead of heap allocation provides better performance.
 * Time Complexity: O(n), Space Complexity: O(1) since we use stack allocation
 */

void Main()
{
	string text = "loonbalxballpoon";
	MaxNumberOfBalloons(text).Dump();
}

public int MaxNumberOfBalloons(string text)
{
	Span<Entry> entries = stackalloc Entry[5] 
	{
		new Entry(1),
		new Entry(1),
		new Entry(2),
		new Entry(2),
		new Entry(1),
	};
	
	foreach (char symbol in text)
	{
		switch (symbol)
		{
			case 'b': entries[0].Amount++; break;
			case 'a': entries[1].Amount++; break;
			case 'l': entries[2].Amount++; break;
			case 'o': entries[3].Amount++; break;
			case 'n': entries[4].Amount++; break;
			default: break;
		}
	}
	
	int min = int.MaxValue;
	foreach (Entry entry in entries)
	{
		min = Math.Min(min, entry.Entries);
	}
	
	return min;
}

struct Entry
{
	public int ExpectedAmount { get; }
	public int Amount { get; set; }
	public int Entries => Amount / ExpectedAmount;
	
	public Entry(int expectedAmount)
	{
		ExpectedAmount = expectedAmount;
	}
}