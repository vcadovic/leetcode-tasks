<Query Kind="Program" />

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