<Query Kind="Program" />

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