namespace ConsoleApp1;

public static class TestClass2
{
    public static int findGroup(List<List<int>> groups, int person) {
        for(int i=0; i<groups.Count; i++) {
            if(groups[i].Contains(person))
                return i;
        }
        
        return -1;
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
        
        for(int i=0; i<peopleCount; i++) {
            // Currrent row
            var row = related[i];
            
            // Current row group. Should always exist.
            var rowGroup = findGroup(groups, i);
            
            // Loop on all column of current row.
            for(int j=0; j<peopleCount / 2; j++) {
                
                // If NOT connected, skip
                if(row[j] != CONNECTED)
                    continue;
                
                // Don't process the middle cell
                if(j*2 == peopleCount)
                    break;
                
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
