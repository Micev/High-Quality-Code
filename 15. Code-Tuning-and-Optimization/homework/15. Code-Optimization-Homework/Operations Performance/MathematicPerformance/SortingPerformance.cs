
using System;
using System.Diagnostics;
class SortingPerformance
{
    private const int TestValue = 1000000;
    public static void ParseType(string type, dynamic valueThatAllTypesHas, ref dynamic holdingValue, ref dynamic testingValue)
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
    public static void CalculateTimeForSorting(string sortType, Stopwatch stopWach, IComparable[] values)
    {
        switch (sortType.ToLower().Trim().Trim())
        {
            case "insertion sort":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        InsertionSort(values);
                    }

                    stopWach.Stop();
                }
                break;

            case "selection sort":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        SelectionSort(values);
                    }

                    stopWach.Stop();
                }
                break;

            case "quicksort":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        Quicksort(values, 0, (values.Length - 1));
                    }

                    stopWach.Stop();
                }
                break;

            default:
                {
                    throw new ArgumentException(string.Format("Can not implement sort type {0}!", sortType));
                }
        }
    }

    static void InsertionSort(IComparable[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            var value = values[i];
            int index = i;

            while (index > 0 && (values[index - 1]).CompareTo(value) >= 0) // CompareTo is used becouse a string has no operators >, = and <
            {
                values[index] = values[index - 1];
                index--;
            }
            values[index] = value;
        }
    }

    static void SelectionSort(IComparable[] values)
    {
        for (int i = 0; i < values.Length - 1; i++)
        {
            for (int j = i + 1; j < values.Length; j++)
            {
                if (values[i].CompareTo(values[j]) > 0) // swap items
                {
                    var tmp = values[i];
                    values[i] = values[j];
                    values[j] = tmp;
                }
            }
        }
    }

    public static void Quicksort(IComparable[] values, int left, int right)
    {
        int i = left, j = right;
        IComparable pivot = values[(left + right) / 2];

        while (i <= j)
        {
            while (values[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (values[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Swap
                IComparable tmp = values[i];
                values[i] = values[j];
                values[j] = tmp;

                i++;
                j--;
            }
        }

        // Recursive calls
        if (left < j)
        {
            Quicksort(values, left, j);
        }

        if (i < right)
        {
            Quicksort(values, i, right);
        }
    }
}

