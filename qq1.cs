using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Result1
{
    /*
    Check is child is subsequence of parent
    */
    public static bool subSequence(string parent, string child)
    {
        if(string.IsNullOrEmpty(parent) || String.IsNullOrEmpty(child))
            throw new Exception("Param cannot be null");

        if(parent.Length == 0 || child.Length == 0)
            throw new Exception("Invalid length");
            
        if(parent.Length < child.Length)
            return false;
        
        var char0 = child[0];
        
        // Find and remove child[0] from parent string
        var idx0 = parent.IndexOf(char0);
        
        // child[0] not found inparent, means cannot be substring
        if(idx0 < 0)
            return false;
            
        // Check remaining part of child on substring (idx0 remvoved) of parent
        var subStr = parent.Remove(idx0, 1);
        
        // Child has no more char
        if(child.Length == 1)
            return true;
        
        return subSequence(subStr, child.Substring(1));
    }
    
    public static int getCost(char ch, List<int> cost) {
        var idx = ch - 'a';
        return cost[idx];
    }
        
    /*
     * Complete the 'calculateMinCost' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING password
     *  2. STRING reference
     *  3. INTEGER_ARRAY cost
     */
    public static long calculateMinCost(string password, string reference, List<int> cost)
    {
        if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(reference))
            throw new Exception("Password or reference is null");
        
        if(password.ToLower() != password || reference.ToLower() != reference)
            throw new Exception("String with upper case chars");
            
        // Get all permutation
        
        // For each permutation, check if ref is subseq
        
        
            
        var count = 0;
        var currentStr = password;
        
        // Loop until we get length chars
        while(count < password.Length) {
            var result = password[0];
            
            var remainChars = password;
            remainChars.Remove(i);
            
            // Loop to get remaining chars
            for()
        }
        for(int i=0; i<password.Length; i++) {
        }
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string password = Console.ReadLine();

        string reference = Console.ReadLine();

        int costCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> cost = new List<int>();

        for (int i = 0; i < costCount; i++)
        {
            int costItem = Convert.ToInt32(Console.ReadLine().Trim());
            cost.Add(costItem);
        }

        long result = Result.calculateMinCost(password, reference, cost);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
