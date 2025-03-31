<Query Kind="Program" />

void Main()
{
	int[] nums = [2, 4, 1, 3];
	NextPermutation(nums);
	
	nums.Dump();
}

public void NextPermutation(int[] nums)
{
	if (nums.Length <= 1) return;
	
	int i = nums.Length - 2;
	while (i >= 0 && nums[i] >= nums[i + 1]) i--;
	
	if (i >= 0)
	{
		int j = nums.Length - 1;
		while (j >= i && nums[i] >= nums[j]) j--;

		Swap(ref nums[i], ref nums[j]);
	}	
	
	Array.Reverse(nums, i + 1, nums.Length - i - 1);
}

private void Swap(ref int a, ref int b)
{
	int temp = b;
	b = a;
	a = temp;
}