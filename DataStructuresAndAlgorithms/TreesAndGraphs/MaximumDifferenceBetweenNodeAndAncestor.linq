<Query Kind="Program" />

void Main()
{
	TreeNode root = new(8,
		left: new(3,
			left: new(1),
			right: new(6,
				left: new(4),
				right: new(7))),
		right: new(10,
			right: new(14,
				left: new(13))));

	MaxAncestorDiff(root).Dump();
}

public int MaxAncestorDiff(TreeNode root)
{
	return Dfs(root).Value.MaxSum;

	NodeResult? Dfs(TreeNode current)
	{
		if (current is null)
		{
			return null;
		}

		if (current.left is null && current.right is null)
		{
			return new(current.val);
		}

		return new(Dfs(current.left), Dfs(current.right), current.val);
	}
}

readonly struct NodeResult
{
	public int Min { get; }
	public int Max { get; }
	public int Root { get; }
	public int MaxSum { get; }

	public NodeResult(int root)
	{
		Min = int.MaxValue;
		Max = int.MinValue;
		MaxSum = int.MinValue;
		Root = root;
	}

	public NodeResult(NodeResult? left, NodeResult? right, int root)
	{
		int minChildRoot = Math.Min(left?.Root ?? int.MaxValue, right?.Root ?? int.MaxValue);
		int maxChildRoot = Math.Max(left?.Root ?? int.MinValue, right?.Root ?? int.MinValue);

		int minChild = Math.Min(left?.Min ?? int.MaxValue, right?.Min ?? int.MaxValue);
		int maxChild = Math.Max(left?.Max ?? int.MinValue, right?.Max ?? int.MinValue);

		Min = Math.Min(minChildRoot, minChild);
		Max = Math.Max(maxChildRoot, maxChild);
		Root = root;
		
		int maxSumChild = Math.Max(
			Math.Abs(Root - Max),
			Math.Abs(Root - Min));
			
		MaxSum = Math.Max(maxSumChild, Math.Max(left?.MaxSum ?? int.MinValue, right?.MaxSum ?? int.MinValue));
	}
}

//Definition for a binary tree node.
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