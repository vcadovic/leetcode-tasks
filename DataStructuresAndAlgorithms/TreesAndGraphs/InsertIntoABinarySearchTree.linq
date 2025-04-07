<Query Kind="Program" />

void Main()
{
	TreeNode root = 
		new(4,
			left: new(2,
				left: new(1),
				right: new(4)),
			right: new(7));
			
	InsertIntoBST(root, 5).Dump();
}

public TreeNode InsertIntoBST(TreeNode root, int val) 
{
	if (root is null)
	{
		return new(val);
	}
	
	TreeNode current = root;
	
	while (true)
	{
		if (val > current.val)
		{
			if (current.right is null)
			{
				current.right = new(val);
				break;
			}
			current = current.right;
		}
		else if (val < current.val)
		{
			if (current.left is null)
			{
				current.left = new(val);
			}
			current = current.left;
		}
		else
		{
			break;
		}
	}
	
	return root;
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