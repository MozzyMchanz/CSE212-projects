public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //  Problem 1 Start

        // PLAN:
        // 1. Create a new array of doubles with size 'length'
        // 2. Loop through each index of the array from 0 to length-1
        // 3. For each index i, calculate the multiple as (i+1) * number
        //    (i+1 because we start with the number itself at index 0, not 0x the number)
        // 4. Store the calculated multiple in the array at index i
        // 5. Return the completed array
        // 
        // Example: MultiplesOf(3, 5) should create array {3, 6, 9, 12, 15}
        // - At index 0: (0+1) * 3 = 3
        // - At index 1: (1+1) * 3 = 6
        // - At index 2: (2+1) * 3 = 9
        // - At index 3: (3+1) * 3 = 12
        // - At index 4: (4+1) * 3 = 15

        // Create the array with the specified length
        double[] result = new double[length];

        // Loop through each position in the array
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple: (position + 1) times the number
            result[i] = (i + 1) * number;
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Problem 2 Start
         

        // PLAN:
        // 1. Use modulo to normalize the amount in case it's larger than the list size
        //    (e.g., rotating by 13 in a list of 9 items is the same as rotating by 4)
        // 2. Calculate the split point: splitIndex = data.Count - amount
        //    This is where we'll separate the "right part" from the "left part"
        // 3. Extract the right part that needs to move to the front using GetRange()
        // 4. Remove the right part from the list using RemoveRange()
        // 5. Insert the extracted right part at the beginning using InsertRange()
        //
        // Example: {1,2,3,4,5,6,7,8,9} rotated right by 3
        // - splitIndex = 9 - 3 = 6
        // - rightPart = GetRange(6, 3) = {7, 8, 9}
        // - RemoveRange(6, 3) removes {7, 8, 9}, leaving {1,2,3,4,5,6}
        // - InsertRange(0, {7,8,9}) inserts at beginning
        // - Result: {7, 8, 9, 1, 2, 3, 4, 5, 6}

        // Normalize the amount using modulo to handle amounts greater than list size
        amount = amount % data.Count;

        // Calculate the starting index of the right part to rotate
        int splitIndex = data.Count - amount;

        // Extract the elements from splitIndex to the end (the right part)
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Remove those elements from the list
        data.RemoveRange(splitIndex, amount);

        // Insert the right part at the beginning of the list
        data.InsertRange(0, rightPart);
    }
}
