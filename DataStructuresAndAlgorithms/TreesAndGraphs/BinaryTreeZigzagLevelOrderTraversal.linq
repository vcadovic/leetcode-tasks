<Query Kind="Program" />

/*
 * LeetCode 103: Binary Tree Zigzag Level Order Traversal
 * 
 * Problem Description:
 * Given the root of a binary tree, return the zigzag level order traversal of its nodes' values.
 * (i.e., from left to right, then right to left for the next level and alternate between).
 * 
 * Example: Input: root = [3,9,20,null,null,15,7]
 *          Output: [[3],[20,9],[15,7]]
 * 
 * Solution Explanation:
 * This solution uses BFS (Breadth-First Search) with level tracking and alternating insertion:
 * 1. Use a queue for standard level-order traversal
 * 2. Track whether current level is even or odd with isEvenLevel boolean
 * 3. For each level:
 *    - Process all nodes at current level (using levelSize to know how many)
 *    - If even level: insert values at the beginning of level list (right-to-left effect)
 *    - If odd level: append values at the end (left-to-right)
 * 4. Enqueue children in standard order (left then right) regardless of zigzag
 * 5. The alternating insertion strategy creates the zigzag pattern in results
 * Time Complexity: O(n), Space Complexity: O(n) where n is number of nodes
 */

void Main()
{
	TreeNode root =
		new(1,
			left: new(2,
				left: new(4,
					left: new(7)),
				right: new(5)),
			right: new(3,
				right: new(6,
					right: new(8))));

	ZigzagLevelOrder(root).Dump(); // 1 3 2 4 5 6 8 7
}

public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
{
	if (root is null)
	{
		return [];
	}

	IList<IList<int>> result = [];
	Queue<TreeNode> bfs = [];
	bfs.Enqueue(root);
	bool isEvenLevel = true;

	while (bfs.Count > 0)
	{
		isEvenLevel = !isEvenLevel;
		int levelSize = bfs.Count;
		IList<int> level = [];
		result.Add(level);
		while (levelSize-- > 0)
		{
			TreeNode current = bfs.Dequeue();

			if (isEvenLevel)
			{
				level.Insert(0, current.val);
			}
			else
			{
				level.Add(current.val);
			}

			EnqueueIfNotNull(current.left);
			EnqueueIfNotNull(current.right);
		}
	}

	return result;

	void EnqueueIfNotNull(TreeNode node)
	{
		if (node is not null)
		{
			bfs.Enqueue(node);
		}
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
