<Query Kind="Program" />

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
