<Query Kind="Program" />

/*
 * LeetCode 83: Remove Duplicates from Sorted List
 * 
 * Problem Description:
 * Given the head of a sorted linked list, delete all duplicates such that each element appears only once.
 * Return the linked list sorted as well.
 * 
 * Example: Input: head = [1,1,2,3,3]
 *          Output: [1,2,3]
 * 
 * Solution Explanation:
 * This solution uses in-place removal by manipulating next pointers:
 * 1. Start with current pointer at head
 * 2. For each node, check if it has the same value as its next node
 * 3. If yes, skip the next node by setting current.next = current.next.next
 * 4. Continue this inner loop while duplicates exist (handles multiple consecutive duplicates)
 * 5. Move to the next distinct node
 * 6. Repeat until the end of the list
 * This modifies the list in-place without creating a new list.
 * Time Complexity: O(n), Space Complexity: O(1)
 */

void Main()
{
	//ListNode head = new(1,
	//	new(1,
	//		new(2,
	//			new(4,
	//				new(4)))));

	ListNode head = new(1,
		new(1,
			new(1)));

	DeleteDuplicates(head).Dump();
}

public ListNode DeleteDuplicates(ListNode head)
{
	ListNode current = head;
	while (current?.next is not null)
	{
		while (current?.val == current?.next?.val)
		{
			current.next = current.next.next;
		}
		
		current = current.next;
	}
	
	return head;
}

//Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
