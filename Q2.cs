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



class Result2
{

    /*
     * Check if a person belong to existing group.
     * Return -1 if not found, other return index of group that this person belog to.
     */
    public static int findGroup(List<List<int>> groups, int person) {
        for(int i=0; i<groups.Count; i++) {
            if(groups[i].Contains(person))
                return i;
        }
        
        throw new Exception("Should not reach here");
    }

    public static void joinGroups(List<List<int>> groups, int first, int second) {
        groups[first].AddRange(groups[second]);
        groups.RemoveAt(second);
    }
    
    /*
     * Complete the 'countGroups' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY related as parameter.
     */

    public static int countGroups(List<string> related)
    {
        var relatedStr = String.Join("\n", related);
        Console.WriteLine($"related:\n{relatedStr}");
        
        const char CONNECTED = '1';
        const char NOT_CONNECTED = '0';
        
        List<List<int>> groups = new List<List<int>>();
        
        var peopleCount = related.Count;
        
        // Initialize groups for each person.
        for(int i=0; i<peopleCount; i++) {
            groups.Add(new List<int>{i});
        }
        
        // Loop on each row.
        for(int i=0; i<peopleCount; i++) {
            // Currrent row
            var row = related[i];
            
            // Current row group. Should always exist.
            var rowGroup = findGroup(groups, i);
            
            // Process from start matrix to i
            for(int j=0; j<i; j++) {
                
                // If NOT connected, skip
                if(row[j] != CONNECTED)
                    continue;
                
                // Check if current column below to a group, join 2 groups
                var groupIdx = findGroup(groups, j);
                if(groupIdx != rowGroup) {
                    joinGroups(groups, rowGroup, groupIdx);
                }
            }
        }
        
        Console.WriteLine($"Result: {groups.Count}");
        
        return groups.Count;
    }

}

class Solution2
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int relatedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> related = new List<string>();

        for (int i = 0; i < relatedCount; i++)
        {
            string relatedItem = Console.ReadLine();
            related.Add(relatedItem);
        }

        int result = Result2.countGroups(related);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
