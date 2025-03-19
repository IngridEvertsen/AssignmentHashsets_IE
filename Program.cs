using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Section 3: Basic HashSet Operations
        // Creating a HashSet and adding some numbers
        HashSet<int> numbers = new HashSet<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("HashSet Elements:");
        foreach (int num in numbers)
        {
            Console.Write(num + " "); // Printing out each number in the HashSet
        }
        
        // Trying to add a duplicate number (3) - should return false
        Console.WriteLine("\nAdding 3 again (Should not be added): " + numbers.Add(3)); // False, because HashSet doesn't allow duplicates
        
        // Section 4: Set Operations
        // Creating two sets with some common and some unique numbers
        HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };
        
        // Finding common elements (intersection of two sets)
        setA.IntersectWith(setB);
        Console.WriteLine("\nIntersection of SetA and SetB:");
        foreach (int num in setA) Console.Write(num + " "); // Should print only numbers that exist in both sets
        
        // Resetting setA to its original values
        setA = new HashSet<int> { 1, 2, 3, 4, 5 };
        
        // Combining both sets into one (union operation)
        setA.UnionWith(setB);
        Console.WriteLine("\nUnion of SetA and SetB:");
        foreach (int num in setA) Console.Write(num + " "); // Should print all unique numbers from both sets
        
        // Section 5: HashSet Performance vs List
        // Creating a large HashSet and a List to compare their performance
        HashSet<int> hashSet = new HashSet<int>();
        List<int> list = new List<int>();
        int testSize = 1000000; // One million elements
        
        for (int i = 0; i < testSize; i++)
        {
            hashSet.Add(i); // Adding numbers to HashSet
            list.Add(i);    // Adding numbers to List
        }
        
        // Measuring time taken to check if an element exists in HashSet vs List
        Stopwatch sw = Stopwatch.StartNew();
        Console.WriteLine("\nHashSet contains check:");
        
        // Checking if the last element exists in HashSet (this should be fast, O(1) on average)
        sw.Restart();
        bool hashSetContains = hashSet.Contains(testSize - 1);
        sw.Stop();
        Console.WriteLine("HashSet contains time: " + sw.ElapsedMilliseconds + " ms");
        
        // Checking if the last element exists in List (this might be slow, O(n) in worst case)
        sw.Restart();
        bool listContains = list.Contains(testSize - 1);
        sw.Stop();
        Console.WriteLine("List contains time: " + sw.ElapsedMilliseconds + " ms");
        
        // Explanation: HashSet has O(1) average time complexity for lookup, whereas List has O(n)
        // This means HashSet is much faster for checking if an item exists!
    }
}
