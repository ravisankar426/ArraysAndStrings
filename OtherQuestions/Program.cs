using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAlienAlphaOrder(new string[] { "baa", "abcd", "abca", "cab", "cad" });
            GetAlienAlphaOrder(new string[] { "aabc", "bce", "cde"});
            //Console.WriteLine(ConvertStringToInt("123"));
            Console.Read();
        }

        public static int ConvertStringToInt(string str)
        {            
            char[] chars = str.ToCharArray();
            int result = 0;
            int counter = 0;
            int ascii;

            for (int i= chars.Length-1;i >= 0;i--) {
                ascii = (int)chars[i];
                if (ascii < 48 || ascii > 57) return 0;
                else {
                    result = result + (int)Math.Pow(10, counter)* GetNumberFromASCII(ascii);
                }
                counter++;
            }

            return result;
        }

        public static int GetNumberFromASCII(int ascii) {
            int number = -1;
            switch (ascii) {
                case 48:number = 0;break;
                case 49: number = 1; break;
                case 50: number = 2; break;
                case 51: number = 3; break;
                case 52: number = 4; break;
                case 53: number = 5; break;
                case 54: number = 6; break;
                case 55: number = 7; break;
                case 56: number = 8; break;
                case 57: number = 9; break;
                default: number=-1;break;
            }
            return number;
        }

        private static void GetAlienAlphaOrder(string[] arr)
        {
            Dictionary<char, int> order = new Dictionary<char, int>();
            Dictionary<int, int[]> levels = new Dictionary<int, int[]>();
            int max = 0;
            int length ;
            string str ;
            int[] list;
            var value = 0;
            var temp = 0;
            var isSorted = false;

            for (int level=0;level<arr.Length;level++)
            {
                length = arr[level].Length;
                str = arr[level];
                list = new int[str.Length];
                value=0;
                for(int j=0;j<length;j++)
                {
                    if (!order.ContainsKey(arr[level][j]))
                    {
                        max++;
                        order.Add(arr[level][j], max);
                        value = max;
                    }
                    else
                    {
                        if (level > 0 && arr[level - 1].Length > j)
                        {
                            if (order[arr[level - 1][j]]>1 && order[arr[level][j]] > 1 && !isSorted && order[arr[level][j]] < order[arr[level - 1][j]])
                            {
                                temp = order[arr[level - 1][j]];
                                order[arr[level - 1][j]] = order[arr[level][j]];
                                order[arr[level][j]] = temp;

                            }

                            if (order[arr[level - 1][j]] < order[arr[level][j]])
                                isSorted = true;
                        }

                        value = order[arr[level][j]];
                    }

                    list[j] = value;
                    value = 0;
                    temp = 0;
                }
                levels.Add(level, list);
                isSorted = false;
            }

            //StringBuilder sBuilder = new StringBuilder();
            //foreach (var key in levels.Keys)
            //{
            //    sBuilder.Append($"Level - {key}  ->  ");
            //    for (int i = 0; i < levels[key].Length; i++)
            //    {
            //        sBuilder.Append($"{levels[key][i].ToString()},");
            //    }
            //    Console.WriteLine(sBuilder.ToString());
            //    sBuilder = new StringBuilder();
            //}

            var result = from item in order orderby item.Value ascending select item;

            foreach (KeyValuePair<char,int> item in result)
            {
                Console.WriteLine($"Key - {item.ToString()} ; Value - {item.Value.ToString()}");
            }
        }

        public static void AlienAlphaOrderQueue(string[] arr)
        {
            Queue<char> previous = new Queue<char>();
            Queue<char> current = new Queue<char>();
            Dictionary<char, int> results = new Dictionary<char, int>();

            results.Add(arr[0][0], 1);
            char prev = new char();
            char curr = new char();
            int max = 1;
            bool isGreater = false;
            int temp = 0;

            foreach (var ch in arr[0].ToCharArray())
            {
                previous.Enqueue(ch);
                if (!results.ContainsKey(ch))
                {
                    max++;
                    results.Add(ch, max);
                }
            }

            for (int i = 1; i < arr.Length; i++)
            {
                prev = new char();
                curr = new char();
                temp = 0;

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (previous.Count > 0)
                        prev = previous.Dequeue();

                    current.Enqueue(arr[i][j]);
                    curr = arr[i][j];

                    if (!isGreater)
                    {
                        if (!results.ContainsKey(arr[i][j]))
                        {
                            max++;
                            results.Add(arr[i][j], max);
                        }
                        else
                        {
                            if (results[curr] < results[prev])
                            {
                                if (results[curr] > 1 && results[prev] > 1)
                                {
                                    temp = results[prev];
                                    results[prev] = results[curr];
                                    results[curr] = temp;
                                }
                            }
                            else
                            {
                                if (!results.ContainsKey(arr[i][j]))
                                {
                                    max++;
                                    results.Add(arr[i][j], max);
                                }

                                if (results[curr] != results[prev])
                                    isGreater = true;
                            }
                        }

                    }

                    if (!results.ContainsKey(arr[i][j]))
                    {
                        max++;
                        results.Add(arr[i][j], max);
                    }
                    prev = new char();
                    curr = new char();
                    temp = 0;
                }

                previous = current;
                isGreater = false;
                current = new Queue<char>();
            }

            var output = from item in results orderby item.Value ascending select item;

            foreach (KeyValuePair<char, int> key in output)
                Console.WriteLine($"{key.ToString()}");
        }
    }
}
