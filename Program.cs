using ConsoleApp1;

Console.WriteLine("Hello, World!");

// var input = "5,3,2,4,1,2";
List<int> input1 = [1 ,2 ,4 ,1 ,2];
List<int> input2 = [3 ,10 ,1 ,1 ,1];

// Result1.minimalHeaviestSetA(input.Split(",").ToList());
var res = Result.calculatePendingOrders(input1, input2);

var resStr = String.Join(',', res);

Console.WriteLine($"Resule: {resStr}");

Console.WriteLine("\n\n\nDONE ..........");
