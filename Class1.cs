namespace ConsoleApp1;

public static class TestClass
{
    // C# Coding Questions For Technical Interviews
    // https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/

    public static void Q1_ReverseString()
    {
        List<int> numbers = new List<int> { 5, 2, 8, 1, 3 };
        Comparison<int> compare = (x, y) => {
            return
                x > y ? 1 :
                x == y ? 0 : -1;
        };
        numbers.Sort(compare);  // Sorts in ascending order

        Console.WriteLine(string.Join(", ", numbers));  // Output: 1, 2, 3, 5, 8
    }

    public static void Q2_Palindrome(string str)  
    {  
        bool flag = true;
        for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)  
        {  
            if (str[i] != str[j])  
            {  
                flag = false;  
                break;  
            }  
        }

        if (flag)  
        {  
            Console.WriteLine("Palindrome");  
        }  
        else  
            Console.WriteLine("Not Palindrome");  
    }

    public static void Q3_ReverseOrderOfWords(string str)  
    {
        var words = str.Split();
        words = words.Reverse().ToArray();

        var result = string.Join(" ", words);

        Console.WriteLine($"Reversed: {result}");  
    }

    public static void Q4_ReverseEchWord(string str)  
    {
        var words = str.Split();

        List<String> reversedWords = [];
        foreach(var word in words) {
            reversedWords.Add(new string(word.Reverse().ToArray()));
        }

        var result = String.Join(" ", reversedWords);
        Console.WriteLine($"Reversed: {result}");  
    }

    public static void Q5_CountOccurences(string str)
    {
        var chars = str.ToCharArray();
        var seed = new Dictionary<char, int>();

        // Count result, use map-reduce
        var result = chars.Aggregate(seed, (acc, ch) => {
            acc[ch] = acc.GetValueOrDefault(ch) + 1;
            return acc;
        });

        // Convert to string to show.
        var strResult  = String.Join(", ", result.ToList().Select(kv => kv.ToString()));

        Console.WriteLine($"Reversed: {strResult}");
    }
}


// TestClass.Q1_ReverseString();
// TestClass.Q2_Palindrome("ABCB");
// TestClass.Q3_ReverseOrderOfWords("AB CD EF 12");
// TestClass.Q4_ReverseEchWord("AB CD EF 12");
