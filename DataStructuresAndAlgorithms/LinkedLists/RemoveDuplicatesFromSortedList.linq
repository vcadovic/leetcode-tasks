<Query Kind="Program" />

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
