<Query Kind="Program" />

/*
 * LeetCode 55: Jump Game
 * 
 * Problem Description:
 * You are given an integer array nums. You are initially positioned at the array's first index,
 * and each element in the array represents your maximum jump length at that position.
 * Return true if you can reach the last index, or false otherwise.
 * 
 * Example: Input: nums = [2,3,1,1,4]
 *          Output: true
 *          Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
 * 
 * Solution Explanation:
 * This solution uses a greedy backward approach to check reachability:
 * 1. Start from the end: assume last index is reachable (firstApplicableIx)
 * 2. Work backward through the array:
 *    - For each position i, check if we can jump to or beyond firstApplicableIx
 *    - If yes (i + nums[i] >= firstApplicableIx), update firstApplicableIx to i
 *    - This means position i can reach the end
 * 3. After processing all positions, check if firstApplicableIx is 0
 *    - If yes, we can reach the end from the start
 *    - If no, start position can't reach any position that reaches the end
 * This backward greedy approach is more efficient than forward simulation.
 * Time Complexity: O(n), Space Complexity: O(1)
 */

void Main()
{
	int[] nums = [2, 3, 1, 1, 4];
	CanJump(nums).Dump();
}

public bool CanJump(int[] nums)
{
	int firstApplicableIx = nums.Length - 1;
	for (int i = nums.Length - 2; i >= 0; i--)
	{
		if (i + nums[i] >= firstApplicableIx)
		{
			firstApplicableIx = i;
		}
	}

	return firstApplicableIx == 0;
}