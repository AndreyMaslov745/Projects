using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApplication1.Extensions
{
    public class ArraySortingExtensions<T> where T : IComparable
    {
        public T[] BubbleSort(T[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[j+1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j+1];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
    }
}
