<Query Kind="Program" />

/*
 * LeetCode 71: Simplify Path
 * 
 * Problem Description:
 * Given an absolute path for a Unix-style file system, which begins with a slash '/',
 * transform this path into its simplified canonical path.
 * In Unix-style file system context:
 * - A single period '.' refers to the current directory.
 * - A double period '..' refers to the parent directory.
 * - Multiple consecutive slashes such as '//' and '///' are treated as a single slash '/'.
 * The simplified canonical path should follow these rules:
 * - Always begins with a single slash '/'.
 * - Directories are separated by exactly one slash '/'.
 * - Does not end with a trailing slash '/' unless it is the root directory.
 * - Only contains the directories on the path from root to target (no '.' or '..').
 * 
 * Example: Input: path = "/home/user/Documents/../Pictures"
 *          Output: "/home/user/Pictures"
 * 
 * Solution Explanation:
 * This solution uses a stack to track the directory path:
 * 1. Split the path by '/' delimiter, removing empty entries (handles multiple slashes)
 * 2. For each entry:
 *    - If ".." (go back): pop from stack if not empty
 *    - If "." (current dir): skip it
 *    - Otherwise: push directory name onto stack
 * 3. Join the stack with '/' and prepend '/' for the final canonical path
 * The stack naturally handles the directory hierarchy navigation.
 * Time Complexity: O(n), Space Complexity: O(n)
 */

void Main()
{ 
	string path = "/.../a/../b///cccc/../d/./";
	SimplifyPath(path).Dump();
}

public string SimplifyPath(string path)
{
	const string goBack = "..";
	const string goThis = ".";
	const string delimiter = "/";
	
	List<string> stack = new();
	
	var entries = path.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
	
	foreach (var entry in entries)
	{
		if (entry == goBack)
		{
			if (stack.Count != 0)
				stack.RemoveAt(stack.Count - 1);
		}
		else if (entry == goThis)
		{
			continue;
		}
		else
		{
			stack.Add(entry);
		}
	}
	
	return delimiter + string.Join(delimiter, stack);
}