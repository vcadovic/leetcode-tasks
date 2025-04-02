<Query Kind="Program" />

void Main()
{
	TreeNode root = new(3,
		left: new(9),
		right: new(20,
			left: new(15),
			right: new(7)));

	MinDepth(root).Dump();

	root = new(2,
		right: new(3,
			right: new(4,
				right: new(5,
					right: new(6)))));
				
	MinDepth(root).Dump();
}

public int MinDepth(TreeNode root)
{
	if (root == null) return 0;
	if (root.left == null) return MinDepth(root.right) + 1;
	if (root.right == null) return MinDepth(root.left) + 1;
	
	int leftDepth = MinDepth(root.left);
	int rightDepth = MinDepth(root.right);
	
	return Math.Min(leftDepth, rightDepth) + 1;
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
