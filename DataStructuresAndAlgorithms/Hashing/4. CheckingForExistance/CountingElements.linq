<Query Kind="Program" />

/*
 * LeetCode 1426: Counting Elements
 * 
 * Problem Description:
 * Given an integer array arr, count how many elements x there are, such that x + 1 is also in arr.
 * If there are duplicates in arr, count them separately.
 * 
 * Example: Input: arr = [1,2,3]
 *          Output: 2
 *          Explanation: 1 and 2 are counted because 2 and 3 are in arr.
 * 
 * Solution Explanation:
 * This solution uses a HashSet for O(1) lookups:
 * 1. Convert the array to a HashSet to get unique elements for fast lookup
 * 2. For each element in the original array, check if (element + 1) exists in the HashSet
 * 3. Count all elements that satisfy this condition
 * 4. Using HashSet makes the Contains check O(1) instead of O(n)
 * Note: We iterate the original array (not the HashSet) to count duplicates separately.
 * Time Complexity: O(n), Space Complexity: O(n)
 */

void Main()
{
	int[] arr = [1,2,3];
	
	CountElements(arr).Dump();
}

public int CountElements(int[] arr)
{
	HashSet<int> uniques = arr.ToHashSet(); // O(n)
	
	return arr.Where(n => uniques.Contains(n + 1)).Count(); // O(n)
	
	// overall: O(2n) => O(n).
	// additional memory: O(n).
}