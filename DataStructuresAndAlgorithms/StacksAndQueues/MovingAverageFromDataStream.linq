<Query Kind="Program" />

/*
 * LeetCode 346: Moving Average from Data Stream
 * 
 * Problem Description:
 * Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.
 * Implement the MovingAverage class:
 * - MovingAverage(int size) Initializes the object with the size of the window.
 * - double next(int val) Returns the moving average of the last size values of the stream.
 * 
 * Example: Input: ["MovingAverage", "next", "next", "next", "next"]
 *                 [[3], [1], [10], [3], [5]]
 *          Output: [null, 1.0, 5.5, 4.66667, 6.0]
 * 
 * Solution Explanation:
 * This solution uses a queue with a running sum for efficient average calculation:
 * 1. Maintain a fixed-size window using a Queue
 * 2. Track the sum of all elements in the window (_sum)
 * 3. On each Next() call:
 *    - If window is full (Count == size), dequeue oldest element and subtract from sum
 *    - Enqueue the new value and add to sum
 *    - Calculate average: sum / current_window_count
 * 4. This avoids recalculating the sum on each call
 * The queue ensures FIFO ordering for the sliding window.
 * Time Complexity: O(1) per next() call, Space Complexity: O(size)
 */

void Main()
{
	MovingAverage movingAverage = new MovingAverage(3);
	
	movingAverage.Next(1).Dump();
	movingAverage.Next(10).Dump();
	movingAverage.Next(3).Dump();
	movingAverage.Next(5).Dump();
}

public class MovingAverage
{
	private readonly int _size;
	private readonly Queue<int> _window;
	private double _sum;

	public MovingAverage(int size)
	{
		_size = size;
		_window = new(size);
	}

	public double Next(int val)
	{
		if (_window.Count == _size)
		{
			_sum -= _window.Dequeue();
		}

		_window.Enqueue(val);
		_sum += val;

		return _sum / _window.Count;
	}
}