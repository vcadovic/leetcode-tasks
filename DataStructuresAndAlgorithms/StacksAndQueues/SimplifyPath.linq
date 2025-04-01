<Query Kind="Program" />

void Main()
{ 
	string path = "/.../a/../b///cccc/../d/./";
	SimplifyPath(path).Dump();
}

public string SimplifyPath(string path)
{
	const string goBack = "..";
	const string goThis = ".";
	const string delimiter = "/";
	
	List<string> stack = new();
	
	var entries = path.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
	
	foreach (var entry in entries)
	{
		if (entry == goBack)
		{
			if (stack.Count != 0)
				stack.RemoveAt(stack.Count - 1);
		}
		else if (entry == goThis)
		{
			continue;
		}
		else
		{
			stack.Add(entry);
		}
	}
	
	return delimiter + string.Join(delimiter, stack);
}