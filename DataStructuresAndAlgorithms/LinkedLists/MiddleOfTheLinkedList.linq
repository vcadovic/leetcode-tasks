<Query Kind="Program" />

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