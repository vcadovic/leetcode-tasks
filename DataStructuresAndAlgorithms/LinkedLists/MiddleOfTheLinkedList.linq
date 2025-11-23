<Query Kind="Program" />

/*
 * LeetCode 876: Middle of the Linked List
 * 
 * Problem Description:
 * Given the head of a singly linked list, return the middle node of the linked list.
 * If there are two middle nodes, return the second middle node.
 * 
 * Example: Input: head = [1,2,3,4,5]
 *          Output: [3,4,5]
 *          Explanation: The middle node of the list is node 3.
 * 
 * Solution Explanation:
 * This solution uses the classic two-pointer (fast and slow) technique:
 * 1. Initialize two pointers (step1x and step2x) both pointing to head
 * 2. Move step2x at 2x speed and step1x at 1x speed
 * 3. When step2x reaches the end, step1x will be at the middle
 * 4. Handle two cases:
 *    - If step2x.next is null (odd length): return step1x
 *    - If step2x.next.next is null (even length): return step1x.next (second middle)
 * This approach finds the middle in a single pass without needing to know the list length.
 * Time Complexity: O(n), Space Complexity: O(1)
 */

void Main()
{
	ListNode head = new(1,
		new(2,
			new(3,
				new(4,
					new(5)))));

	MiddleNode(head).Dump();
}

public ListNode MiddleNode(ListNode head)
{
	ListNode step1x, step2x;
	step1x = step2x = head;
	while (true)
	{
		if (step2x.next is null)
		{
			return step1x;
		}

		if (step2x.next.next is null)
		{
			return step1x.next;
		}

		step2x = step2x.next.next;
		step1x = step1x.next;
	}
}

//Definition for singly - linked list.
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