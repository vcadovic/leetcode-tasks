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
 * This solution uses sliding window with a hash map:
 * 1. Use a dictionary to store each character's next valid index (index + 1)
 * 2. Maintain left pointer for the start of the current window
 * 3. For each character (right pointer):
 *    - If character was seen before, move left to max(current left, character's stored next index)
 *    - This handles cases where the repeated char is outside current window
 * 4. Calculate current window length and update maxLen
 * 5. Store the next valid index for this character (right + 1)
 * The key insight: when we find a repeat, we don't need to move left one-by-one; we can jump directly.
 * Time Complexity: O(n), Space Complexity: O(min(n, m)) where m is charset size
 */

void Main()
{
	string s = "abcabcbb";
	LengthOfLongestSubstring(s).Dump();
}

public int LengthOfLongestSubstring(string s)
{
	Dictionary<char, int> charToNextIndex = [];
	int maxLen = 0, left = 0;

	for (int right = 0; right < s.Length; right++)
	{
		if (charToNextIndex.ContainsKey(s[right]))
		{
			left = Math.Max(charToNextIndex[s[right]], left);
		}

		maxLen = Math.Max(maxLen, right - left + 1);
		charToNextIndex[s[right]] = right + 1;
	}

	return maxLen;
}