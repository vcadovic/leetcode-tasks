<Query Kind="Program" />

void Main()
{
	StockSpanner stockSpanner = new();

	stockSpanner.Next(100).Dump(); // return 1
	stockSpanner.Next(80).Dump();  // return 1
	stockSpanner.Next(60).Dump();  // return 1
	stockSpanner.Next(70).Dump();  // return 2
	stockSpanner.Next(60).Dump();  // return 1
	stockSpanner.Next(75).Dump();  // return 4, because the last 4 prices (including today's price of 75) were less than or equal to today's price.
	stockSpanner.Next(85).Dump();  // return 6
}

public class StockSpanner
{
	private readonly Stack<(int Price, int Amount)> _stack = [];

	public int Next(int price)
	{
		int newAmount = 1;
		while (_stack.Count > 0 && _stack.Peek().Price <= price)
		{
			newAmount += _stack.Pop().Amount;
		}

		_stack.Push((price, newAmount));

		return newAmount;
	}
}