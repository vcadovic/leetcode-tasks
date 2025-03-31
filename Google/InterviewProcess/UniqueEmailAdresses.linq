<Query Kind="Program" />

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