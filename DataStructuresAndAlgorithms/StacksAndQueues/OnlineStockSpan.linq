<Query Kind="Program" />

/*
 * LeetCode 901: Online Stock Span
 * 
 * Problem Description:
 * Design an algorithm that collects daily price quotes for some stock and returns the span of that stock's price for the current day.
 * The span of the stock's price in one day is the maximum number of consecutive days (starting from that day and going backward)
 * for which the stock price was less than or equal to the price of that day.
 * Implement the StockSpanner class:
 * - StockSpanner() Initializes the object of the class.
 * - int next(int price) Returns the span of the stock's price given that today's price is price.
 * 
 * Example: Input: ["StockSpanner", "next", "next", "next", "next", "next", "next", "next"]
 *                 [[], [100], [80], [60], [70], [60], [75], [85]]
 *          Output: [null, 1, 1, 1, 2, 1, 4, 6]
 * 
 * Solution Explanation:
 * This solution uses a monotonic decreasing stack with span aggregation:
 * 1. Stack stores tuples of (Price, Amount) where Amount is the span of consecutive days
 * 2. For each new price:
 *    - Initialize newAmount = 1 (at least the current day)
 *    - Pop all entries from stack with price <= current price
 *    - Add their Amount to newAmount (aggregating consecutive spans)
 *    - Push (price, newAmount) onto stack
 * 3. Return newAmount
 * Key insight: Instead of storing each day separately, aggregate spans to avoid O(n) per query.
 * The stack maintains prices in decreasing order from bottom to top.
 * Time Complexity: O(1) amortized per next() call, Space Complexity: O(n)
 */

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