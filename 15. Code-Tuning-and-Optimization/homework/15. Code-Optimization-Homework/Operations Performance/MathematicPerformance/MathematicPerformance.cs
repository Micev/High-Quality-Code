using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MathematicPerformance
{
    private const int TestValue = 1000000;
    public static void CalculateTimeForAction(string action, Stopwatch stopWach, dynamic holdingValue, dynamic testingValue)
    {
        switch (action.ToLower().Trim())
        {
            case "add":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = testingValue + testingValue;
                    }

                    stopWach.Stop();
                }
                break;

            case "subtract":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = testingValue - testingValue;
                    }

                    stopWach.Stop();
                }
                break;

            case "increment":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue++;
                    }

                    stopWach.Stop();
                }
                break;

            case "multiply":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = testingValue * testingValue;
                    }

                    stopWach.Stop();
                }
                break;

            case "divide":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {

                        holdingValue = testingValue / testingValue;
                    }

                    stopWach.Stop();
                }
                break;

            case "square root":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = Math.Sqrt((double)testingValue);
                    }

                    stopWach.Stop();
                }
                break;

            case "natural logarithm":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = Math.Log((double)testingValue);
                    }

                    stopWach.Stop();
                }
                break;

            case "sinus":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = Math.Sin((double)testingValue);
                    }

                    stopWach.Stop();
                }
                break;

            default:
                {
                    throw new ArgumentException(string.Format("Can not resolve this kind of action {0}!", action));
                }
        }
    }
}

