<Query Kind="Program" />

/*
 * LeetCode 111: Minimum Depth of Binary Tree
 * 
 * Problem Description:
 * Given a binary tree, find its minimum depth.
 * The minimum depth is the number of nodes along the shortest path from the root node
 * down to the nearest leaf node.
 * Note: A leaf is a node with no children.
 * 
 * Example: Input: root = [3,9,20,null,null,15,7]
 *          Output: 2
 *          Explanation: The shortest path is 3 -> 9 (2 nodes)
 * 
 * Solution Explanation:
 * This solution uses recursive DFS with special handling for unbalanced trees:
 * 1. Base case: if root is null, return 0
 * 2. Handle unbalanced subtrees:
 *    - If left is null: minimum depth is through right subtree + 1
 *    - If right is null: minimum depth is through left subtree + 1
 *    - This is crucial: a node with only one child is NOT a leaf
 * 3. For nodes with both children:
 *    - Recursively get depth of both subtrees
 *    - Return minimum of the two + 1 (current node)
 * 4. This correctly finds the depth to the nearest leaf (not just shortest path to null)
 * Time Complexity: O(n), Space Complexity: O(h) where h is tree height
 */

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
