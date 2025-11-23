<Query Kind="Program" />

/*
 * LeetCode 1026: Maximum Difference Between Node and Ancestor
 * 
 * Problem Description:
 * Given the root of a binary tree, find the maximum value v for which there exist different nodes
 * a and b where v = |a.val - b.val| and a is an ancestor of b.
 * A node a is an ancestor of b if either: a is a parent of b or a is an ancestor of a parent of b.
 * 
 * Example: Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
 *          Output: 7
 *          Explanation: Various ancestor-node differences exist, maximum is |8 - 1| = 7
 * 
 * Solution Explanation:
 * This solution uses DFS with a custom NodeResult struct to track min/max values:
 * 1. For each node, calculate and propagate:
 *    - Min: minimum value in the subtree (including current root)
 *    - Max: maximum value in the subtree (including current root)
 *    - MaxSum: maximum ancestor-descendant difference found in subtree
 * 2. For leaf nodes: initialize with default values
 * 3. For internal nodes:
 *    - Collect min/max from both subtrees
 *    - Calculate difference between current root and subtree extremes
 *    - Compare with MaxSum from subtrees
 *    - Propagate the overall maximum upward
 * 4. Return MaxSum from root
 * Time Complexity: O(n), Space Complexity: O(h) where h is tree height
 */

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