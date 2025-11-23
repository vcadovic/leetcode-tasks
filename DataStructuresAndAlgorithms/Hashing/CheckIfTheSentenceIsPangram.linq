<Query Kind="Program" />

/*
 * LeetCode 1832: Check if the Sentence Is Pangram
 * 
 * Problem Description:
 * A pangram is a sentence where every letter of the English alphabet appears at least once.
 * Given a string sentence containing only lowercase English letters, return true if sentence is a pangram,
 * or false otherwise.
 * 
 * Example: Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
 *          Output: true
 *          Explanation: The sentence contains at least one of every letter of the English alphabet.
 * 
 * Solution Explanation:
 * This solution uses a HashSet to track unique characters:
 * 1. Create a HashSet to store unique characters encountered
 * 2. Maintain a counter to track how many unique characters we've seen
 * 3. Iterate through each character in the sentence
 * 4. When Add() returns true (new character), increment the counter
 * 5. Check if counter equals 26 (number of letters in English alphabet)
 * Using HashSet's Add() return value is more efficient than checking Contains() first.
 * Time Complexity: O(n), Space Complexity: O(1) since HashSet can have at most 26 characters
 */

void Main()
{
	string sentence = "thequickbrownfoxjumpsoverthelazydog";
	CheckIfPangram(sentence).Dump();
}

public bool CheckIfPangram(string sentence)
{
	HashSet<char> entrancesSet = [];
	int counter = 0;
	const int lettersInEnglishAlphabet = 26;
	
	foreach (char symbol in sentence)
	{
		if (entrancesSet.Add(symbol))
		{
			counter++;
		}
	}
	
	return counter == lettersInEnglishAlphabet;
}