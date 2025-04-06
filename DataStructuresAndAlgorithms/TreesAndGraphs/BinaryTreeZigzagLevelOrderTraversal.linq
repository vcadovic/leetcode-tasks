<Query Kind="Program" />

void Main()
{
	TreeNode root =
		new(1,
			left: new(2,
				left: new(4,
					left: new(7)),
				right: new(5)),
			right: new(3,
				right: new(6,
					right: new(8))));

	ZigzagLevelOrder(root).Dump(); // 1 3 2 4 5 6 8 7
}

public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
{
	if (root is null)
	{
		return [];
	}

	IList<IList<int>> result = [];
	Queue<TreeNode> bfs = [];
	bfs.Enqueue(root);
	bool isEvenLevel = true;

	while (bfs.Count > 0)
	{
		isEvenLevel = !isEvenLevel;
		int levelSize = bfs.Count;
		IList<int> level = [];
		result.Add(level);
		while (levelSize-- > 0)
		{
			TreeNode current = bfs.Dequeue();

			if (isEvenLevel)
			{
				level.Insert(0, current.val);
			}
			else
			{
				level.Add(current.val);
			}

			EnqueueIfNotNull(current.left);
			EnqueueIfNotNull(current.right);
		}
	}

	return result;

	void EnqueueIfNotNull(TreeNode node)
	{
		if (node is not null)
		{
			bfs.Enqueue(node);
		}
	}
}

// Definition for a binary tree node.
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
	{
		this.val = val;
		this.left = left;
		this.right = right;
	}
}
