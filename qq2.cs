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



class Result
{

    /*
     * Complete the 'calculatePendingOrders' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY orderProcessTime
     *  2. INTEGER_ARRAY shiftDuration
     */

    public static List<int> calculatePendingOrders(List<int> orderProcessTime, List<int> shiftDuration)
    {
        if(orderProcessTime == null || shiftDuration == null)
            throw new Exception("Null params");
        
        var shiftRemains = new List<int>(shiftDuration.Count);
        
        // Initial order
        var processingIdx = 0;
        var lastRemain = orderProcessTime[processingIdx];
        orderProcessTime[processingIdx] = 0;
        
        // Loop on shifts
        for(int i=0; i<shiftDuration.Count; i++) {
            
            var shiftHours = shiftDuration[i];
            
            // More shift hours; Loop to get enough order for shiftHours
            for(;shiftHours > 0;) {
                
                if(shiftHours > lastRemain) {
                    shiftHours -= lastRemain;
                    lastRemain = 0;
                    
                    // No more order
                    if(processingIdx >= orderProcessTime.Count)
                        break;
                        
                    // Get order, cont processing
                    if(processingIdx < orderProcessTime.Count) {
                        processingIdx ++;
                        lastRemain = orderProcessTime[processingIdx];
                        orderProcessTime[processingIdx] = 0;
                    }
                }
                else {
                    // No more shift time
                    lastRemain -= shiftHours;
                    shiftHours = 0;

                    if(lastRemain == 0 && processingIdx < orderProcessTime.Count) {
                        // Get more order
                        processingIdx ++;
                        lastRemain = orderProcessTime[processingIdx];
                        orderProcessTime[processingIdx] = 0;
                    }
                }
            }
            
            // Count zeros in orderProcessTime, length - zeros means remaining orders
            // lastRemain > 0 mean some work remain.
            var countZeros = orderProcessTime.Count(v => v == 0) + (lastRemain > 0 ? -1 : 0);
            shiftRemains = shiftRemains.Append(orderProcessTime.Count - countZeros).ToList();
        }
        
        var remainStr = String.Join(',', shiftRemains);
        Console.WriteLine($"Result: {remainStr}");
        
        return shiftRemains;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int orderProcessTimeCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> orderProcessTime = new List<int>();

        for (int i = 0; i < orderProcessTimeCount; i++)
        {
            int orderProcessTimeItem = Convert.ToInt32(Console.ReadLine().Trim());
            orderProcessTime.Add(orderProcessTimeItem);
        }

        int shiftDurationCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> shiftDuration = new List<int>();

        for (int i = 0; i < shiftDurationCount; i++)
        {
            int shiftDurationItem = Convert.ToInt32(Console.ReadLine().Trim());
            shiftDuration.Add(shiftDurationItem);
        }

        List<int> result = Result.calculatePendingOrders(orderProcessTime, shiftDuration);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
