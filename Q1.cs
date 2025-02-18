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
     * Complete the 'minimalHeaviestSetA' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    public static List<int> minimalHeaviestSetA(List<int> arr)
    {
        var arrStr = String.Join(",", arr);
        
        Console.WriteLine($"Input: {arrStr}");
        
        Comparison<int> compare  = (x, y) => {
            if(x < y)
                return 1;
            if(x > y)
                return -1;
            return 0;
        };
        // Sort decremental
        arr.Sort(compare);
        
        arrStr = String.Join(",", arr);
        Console.WriteLine($"After sort: {arrStr}");
        
        // Get half of total weight
        var totalWeight = arr.Sum() / (float)2;
        
        var totalA = 0;
        List<int> listA = [];
        
        for(int i=0; i<arr.Count; i++){
            listA.Append(arr[i]);
            totalA += arr[i];
            
            if(totalA > totalWeight - totalA)
                break;
        }
        
        
        var listStr = String.Join(",", listA);
        Console.WriteLine($"Result: {listStr}");
        
        listA.Reverse();
        return listA;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < arrCount; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        List<int> result = Result1.minimalHeaviestSetA(arr);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
