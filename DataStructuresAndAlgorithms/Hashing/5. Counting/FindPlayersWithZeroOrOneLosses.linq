<Query Kind="Program" />

/*
 * LeetCode 2225: Find Players With Zero or One Losses
 * 
 * Problem Description:
 * You are given an integer array matches where matches[i] = [winneri, loseri] indicates that
 * the player winneri defeated player loseri in a match.
 * Return a list answer of size 2 where:
 * - answer[0] is a list of all players that have not lost any matches.
 * - answer[1] is a list of all players that have lost exactly one match.
 * The values in the two lists should be returned in increasing order.
 * 
 * Example: Input: matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]
 *          Output: [[1,2,10],[4,5,7,8,9]]
 * 
 * Solution Explanation:
 * This solution uses a SortedDictionary for automatic sorting:
 * 1. Create a SortedDictionary to track loss count for each player
 * 2. For each match, ensure both winner and loser are in the map (initialize with 0)
 * 3. Increment the loser's count
 * 4. Iterate through the sorted dictionary and separate players by loss count:
 *    - Players with 0 losses go to result[0]
 *    - Players with 1 loss go to result[1]
 * Using SortedDictionary ensures the results are automatically sorted.
 * Time Complexity: O(n log n) for sorting, Space Complexity: O(n)
 */

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