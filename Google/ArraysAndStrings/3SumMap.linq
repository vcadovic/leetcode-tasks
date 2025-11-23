<Query Kind="Program" />

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
 * Solution Explanation (Hash Map Approach):
 * This solution reduces 3Sum to multiple 2Sum problems using hash maps:
 * 1. For each element nums[i], find pairs in remaining elements that sum to -nums[i]
 * 2. TwoSum helper function uses a hash map:
 *    - Track seen numbers and their complements
 *    - When a complement is found, store both numbers as a pair
 *    - Use nullable int to distinguish between "seen but no pair" and "seen with pair"
 * 3. Use HashSet with custom Chunk struct to eliminate duplicate triplets:
 *    - Chunk implements IEquatable to compare sorted triplets
 *    - GetHashCode provides consistent hashing for XOR-based deduplication
 * 4. Return unique triplets as lists
 * Time Complexity: O(n²), Space Complexity: O(n)
 */

void Main()
{
	int[] nums = [-1,0,1,0];

	ThreeSum(nums).Dump();
}

public IList<IList<int>> ThreeSum(int[] nums)
{
	if (nums.Length < 2) return [];

	HashSet<Chunk> result = [];
	ReadOnlySpan<int> span = nums.AsSpan();

	for (int i = 0; i < nums.Length - 2; i++)
	{
		var chunks = TwoSum(span.Slice(i + 1), -nums[i]);

		foreach (var chunk in chunks)
		{
			result.Add(chunk);
		}
	}
	
	return result.Select(c => c.ToList()).ToList();

	IList<Chunk> TwoSum(ReadOnlySpan<int> nums, int sum)
	{
		Dictionary<int, int?> map = [];
		
		foreach (var num in nums)
		{
			int diff = sum - num;
			if (map.TryGetValue(diff, out _))
			{
				map[diff] = num;
			}
			else if (!map.TryGetValue(num, out _))
			{
				map[num] = null;
			}
		}
		
		return map
			.Where(p => p.Value.HasValue)
			.Select(p => new Chunk(-sum, p.Key, p.Value.Value))
			.ToList();
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