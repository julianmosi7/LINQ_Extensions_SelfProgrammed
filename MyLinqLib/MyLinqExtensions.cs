using System;
using System.Collections.Generic;

namespace MyLinqLib
{
    public static class MyLinqExtensions
    {
        public delegate bool del<T>(T t);

        #region ---------------------------------------- helpers for printing
        private const int HEADER_LENGTH = 90;
        public static void Show<T>(this IEnumerable<T> list, string header)
        {
            //Console.WriteLine(new StackTrace().GetFrame(1).GetMethod().Name.PadLeft(80, '-'));
            header = $" {header}";
            Console.WriteLine(header.PadLeft(HEADER_LENGTH, '-'));
            foreach (var s in list) Console.WriteLine(s.ToString());
            Console.WriteLine("".PadLeft(HEADER_LENGTH, '-'));
            Console.WriteLine();
        }

        public static void ShowSingle<T>(this T obj, string header)
        {
            //Console.WriteLine(new StackTrace().GetFrame(1).GetMethod().Name.PadLeft(80, '-'));
            header = $" {header}";
            Console.WriteLine(header.PadLeft(HEADER_LENGTH, '-'));
            Console.WriteLine(obj.ToString());
            Console.WriteLine("".PadLeft(HEADER_LENGTH, '-'));
            Console.WriteLine();
        }
        #endregion

        public static object First<T>(this List<T> list, del<T> action)
        {
            foreach (var item in list)
            {
                if (action(item))
                {
                    return item;
                }
            }
            return null;
        }

        public static object First<T>(this List<T> list)
        {
            foreach (var item in list)
            {
                return item;
            }
            return null;
        }

        /*
        public static object FirstOrDefault<T>(this List<T> list, del<T> action)
        {
            foreach (var item in list)
            {
                if (action(item))
                {
                    return item;
                }
            }
            return list;
        }
        */

        public static object Last<T>(this List<T> list, del<T> action)
        {
            object last = null;
            foreach (var item in list)
            {
                if (action(item))
                {
                    last = item;
                }
            }
            return last;
        }

        public static object Last<T>(this List<T> list)
        {
            object last = null;
            foreach (var item in list)
            {
                last = item;
            }
            return last;
        }

        /*
        public static object LastOrDefault<T>(this List<T> list, del<T> action)
        {
            object last = null;
            foreach (var item in list)
            {
                if (action(item))
                {
                    last = item;
                }
            }
            return list;
        }
        */

        public static List<T> Where<T>(this List<T> list, del<T> action)
        {
            var newList = new List<T>();
            foreach (var item in list)
            {
                if (action(item))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        /*
        public static List<T> Distinct<T>(this List<T> list)
        {            
            var newList = new List<T>();
            
        }
        */

        public static List<T> Take<T>(this List<T> list, int num)
        {
            var newList = new List<T>();
            for (int i = 0; i < num; i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }
    }
}
