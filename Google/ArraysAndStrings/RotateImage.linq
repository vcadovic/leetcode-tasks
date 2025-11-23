<Query Kind="Program" />

/*
 * LeetCode 48: Rotate Image
 * 
 * Problem Description:
 * You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
 * You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.
 * DO NOT allocate another 2D matrix and do the rotation.
 * 
 * Example: Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
 *          Output: [[7,4,1],[8,5,2],[9,6,3]]
 * 
 * Solution Explanation:
 * This solution uses a two-step transformation approach for 90-degree clockwise rotation:
 * 1. Transpose the matrix (swap rows and columns):
 *    - Iterate through upper triangle (i > j)
 *    - Swap matrix[i][j] with matrix[j][i]
 *    - This converts rows to columns and vice versa
 * 2. Reverse each row (horizontal flip):
 *    - For each row, reverse the order of elements
 *    - This completes the 90-degree clockwise rotation
 * Key insight: Transpose + Horizontal Flip = 90° Clockwise Rotation
 *              (Alternatively: Transpose + Vertical Flip = 90° Counter-clockwise)
 * This approach is elegant and easy to implement with O(1) extra space.
 * Time Complexity: O(n²), Space Complexity: O(1)
 */

void Main()
{
	int[][] matrix = [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]];
	Rotate(matrix);
	matrix.Dump();
}

public void Rotate(int[][] matrix)
{
	// transpose
	for (int i = 0; i < matrix.Length; i++)
	{
		for (int j = 0; j < i; j++)
		{
			int temp = matrix[i][j];
			matrix[i][j] = matrix[j][i];
			matrix[j][i] = temp;
		}
	}

	// vertical rotate
	for (int i = 0; i < matrix.Length; i++)
	{
		Array.Reverse(matrix[i]);
	}
}