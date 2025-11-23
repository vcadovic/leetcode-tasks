<Query Kind="Program" />

/*
 * LeetCode 270: Closest Binary Search Tree Value
 * 
 * Problem Description:
 * Given the root of a binary search tree and a target value, return the value in the BST
 * that is closest to the target. If there are multiple answers, return any of them.
 * 
 * Example: Input: root = [4,2,5,1,3], target = 3.714286
 *          Output: 4
 * 
 * Solution Explanation:
 * This solution leverages BST properties for efficient traversal:
 * 1. Start at root, initialize closest with root value
 * 2. At each node, calculate the difference between node value and target
 * 3. Update closest if:
 *    - Current difference is smaller, OR
 *    - Differences are equal (within epsilon) and current value is smaller
 * 4. Navigate using BST property:
 *    - If target < node.val, go left (smaller values)
 *    - Otherwise, go right (larger values)
 * 5. Continue until reaching a leaf
 * This avoids searching the entire tree, using BST ordering to prune paths.
 * Time Complexity: O(h) where h is tree height, Space Complexity: O(1)
 */

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