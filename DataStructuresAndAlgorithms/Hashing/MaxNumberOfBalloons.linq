<Query Kind="Program" />

void Main()
{
	string text = "loonbalxballpoon";
	MaxNumberOfBalloons(text).Dump();
}

public int MaxNumberOfBalloons(string text)
{
	Span<Entry> entries = stackalloc Entry[5] 
	{
		new Entry(1),
		new Entry(1),
		new Entry(2),
		new Entry(2),
		new Entry(1),
	};
	
	foreach (char symbol in text)
	{
		switch (symbol)
		{
			case 'b': entries[0].Amount++; break;
			case 'a': entries[1].Amount++; break;
			case 'l': entries[2].Amount++; break;
			case 'o': entries[3].Amount++; break;
			case 'n': entries[4].Amount++; break;
			default: break;
		}
	}
	
	int min = int.MaxValue;
	foreach (Entry entry in entries)
	{
		min = Math.Min(min, entry.Entries);
	}
	
	return min;
}

struct Entry
{
	public int ExpectedAmount { get; }
	public int Amount { get; set; }
	public int Entries => Amount / ExpectedAmount;
	
	public Entry(int expectedAmount)
	{
		ExpectedAmount = expectedAmount;
	}
}