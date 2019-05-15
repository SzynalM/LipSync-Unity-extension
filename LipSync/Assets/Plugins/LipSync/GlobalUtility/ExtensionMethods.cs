using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

namespace LipsyncUtility
{
    public static class ExtensionMethods
    {
        public static string BuildStringFromArray(this string[] stringArray, string separator)
        {
            string output = "";
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (i > 0)
                {
                    output += separator;
                }
                output += stringArray[i];
            }
            return output;
        }

        public static Queue<T> EnqueueAll<T>(this Queue<T> queue, List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                queue.Enqueue(list[i]);
            }
            return queue;
        }

        public static Queue<T> EnqueueAll<T>(this Queue<T> queue, T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }
            return queue;
        }
    }
}