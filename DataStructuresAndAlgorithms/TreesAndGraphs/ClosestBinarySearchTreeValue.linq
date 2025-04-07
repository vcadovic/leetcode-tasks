<Query Kind="Program" />

void Main()
{
	TreeNode root = 
		new(4,
			left: new(2,
				left: new(1),
				right: new(3)),
			right: new(5));
			
	ClosestValue(root, 3.5).Dump();
}

const double Epsilon = 1e-9;

public int ClosestValue(TreeNode root, double target) 
{
	int closest = root.val;
	
	while (root is not null)
	{
		double currentDiff = Math.Abs(root.val - target);
		double closestDiff = Math.Abs(closest - target);
		
		if (currentDiff < closestDiff ||
			(Equals(currentDiff, closestDiff) && root.val < closest))
		{
			closest = root.val;
		}
		
		root = target < root.val
			? root.left
			: root.right;
	}


	return closest;
}

bool Equals(double v1, double v2)
{
	return Math.Abs(v1 - v2) < Epsilon;
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