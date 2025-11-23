<Query Kind="Program" />

/*
 * LeetCode 92: Reverse Linked List II
 * 
 * Problem Description:
 * Given the head of a singly linked list and two integers left and right where left <= right,
 * reverse the nodes of the list from position left to position right, and return the reversed list.
 * Positions are 1-indexed.
 * 
 * Example: Input: head = [1,2,3,4,5], left = 2, right = 4
 *          Output: [1,4,3,2,5]
 * 
 * Solution Explanation:
 * This solution uses recursion to navigate to the reversal start point and reverse the sublist:
 * 1. Use recursion to navigate to position left:
 *    - If left > 1, recurse with left-1 and right-1 on head.next
 * 2. When left == 1, start reversing using the Rec helper function:
 *    - Reverse 'count' nodes starting from current position
 *    - Track 'successor' - the node after the reversed section
 * 3. The Rec function reverses nodes by:
 *    - Base case: when count==1, save the successor and return current node
 *    - Recursive case: reverse remaining nodes, then link current node to end
 * 4. After reversing, connect the reversed section to its successor
 * This elegant recursive approach handles the reversal without explicit iteration.
 * Time Complexity: O(n), Space Complexity: O(n) due to recursion stack
 */

void Main()
{
	ListNode head =
		new(1,
			new(2,
				new(3,
					new(4,
						new(5)))));

	int left = 2, right = 4;

	ReverseBetween(head, left, right).Dump();
}

public ListNode ReverseBetween(ListNode head, int left, int right)
{
	ListNode successor = null;
	if (left == 1)
	{
		return Rec(head, right);
	}

	head.next = ReverseBetween(head.next, left - 1, right - 1);

	return head;

	ListNode Rec(ListNode head, int count)
	{
		if (count == 1)
		{
			successor = head.next;
			return head;
		}

		ListNode newHead = Rec(head.next, count - 1);

		head.next.next = head;
		head.next = successor;

		return newHead;
	}
}

//Definition for singly-linked list.
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}
