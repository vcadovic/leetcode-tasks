<Query Kind="Program" />

void Main()
{
	int[] nums = [9,6,4,2,3,5,7,0,1];
	MissingNumberXor(nums).Dump();
	MissingNumber(nums).Dump();
}

public int MissingNumber(int[] nums) // Gauss formula
{
	int sum = 0, indicesSum = 0;
	
	for (int i = 0; i < nums.Length; i++)
	{
		indicesSum += i + 1;
		sum += nums[i];
	}
	
	return indicesSum - sum;
}

public int MissingNumberXor(int[] nums)
{
	int missing = nums.Length;
	for (int i = 0; i < nums.Length; i++)
	{
		missing ^= i ^ nums[i];
	}
	
	return missing;
}