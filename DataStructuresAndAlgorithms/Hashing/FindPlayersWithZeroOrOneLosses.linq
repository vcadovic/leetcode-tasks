<Query Kind="Program" />

void Main()
{
	int[][] matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]];
	
	FindWinners(matches).Dump();
}

public IList<IList<int>> FindWinners(int[][] matches)
{
	IList<IList<int>> result = [[], []];
	SortedDictionary<int, int> losesMap = [];
	
	foreach (int[] match in matches)
	{
		int winner = match[0];
		int loser = match[1];
		
		losesMap.TryAdd(winner, 0);
		losesMap.TryAdd(loser, 0);
		
		losesMap[loser]++;
	}
	
	foreach (var player in losesMap)
	{
		if (player.Value <= 1)
		{
			result[player.Value].Add(player.Key);
		}
	}
	
	return result;
}