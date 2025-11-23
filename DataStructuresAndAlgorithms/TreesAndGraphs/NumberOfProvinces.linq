<Query Kind="Program" />

/*
 * LeetCode 547: Number of Provinces
 * 
 * Problem Description:
 * There are n cities. Some of them are connected, while some are not. If city a is connected
 * directly with city b, and city b is connected directly with city c, then city a is connected
 * indirectly with city c. A province is a group of directly or indirectly connected cities.
 * You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and
 * the jth city are directly connected, and isConnected[i][j] = 0 otherwise.
 * Return the total number of provinces.
 * 
 * Example: Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
 *          Output: 2
 *          Explanation: Cities 0 and 1 form one province, city 2 forms another
 * 
 * Solution Explanation:
 * This solution uses DFS to count connected components in an undirected graph:
 * 1. Build adjacency list from the connection matrix:
 *    - Only process upper triangle (i < j) since matrix is symmetric
 *    - For each connection, add edges in both directions
 * 2. Use DFS to find connected components:
 *    - Maintain a 'seen' array to track visited cities
 *    - For each unvisited city, increment province count and run DFS
 *    - DFS marks all cities in the same province as visited
 * 3. Return the count of connected components
 * Time Complexity: O(n²), Space Complexity: O(n) where n is number of cities
 */

void Main()
{
	int[][] isConnected = [[1, 1, 0], [1, 1, 0], [0, 0, 1]];
	FindCircleNum(isConnected).Dump();
}

public int FindCircleNum(int[][] isConnected)
{
	Dictionary<int, List<int>> graph = [];
	BuildGraph();

	bool[] seen = new bool[isConnected.Length];
	int result = 0;

	for (int i = 0; i < isConnected.Length; i++)
	{
		if (!seen[i])
		{
			result++;
			seen[i] = true;
			Dfs(i);
		}
	}

	return result;

	void BuildGraph()
	{
		for (int i = 0; i < isConnected.Length; i++)
		{
			graph.TryAdd(i, []);
			for (int j = i + 1; j < isConnected.Length; j++)
			{
				graph.TryAdd(j, []);
				if (isConnected[i][j] == 1)
				{
					graph[i].Add(j);
					graph[j].Add(i);
				}
			}
		}
	}

	void Dfs(int node)
	{
		foreach (int neighbour in graph[node])
		{
			if (!seen[neighbour])
			{
				seen[neighbour] = true;
				Dfs(neighbour);
			}
		}
	}
}

