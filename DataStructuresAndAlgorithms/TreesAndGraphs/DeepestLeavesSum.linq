<Query Kind="Program" />

void Main()
{
	TreeNode root = new(1,
		left: new(2,
			left: new(4,
				left: new(7)),
			right: new(5)),
		right: new(3,
			right: new(6,
				right: new(8))));
				
	DeepestLeavesSum(root).Dump();
}

public int DeepestLeavesSum(TreeNode root) 
{
	int result = 0;
	Queue<TreeNode> bfs = [];
	bfs.Enqueue(root);
	
	while (bfs.Count > 0)
	{
		result = 0;
		int levelSize = bfs.Count;
		while (levelSize-- > 0)
		{
			TreeNode current = bfs.Dequeue();
			if (current.left is not null)
			{
				bfs.Enqueue(current.left);
			}
			if (current.right is not null)
			{
				bfs.Enqueue(current.right);
			}
			result += current.val;
		}
	}
	
	return result;
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
