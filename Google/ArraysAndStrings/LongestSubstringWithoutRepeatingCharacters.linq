<Query Kind="Program" />

/*
 * LeetCode 3: Longest Substring Without Repeating Characters
 * 
 * Problem Description:
 * Given a string s, find the length of the longest substring without repeating characters.
 * 
 * Example: Input: s = "abcabcbb"
 *          Output: 3
 *          Explanation: The answer is "abc", with the length of 3.
 * 
 * Solution Explanation:
 * This solution uses a sliding window with a list to track current substring:
 * 1. Maintain a list (usedSymbols) containing characters in current window
 * 2. For each character in the string:
 *    - Check if it exists in usedSymbols using IndexOf
 *    - If not found (index < 0):
 *      * Add character to window
 *      * Increment current length
 *    - If found (repeating character):
 *      * Remove all characters from start up to and including the duplicate
 *      * Add current character
 *      * Update current length to new window size
 * 3. Track maximum length seen across all windows
 * Using a list allows easy removal of prefix when duplicate is found.
 * Time Complexity: O(n²) due to IndexOf and RemoveRange, Space Complexity: O(min(n, m))
 */

void Main()
{
	string s = "abcabcbb";
	LengthOfLongestSubstring(s).Dump();
}

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
