using System;
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

            //Console.WriteLine(UniqueCharacteredString("aple"));

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

            string[] strings = new string[] { "apple","zoo","leapp","ozo","lime","ooz","mile","pink"};

            GetAnagramGroups(strings);

            Console.Read();
        }

        public static bool UniqueCharacteredString(string str) {
            bool[] char_set = new bool[128];
            var charArray = str.ToCharArray();
            for (int i = 0; i < str.Length; i++) {
                int val = (int)charArray[i];

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



    }
}
