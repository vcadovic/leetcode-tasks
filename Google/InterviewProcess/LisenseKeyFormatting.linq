<Query Kind="Program" />

/*
 * LeetCode 482: License Key Formatting
 * 
 * Problem Description:
 * You are given a license key represented as a string s that consists of only alphanumeric characters and dashes.
 * The string is separated into n+1 groups by n dashes. You are also given an integer k.
 * We want to reformat the string s such that each group contains exactly k characters, except for the first group,
 * which could be shorter than k but still must contain at least one character. Furthermore, there must be a dash
 * inserted between two groups, and you should convert all lowercase letters to uppercase.
 * Return the reformatted license key.
 * 
 * Example: Input: s = "5F3Z-2e-9-w", k = 4
 *          Output: "5F3Z-2E9W"
 *          Explanation: The string s has been split into two parts, each part has 4 characters.
 * 
 * Solution Explanation:
 * This solution reformats the license key in three steps:
 * 1. Preprocessing:
 *    - Remove all dashes
 *    - Convert to uppercase
 * 2. Calculate first group size using modulo:
 *    - firstLen = rawText.Length % k
 *    - This ensures all subsequent groups have exactly k characters
 *    - If firstLen is 0, first group will also have k characters
 * 3. Build result with StringBuilder:
 *    - Add first group (if not empty) with dash
 *    - Add remaining groups of k characters each with dashes
 *    - Remove trailing dash from result
 * Time Complexity: O(n), Space Complexity: O(n)
 */

void Main()
{
	string s = "5F3Z-2e-9-w";
	int k = 4;
	
	LicenseKeyFormatting(s, k).Dump();
}

public string LicenseKeyFormatting(string s, int k)
{
	string rawText = s.Replace("-", string.Empty).ToUpper();

	if (rawText.Length == 0) return string.Empty;

	StringBuilder result = new();
	int firstLen = rawText.Length % k;

	if (firstLen != 0)
	{
		result.Append(rawText.Substring(0, firstLen));
		result.Append("-");
	}

	for (int i = firstLen; i < rawText.Length; i += k)
	{
		result.Append(rawText.Substring(i, k));
		result.Append("-");
	}

	return result.ToString().Substring(0, result.Length - 1);
}