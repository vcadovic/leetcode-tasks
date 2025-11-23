<Query Kind="Program" />

/*
 * LeetCode 1544: Make The String Great
 * 
 * Problem Description:
 * Given a string s of lower and upper case English letters.
 * A good string is a string which doesn't have two adjacent characters s[i] and s[i+1] where:
 * - 0 <= i <= s.length - 2
 * - s[i] is a lower-case letter and s[i+1] is the same letter but in upper-case or vice-versa.
 * To make the string good, you can choose two adjacent characters that make the string bad and remove them.
 * Keep doing this until the string becomes good. Return the string after making it good.
 * 
 * Example: Input: s = "abBAcC"
 *          Output: ""
 *          Explanation: We have many possible scenarios: "abBAcC" → "aAcC" → "cC" → ""
 * 
 * Solution Explanation:
 * This solution uses a stack to efficiently remove adjacent bad pairs:
 * 1. Use a List as a stack to build the result
 * 2. For each character in the string:
 *    - Peek at the top of stack (if exists)
 *    - Check if current and peek are same letter but different case using XOR:
 *      * peekIsLower XOR currentIsLower ensures different cases
 *      * char.ToLower comparison ensures same letter
 *    - If they form a bad pair, pop the stack (remove the bad pair)
 *    - Otherwise, push current character
 * 3. Join the remaining characters into the result string
 * Time Complexity: O(n), Space Complexity: O(n)
 */

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
		char peek = stack.Count > 0 ? stack[stack.Count - 1] : default;

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