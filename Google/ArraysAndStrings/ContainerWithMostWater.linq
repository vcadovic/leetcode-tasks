<Query Kind="Program" />

void Main()
{
	int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
	MaxArea(height).Dump();
}

public int MaxArea(int[] height)
{
	int leftIx = 0, rightIx = height.Length - 1;
	int maxArea = 0, currentArea = 0;

	while (leftIx < rightIx)
	{
		currentArea = Math.Min(height[leftIx], height[rightIx]) * (rightIx - leftIx);
		maxArea = Math.Max(maxArea, currentArea);

		if (height[leftIx] < height[rightIx]) leftIx++;
		else rightIx--;
	}

	return maxArea;
}