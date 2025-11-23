<Query Kind="Program" />

/*
 * LeetCode 1004: Max Consecutive Ones III
 * 
 * Problem Description:
 * Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array
 * if you can flip at most k 0's.
 * 
 * Example: Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
 *          Output: 6
 *          Explanation: [1,1,1,0,0,1,1,1,1,1,1] (flipped 0s are in bold)
 * 
 * Solution Explanation:
 * This solution uses a sliding window approach with a queue to track zero positions:
 * 1. Maintain a window with 'right' pointer expanding the window
 * 2. Track the number of zeros in the current window (windowZeros)
 * 3. Store zero indices in a queue for quick access to the leftmost zero
 * 4. When windowZeros exceeds k, shrink the window from the left by:
 *    - Dequeuing the leftmost zero index
 *    - Moving left pointer to that zero position
 *    - Recalculating window size
 * 5. Keep track of the maximum window size seen
 * The queue helps efficiently maintain which zeros are in the current window.
 * Time Complexity: O(n), Space Complexity: O(k) for the queue
 */

void Main()
{
	int[] nums = [0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1];
	int k = 3;
	
	LongestOnes(nums, k).Dump();
}

public int LongestOnes(int[] nums, int k)
{
	int result = 0, windowZeros = 0, windowSize = 0;
	int left = -1, right = 0;
	Queue<int> zeroIndices = [];
	while (right < nums.Length)
	{
		if(nums[right] == 0)
		{
			windowZeros++;
			zeroIndices.Enqueue(right);
		}
		
		if (windowZeros <= k)
		{
			windowSize++;
		}
		else
		{
			result = Math.Max(result, windowSize);

			left = zeroIndices.Dequeue();
			
			windowSize = right - left;
			windowZeros--;
		}

		right++;
	}

	return Math.Max(result, windowSize);
}