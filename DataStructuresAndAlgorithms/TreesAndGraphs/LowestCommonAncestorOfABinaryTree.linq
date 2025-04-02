<Query Kind="Program" />

void Main()
{
	TreeNode root = new(3,
		left: new(5,
			left: new(6),
			right: new(2,
				left: new(7),
				right: new(4))),
		right: new(1,
			left: new(0),
			right: new(8)));

	LowestCommonAncestor(root, new(5), new(2)).Dump();
}

public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
{
	return Dfs(root);
	
	TreeNode Dfs(TreeNode current)
	{
		if (current is null) return null;
		if (current.val == p.val || current.val == q.val) return current;
		
		var left = Dfs(current.left);
		var right = Dfs(current.right);
		
		if (left is not null && right is not null) return current;
		if (left is not null) return left;
		
		return right;
	}
}

//Definition for a binary tree node.
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }

	public TreeNode(int x, TreeNode left, TreeNode right) : this(x)
	{
		this.left = left;
		this.right = right;
	}
}
