<Query Kind="Program" />

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