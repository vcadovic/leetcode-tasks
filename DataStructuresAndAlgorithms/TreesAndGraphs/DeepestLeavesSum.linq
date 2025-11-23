<Query Kind="Program" />

/*
 * LeetCode 1302: Deepest Leaves Sum
 * 
 * Problem Description:
 * Given the root of a binary tree, return the sum of values of its deepest leaves.
 * 
 * Example: Input: root = [1,2,3,4,5,null,6,7,null,null,null,null,8]
 *          Output: 15
 *          Explanation: The deepest leaves are nodes with values 7 and 8, sum = 15
 * 
 * Solution Explanation:
 * This solution uses BFS (level-order traversal) to identify the deepest level:
 * 1. Use a queue for level-by-level traversal
 * 2. For each level:
 *    - Reset result to 0 (assuming current level might be deepest)
 *    - Process all nodes at this level (using levelSize)
 *    - Add all node values at this level to result
 *    - Enqueue children for next level
 * 3. When queue is empty, the last level processed was the deepest
 * 4. Return the sum accumulated during the last level
 * The key insight: keep overwriting result with each level's sum until no more levels exist.
 * Time Complexity: O(n), Space Complexity: O(w) where w is maximum tree width
 */

void Main()
{
	TreeNode root = new(1,
		left: new(2,
			left: new(4,
				left: new(7)),
			right: new(5)),
		right: new(3,
			right: new(6,
				right: new(8))));
				
	DeepestLeavesSum(root).Dump();
}

public int DeepestLeavesSum(TreeNode root) 
{
	int result = 0;
	Queue<TreeNode> bfs = [];
	bfs.Enqueue(root);
	
	while (bfs.Count > 0)
	{
		result = 0;
		int levelSize = bfs.Count;
		while (levelSize-- > 0)
		{
			TreeNode current = bfs.Dequeue();
			if (current.left is not null)
			{
				bfs.Enqueue(current.left);
			}
			if (current.right is not null)
			{
				bfs.Enqueue(current.right);
			}
			result += current.val;
		}
	}
	
	return result;
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
