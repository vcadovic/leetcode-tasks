<Query Kind="Program">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>

/*
 * LeetCode 15: 3Sum
 * 
 * Problem Description:
 * Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that
 * i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
 * Notice that the solution set must not contain duplicate triplets.
 * 
 * Example: Input: nums = [-1,0,1,2,-1,-4]
 *          Output: [[-1,-1,2],[-1,0,1]]
 * 
 * Solution Explanation (Naive/Brute Force Approach):
 * This solution uses three nested loops to check all possible triplets:
 * 1. Fix first element at position i
 * 2. For remaining elements (i+1 onwards), use Step helper to find pairs summing to -nums[i]
 * 3. Step function uses two nested loops (brute force 2Sum):
 *    - Try all pairs in the subarray
 *    - When sum matches target, create a Chunk triplet
 * 4. Use HashSet with custom Chunk struct to automatically eliminate duplicates
 * 5. Chunk equality compares sorted values to identify duplicate triplets
 * This is simpler but less efficient than optimized approaches.
 * Time Complexity: O(n³), Space Complexity: O(n)
 */

void Main()
{
	int[] nums = [1, 1, -2];

	ThreeSum(nums).Dump();
}

public IList<IList<int>> ThreeSum(int[] nums)
{
	if (nums.Length < 2) return [];

	HashSet<Chunk> result = [];
	ReadOnlySpan<int> span = nums.AsSpan();
	for (int i = 0; i < nums.Length - 2; i++)
	{
		var chunks = Step(span.Slice(i + 1), -nums[i]);

		foreach (var chunk in chunks)
		{
			result.Add(chunk);
		}
	}

	return result.Select(c => c.ToList()).ToList();

	IList<Chunk> Step(ReadOnlySpan<int> nums, int sum)
	{
		IList<Chunk> result = [];
		
		for (int i = 0; i < nums.Length - 1; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (sum == nums[i] + nums[j])
				{
					result.Add(new Chunk(-sum, nums[i], nums[j]));
				}
			}
		}
		
		return result;
	}
}

readonly struct Chunk : IEquatable<Chunk>
{
	public int X { get; }
	public int Y { get; }
	public int Z { get; }

	public Chunk(int x, int y, int z) : this()
	{
		X = x; Y = y; Z = z;
	}

	public override bool Equals(object obj)
	{
		if (obj is not Chunk) return false;

		return Equals((Chunk)obj);
	}

	public override int GetHashCode()
	{
		const int prime = 31;
		return (X * prime) ^ (Y * prime) ^ (Z * prime);
	}

	public bool Equals(Chunk o)
	{
		Span<int> current = stackalloc int[3];
		current[0] = this.X;
		current[1] = this.Y;
		current[2] = this.Z;

		Span<int> other = stackalloc int[3];
		other[0] = o.X;
		other[1] = o.Y;
		other[2] = o.Z;

		current.Sort();
		other.Sort();

		return current.SequenceEqual(other);
	}

	public IList<int> ToList()
	{
		return [X, Y, Z];
	}
}