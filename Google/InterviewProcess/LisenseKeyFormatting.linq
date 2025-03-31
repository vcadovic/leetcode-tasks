<Query Kind="Program" />

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