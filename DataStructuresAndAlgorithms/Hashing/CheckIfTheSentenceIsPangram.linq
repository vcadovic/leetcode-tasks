<Query Kind="Program" />

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