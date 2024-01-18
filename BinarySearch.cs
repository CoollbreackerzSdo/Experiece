public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int L = 0;
        int R = input.Length - 1;
        while (L <= R)
        {
            int mid = (L + R) / 2;
            if (input[mid] < value)
            {
                L = mid + 1;
            }
            else if (input[mid] > value)
            {
                R = mid - 1;
            }
            else
                return mid;
        }
        return -1;
    }
    public static int Find2(int[] input, int value)
        => Array.BinarySearch(input, value);
}