<Query Kind="Program" />

/*
 * LeetCode 236: Lowest Common Ancestor of a Binary Tree
 * 
 * Problem Description:
 * Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
 * The LCA is defined as the lowest node in the tree that has both p and q as descendants
 * (where we allow a node to be a descendant of itself).
 * 
 * Example: Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
 *          Output: 3
 *          Explanation: The LCA of nodes 5 and 1 is 3.
 * 
 * Solution Explanation:
 * This solution uses recursive DFS with bottom-up propagation:
 * 1. Base cases:
 *    - If current node is null, return null
 *    - If current node matches p or q, return current (found one target)
 * 2. Recursively search left and right subtrees
 * 3. Analyze results:
 *    - If both left and right return non-null: current node is LCA (p and q in different subtrees)
 *    - If only left returns non-null: LCA is in left subtree, return left
 *    - If only right returns non-null: LCA is in right subtree, return right
 * 4. The algorithm naturally finds the lowest (deepest) common ancestor
 * Time Complexity: O(n), Space Complexity: O(h) where h is tree height
 */

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
