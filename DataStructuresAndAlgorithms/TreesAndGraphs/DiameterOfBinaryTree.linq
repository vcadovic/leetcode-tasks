<Query Kind="Program" />

void Main()
{
	TreeNode root = new(0,
		left: new(1,
			left: new(3,
				left: new(5),
				right: new(6,
					left: new(9))),
			right: new(4,
				left: new(7),
				right: new(8,
					left: new(10),
					right: new(11,
						left: new(12))))),
		right: new(2,
			left: new()));
			
	DiameterOfBinaryTree(root).Dump();
}

public int DiameterOfBinaryTree(TreeNode root) 
{
	int maxDiameter = 0;
	Dfs(root);
	return maxDiameter;
	
	NodeResult Dfs(TreeNode current)
	{		
		int leftRadius = 0, rightRadius = 0;
		
		if (current.left is not null)
		{
			leftRadius = Dfs(current.left).MaxRadius + 1;
		}
		
		if (current.right is not null)
		{
			rightRadius = Dfs(current.right).MaxRadius + 1;
		}
		
		NodeResult result = new(leftRadius, rightRadius);
		maxDiameter = Math.Max(maxDiameter, result.Diameter);
		
		return result;
	}
}

struct NodeResult
{
	public int LeftRadius { get; }
	public int RightRadius { get; }
	public int MaxRadius => Math.Max(LeftRadius, RightRadius);
	public int Diameter => LeftRadius + RightRadius;
	
	public NodeResult(int leftRadius, int rightRadius)
	{
		LeftRadius = leftRadius;
		RightRadius = rightRadius;
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
