﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Algorithm to check if a string has all unique characters

            Console.WriteLine(UniqueCharacteredString("apple"));

            //Check if two strings are permutation of each other

            //Console.WriteLine(CheckStringPermutation("chruch","huhrc"));

            //Check if two strings has equal character counts

            //Console.WriteLine(SameCharacterCounts("apple","mapple"));

            ////Check if two strings has equal character counts

            //Console.WriteLine(Urlify("Mr Ravi Sankar".ToCharArray(), 14));

            //Check if a string is palindrome

            //Console.WriteLine(IsPalindrome("anna".ToCharArray()));

            //Check if a Palindrome permutation 

            //Console.WriteLine(CheckPalindromePermutation("taco cat"));

            //Console.WriteLine(IsAnagram("breeze","ezerb"));

            //string[] strings = new string[] { "apple","zoo","leapp","ozo","lime","ooz","mile","pink"};

            //GetAnagramGroups(strings);

            //Top2 most occured strings
            List<string> strings = new List<string>() { "pb","pc","pd","pe", "pa", "pf", "pb", "pa","pc","pa","pf","pd","pf","pf","pe","pf"};
            //GetListTop2Most(strings);
            //strings=GetListTop2MostPQ(strings);

            //foreach (string str in strings)
                //Console.WriteLine(str);

            Console.Read();
        }

        public static bool UniqueCharacteredString(string str) {
            bool[] char_set = new bool[128];
            for (int i = 0; i < str.Length; i++) {
                int val = str[i];

                if (char_set[val])
                {
                    return false;
                }

                char_set[val] = true;
            }
            return true;
        }

        public static bool CheckStringPermutation(string s1, string s2) {
            if (s1.Length != s2.Length) return false;
            
            return SortCharsInString(s1)== SortCharsInString(s2);
        }


        public static string SortCharsInString(string s)
        {
            char[] sortedChars = s.ToCharArray();
            Array.Sort(sortedChars);
            return new string(sortedChars);
        }

        //Anagram other meaning
        public static bool SameCharacterCounts(string s1, string s2)
        {
            int[] chars = new int[128];
            int char_int;

            for (int i = 0; i < s1.Length; i++) {
                char_int = s1[i];
                chars[char_int]++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                char_int = s2[i];
                chars[char_int]--;
                if (chars[char_int] < 0)
                    return false;
            }

            return true;
        }

        public static string Urlify(char[] str, int trueLength) {
            int spaces=0, index= trueLength;

            for (int i = 0; i < str.Length; i++) {
                if (str[i] == ' ')
                    spaces++;
            }

            index = trueLength + spaces * 2;

            char[] newCharArray = new char[index];

            for (int i = trueLength - 1; i >= 0; i--) {
                if (str[i] == ' ')
                {
                    newCharArray[index - 1] = '0';
                    newCharArray[index - 2] = '2';
                    newCharArray[index - 3] = '%';
                    index = index - 3;
                }
                else {
                    newCharArray[index - 1] = str[i];
                    index--;
                }
            }

            return new string(newCharArray);
        }

        public static bool IsPalindrome(char[] str)
        {
            int i = 0;
            int j = str.Length - 1;

            while (i < j) {
                if (str[i] != str[j])
                    return false;
                i++;
                j--;
            }

            return true;
        }

        public static bool CheckPalindromePermutation(string s)
        {
            char[] charArray = s.ToCharArray();
            bool foundOdd = false;
            int count=0;

            Dictionary<char, int> dictCharCount = new Dictionary<char, int>();

            for (int i = 0; i < charArray.Length; i++) {
                if (charArray[i] != ' ')
                {
                    if (dictCharCount.Keys.Contains(charArray[i]))
                        dictCharCount[charArray[i]]++;
                    else
                        dictCharCount.Add(charArray[i], 1);
                }
            }

            foreach (var key in dictCharCount.Keys) {
                dictCharCount.TryGetValue(key,out count);

                if (count % 2 == 1)
                {
                    if (foundOdd)
                        return false;

                    foundOdd = true;
                }
            }
            return true;

        }

        public static bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int[] chars = new int[128];
            int char_int;

            for (int i = 0; i < s1.Length; i++)
            {
                char_int = (int)s1[i];
                chars[char_int]++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                char_int = (int)s2[i];
                chars[char_int]--;
                if (chars[char_int] < 0)
                    return false;
            }

            return true;
        }

        public static void GetAnagramGroups(string[] strings)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<List<string>> result = new List<List<string>>();
            foreach (string str in strings)
            {
                char[] tempCharArray = str.ToCharArray();
                Array.Sort(tempCharArray);
                string temp = new string(tempCharArray);
                if (dict.ContainsKey(temp))
                    dict[temp].Add(str);
                else
                    dict.Add(temp, new List<string> { str });
            }
        }

        public static List<string> GetListTop2Most(List<string> strings) {
            List<string> result = new List<string>();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            Dictionary<int, List<string>> order = new Dictionary<int, List<string>>();
            int count = 0;
            bool completed = false;

            //strings.Sort();
            foreach (string str in strings) {
                if (counts.ContainsKey(str))
                {
                    counts[str]++;
                }
                else {
                    counts.Add(str,1);
                }
            }

            foreach (string key in counts.Keys) {
                if (order.ContainsKey(counts[key]))
                {
                    order[counts[key]].Add(key);
                }
                else {
                    order[counts[key]] = new List<string> { key};
                }
            }

            var orders = from pair in order orderby pair.Key descending select pair;

            foreach (KeyValuePair<int, List<string>> k in orders) {
                if (!completed)
                {
                    foreach (string str in k.Value)
                    {
                        if (count < 2)
                        {
                            result.Add(str);
                            count++;
                        }
                        else
                        {
                            completed = true;
                        }
                    }

                }
            }

            return result; 
        }

        public static List<string> GetListTop2MostPQ(List<string> strings)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            PriorityQueue pq = new PriorityQueue();

            //strings.Sort();
            foreach (string str in strings)
            {
                if (counts.ContainsKey(str))
                {
                    counts[str]++;
                }
                else
                {
                    counts.Add(str, 1);
                }
            }

            foreach (var key in counts.Keys) {
                ProductCounts productCount = new ProductCounts();
                productCount.product = key;
                counts.TryGetValue(key, out productCount.count);
                pq.Add(productCount);
            }

            result.Add(pq.Poll().product);
            result.Add(pq.Poll().product);

            return result;
        }

    }

    public class ProductCounts
    {
        public int count;
        public string product;
        public ProductCounts() { }
        public ProductCounts(int count, string product)
        {
            this.count = count;
            this.product = product;
        }
    }

    public class PriorityQueue
    {       
        ProductCounts[] productCounts;
        int size=0;
       

        public PriorityQueue()
        {
            productCounts = new ProductCounts[size];
        }

        public bool HasParent(int index)
        {
            return index > 0;
        }
        public bool HasLeftChild(int index)
        {
            return GetLeftIndex(index) < productCounts.Length;
        }
        public bool HasRightChild(int index)
        {
            return GetRightIndex(index) < productCounts.Length;
        }
        public int GetParentIndex(int index)
        {
            return ((index - 1) / 2);
        }
        public int GetLeftIndex(int index)
        {
            return (index * 2) + 1;
        }
        public int GetRightIndex(int index)
        {
            return (index * 2) + 2;
        }
        public void Swap(int a, int b)
        {
            var temp = productCounts[a];
            productCounts[a] = productCounts[b];
            productCounts[b] = temp;
        }

        public ProductCounts Peek()
        {
            return productCounts[0];
        }

        public ProductCounts Poll()
        {
            if (productCounts.Length == 0) throw new Exception("There are no products");
            ProductCounts temp = productCounts[0];
            productCounts[0] = productCounts[size - 1];
            size--;
            HeapifyDown();
            return temp;
        }

        public void Add(ProductCounts productCount)
        {
            Array.Resize<ProductCounts>(ref productCounts, size + 1);
            size++;
            productCounts[size - 1] = productCount;
            HeapifyUp();
        }

        public void HeapifyDown()
        {
            int index = 0;
            int largestIndex;
            while (HasLeftChild(index))
            {
                largestIndex = GetLeftIndex(index);
                if (HasRightChild(index) && productCounts[GetRightIndex(index)].count > productCounts[GetLeftIndex(index)].count)
                    largestIndex = GetRightIndex(index);
                if (productCounts[index].count < productCounts[largestIndex].count)
                {
                    Swap (index, largestIndex);
                    index = largestIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public void HeapifyUp()
        {
            int index = size - 1;
            int parentIndex;
            while (HasParent(index))
            {
                parentIndex = GetParentIndex(index);
                if (productCounts[index].count > productCounts[parentIndex].count)
                {
                    Swap(index, parentIndex);
                    index = GetParentIndex(index);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
