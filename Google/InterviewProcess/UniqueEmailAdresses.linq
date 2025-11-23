<Query Kind="Program" />

/*
 * LeetCode 929: Unique Email Addresses
 * 
 * Problem Description:
 * Every valid email consists of a local name and a domain name, separated by the '@' sign.
 * Besides lowercase letters, the email may contain one or more '.' or '+'.
 * - If you add periods '.' between some characters in the local name part of an email address,
 *   mail sent there will be forwarded to the same address without dots in the local name.
 *   This rule does not apply to domain names.
 * - If you add a plus '+' in the local name, everything after the first plus sign will be ignored.
 *   This allows certain emails to be filtered. This rule does not apply to domain names.
 * Given a list of emails, return the number of different addresses that actually receive mails.
 * 
 * Example: Input: emails = ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com"]
 *          Output: 2
 *          Explanation: "testemail@leetcode.com" and "testemail@leetcode.com" are the same (2 different actual addresses).
 * 
 * Solution Explanation:
 * This solution uses LINQ to normalize and count unique email addresses:
 * 1. Split each email by '@' to separate local name and domain
 * 2. Normalize the local name:
 *    - Split by '+' and take first part (ignore everything after '+')
 *    - Remove all '.' characters
 * 3. Keep domain name as-is (no normalization rules apply)
 * 4. Reconstruct normalized email: localName@domainName
 * 5. Use Distinct() to eliminate duplicates
 * 6. Count unique normalized addresses
 * This functional LINQ approach is concise and readable.
 * Time Complexity: O(n * m) where m is average email length, Space Complexity: O(n)
 */

void Main()
{
	string[] emails = ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"];
	NumUniqueEmails(emails).Dump();
}

public int NumUniqueEmails(string[] emails)
{
	var actualReceivers = emails
		.Select(e => e.Split('@'))
		.Select(e => new
		{
			LocalName = e.First().Split('+').First().Replace(".", string.Empty),
			DomainName = e.Last()
		})
		.Select(e => $"{e.LocalName}@{e.DomainName}")
		.Distinct();

	return actualReceivers.Count();
}