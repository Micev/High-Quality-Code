
using System;
using System.Diagnostics;
class PrintResult
    {
        private const int TestValue = 1000000;
        public static void PrintMathComparingResult(string type, string action)
        {
            dynamic holdingValue = 0;
            dynamic testingValue = 0;
            dynamic valueThatAllTypesHas = 1;

            ParseType(type, valueThatAllTypesHas, ref holdingValue, ref testingValue);

            var stopWach = new Stopwatch();

            MathematicPerformance.CalculateTimeForAction(action, stopWach, holdingValue, testingValue);

            PrintrResults(type, action, stopWach);
        }

        public static void PrintSortComparingResults(string arrayType, string sortType)
        {
            IComparable[] values = { };

            MakeArrayFromType(arrayType, ref values);

            var stopWach = new Stopwatch();

            SortingPerformance.CalculateTimeForSorting(sortType, stopWach, values);

            PrintrResults(arrayType, sortType, stopWach);
        }

        private static void ParseType(string type, dynamic valueThatAllTypesHas, ref dynamic holdingValue, ref dynamic testingValue)
        {
            switch (type.ToLower().Trim())
            {
                case "int":
                    {
                        holdingValue = (int)valueThatAllTypesHas;
                        testingValue = (int)valueThatAllTypesHas;
                    }
                    break;

                case "long":
                    {
                        holdingValue = (long)valueThatAllTypesHas;
                        testingValue = (long)valueThatAllTypesHas;
                    }
                    break;

                case "double":
                    {
                        holdingValue = (double)valueThatAllTypesHas;
                        testingValue = (double)valueThatAllTypesHas;
                    }
                    break;

                case "float":
                    {
                        holdingValue = (float)valueThatAllTypesHas;
                        testingValue = (float)valueThatAllTypesHas;
                    }
                    break;

                case "decimal":
                    {
                        holdingValue = (decimal)valueThatAllTypesHas;
                        testingValue = (decimal)valueThatAllTypesHas;
                    }
                    break;

                default:
                    {
                        throw new ArgumentException(string.Format("Can not resolve this kind of type {0}!", type));
                    }
            }
        }
        private static void PrintrResults(string type, string action, Stopwatch stopWach)
        {
            Console.WriteLine(
                string.Format(
                    "Results from {0} for {1} times, values type {2}, elapsed {3}ms.",
                    action,
                    TestValue,
                    type,
                    stopWach.ElapsedMilliseconds));
        }

        private static void MakeArrayFromType(string arrayType, ref IComparable[] values)
        {
            switch (arrayType)
            {
                case "int":
                    {
                        values = new IComparable[] { 2, 1, 3, 5, 4 };
                    }

                    break;

                case "double":
                    {
                        values = new IComparable[] { 2.0, 1.0, 3.0, 5.0, 4.0 };
                    }

                    break;

                case "string":
                    {
                        values = new IComparable[] { "2", "1", "3", "5", "4" };
                    }

                    break;

                default:
                    {
                        throw new ArgumentException(string.Format("Can not make array of type {0}!", arrayType));
                    }
            }
        }

    }

