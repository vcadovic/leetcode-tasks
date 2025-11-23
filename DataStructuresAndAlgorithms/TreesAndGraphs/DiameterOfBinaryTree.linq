<Query Kind="Program" />

/*
 * LeetCode 543: Diameter of Binary Tree
 * 
 * Problem Description:
 * Given the root of a binary tree, return the length of the diameter of the tree.
 * The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
 * This path may or may not pass through the root. The length of a path between two nodes
 * is represented by the number of edges between them.
 * 
 * Example: Input: root = [1,2,3,4,5]
 *          Output: 3
 *          Explanation: The longest path is [4,2,1,3] or [5,2,1,3] with length 3
 * 
 * Solution Explanation:
 * This solution uses DFS with post-order traversal to calculate diameter:
 * 1. Use a NodeResult struct to track left and right radius (height) from each node
 * 2. For each node in DFS:
 *    - Recursively get left and right subtree radii
 *    - Add 1 to each radius to include edge to current node
 *    - Calculate diameter at this node: leftRadius + rightRadius (path through this node)
 *    - Update global maxDiameter if current diameter is larger
 * 3. Return NodeResult with the radii to parent
 * Key insight: diameter at any node = left height + right height; track maximum across all nodes.
 * Time Complexity: O(n), Space Complexity: O(h) where h is tree height (recursion stack)
 */

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
