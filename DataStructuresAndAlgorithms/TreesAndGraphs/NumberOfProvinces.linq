<Query Kind="Program" />

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

