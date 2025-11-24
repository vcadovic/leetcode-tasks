<Query Kind="Program" />

/*
 * LeetCode 383: Ransom Note
 * 
 * Problem Description:
 * Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using
 * the letters from magazine and false otherwise.
 * Each letter in magazine can only be used once in ransomNote.
 * 
 * Example: Input: ransomNote = "aa", magazine = "aab"
 *          Output: true
 *          Explanation: The magazine has two 'a's and one 'b', which is enough to construct "aa".
 * 
 * Solution Explanation:
 * This solution uses frequency maps (dictionaries) to compare character counts:
 * 1. Create frequency map for ransomNote (how many of each character needed)
 * 2. Create frequency map for magazine (how many of each character available)
 * 3. For each character in ransomNote's frequency map:
 *    - Check if it exists in magazine's frequency map
 *    - Check if the count in magazine is >= count needed in ransomNote
 * 4. Return true only if all characters can be satisfied
 * Using LINQ's GroupBy and ToDictionary provides a clean, functional approach to counting.
 * Time Complexity: O(m + n), Space Complexity: O(1) since there are at most 26 lowercase letters
 */

void Main()
{
	string ransomNote = "aa", magazine = "aab";
	CanConstruct(ransomNote, magazine).Dump();
}

public bool CanConstruct(string ransomNote, string magazine)
{
	var ransomNoteLettersMap = CountLetters(ransomNote);
	var magazineLettersMap = CountLetters(magazine);

	return ransomNoteLettersMap.All(l => magazineLettersMap.TryGetValue(l.Key, out var count) && count >= l.Value);
}

private Dictionary<char, int> CountLetters(string text) => text
	.GroupBy(c => c)
	.ToDictionary(g => g.Key, g => g.Count());