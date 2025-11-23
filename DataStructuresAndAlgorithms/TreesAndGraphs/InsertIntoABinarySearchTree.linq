<Query Kind="Program" />

/*
 * LeetCode 701: Insert into a Binary Search Tree
 * 
 * Problem Description:
 * You are given the root node of a binary search tree (BST) and a value to insert into the tree.
 * Return the root node of the BST after the insertion. It is guaranteed that the new value does not
 * exist in the original BST.
 * 
 * Example: Input: root = [4,2,7,1,3], val = 5
 *          Output: [4,2,7,1,3,5]
 *          Explanation: Insert 5 as right child of 3, or left child of 7
 * 
 * Solution Explanation:
 * This solution uses iterative BST insertion:
 * 1. Handle edge case: if root is null, return new node with val
 * 2. Navigate to insertion point using BST property:
 *    - If val > current.val: go right
 *    - If val < current.val: go left
 *    - If val == current.val: value already exists, stop
 * 3. When reaching a null child position, create new node there
 * 4. Return the original root (tree structure modified in place)
 * This iterative approach avoids recursion overhead while maintaining BST property.
 * Time Complexity: O(h) where h is tree height, Space Complexity: O(1)
 */

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