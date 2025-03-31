<Query Kind="Program" />

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