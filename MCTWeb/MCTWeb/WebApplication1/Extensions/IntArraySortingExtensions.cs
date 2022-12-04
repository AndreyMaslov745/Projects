using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApplication1.Extensions
{
    public static class IntArraySortingExtensions
    {
        public static int[] BubbleSort(this int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
            return array;
        }
        public static int[] GenerateRandom(int lenght)
        {
            int[] array = new int[lenght];
            for(int i = 0; i < lenght; i++)
            {
                array[i] = new Random().Next();
            }
            return array;
        }
    }
}
