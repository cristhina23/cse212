using System.Globalization;

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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // ** My plan:
        // Create a new array named 'result' with a size equal to 'length'. This array will store each multiple.
        // Use a for loop to go through each index from 0 up to (length - 1).
        // For each index i, calculate number * i. 
        // Store the result of that multiplication in the array at position i.
        // After the loop finishes, return the array with all the calculated multiples.

        double[] result = new double[length]; 
        for (int i = 0; i < length; i++)
        {
            
            result[i] = number * i;
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // ** My Plan:
        // Check if the list has no elements. If it is empty, show a message to the user and stop the function.
        // Save the total number of items in the list in a variable (n).
        // Check if the rotation amount is less than 1 or greater than the size of the list.
        //    - If the amount is invalid, show a message telling the user the valid range and stop the function.
        // Get the last 'amount' elements from the list and store them in a temporary list.
        // Remove those same 'amount' elements from the end of the original list.
        // Insert the temporary elements at the beginning of the original list.
        // Display a message saying the list was successfully rotated.


        if (data == null || data.Count == 0) 
        {
            Console.WriteLine("The list is empty please enter a list of numbers");
            return;
        }

        int n = data.Count;

        if (amount <= 0 || amount > n)
        {
            Console.WriteLine($"The amount is incorrect please enter a number between 1 and  {n}.");
            return;
        } 
           
        List<int> extractedData = data.GetRange(n - amount, amount);
        data.RemoveRange(n - amount, amount);
        data.InsertRange(0, extractedData);
        
        Console.WriteLine($"Mission acomlished, the list has been rotated {amount} positions to the right.");

    }
}
