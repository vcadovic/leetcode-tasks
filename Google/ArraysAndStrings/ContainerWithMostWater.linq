<Query Kind="Program" />

/*
 * LeetCode 11: Container With Most Water
 * 
 * Problem Description:
 * You are given an integer array height of length n. There are n vertical lines drawn such that
 * the two endpoints of the ith line are (i, 0) and (i, height[i]).
 * Find two lines that together with the x-axis form a container, such that the container contains the most water.
 * Return the maximum amount of water a container can store.
 * Note: You may not slant the container.
 * 
 * Example: Input: height = [1,8,6,2,5,4,8,3,7]
 *          Output: 49
 *          Explanation: Max area is between heights 8 and 7 with width 7: min(8,7) * 7 = 49
 * 
 * Solution Explanation:
 * This solution uses two pointers to efficiently find maximum area:
 * 1. Start with widest container: left at 0, right at end
 * 2. Calculate area: min(height[left], height[right]) * width
 *    - Water level limited by shorter line
 *    - Width is distance between pointers
 * 3. Move the pointer with shorter height inward:
 *    - Moving taller pointer can't increase area (width decreases, height stays same/smaller)
 *    - Moving shorter pointer might find a taller line
 * 4. Track maximum area seen
 * This greedy approach works because we start with maximum width and intelligently reduce it.
 * Time Complexity: O(n), Space Complexity: O(1)
 */

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