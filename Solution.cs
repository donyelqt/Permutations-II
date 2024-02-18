public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums); 

        bool[] used = new bool[nums.Length];
        List<int> currentPermutation = new List<int>();

        Permute(nums, used, currentPermutation, result);

        return result;
    }

    private void Permute(int[] nums, bool[] used, List<int> currentPermutation, IList<IList<int>> result) {
        if (currentPermutation.Count == nums.Length) {
            result.Add(new List<int>(currentPermutation));
            return;
        }

        for (int i = 0; i < nums.Length; i++) {
            if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])) {
                
                continue;
            }

            used[i] = true;
            currentPermutation.Add(nums[i]);

            Permute(nums, used, currentPermutation, result);

            used[i] = false;
            currentPermutation.RemoveAt(currentPermutation.Count - 1);
        }
    }
}
