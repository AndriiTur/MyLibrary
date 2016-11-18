using System;

namespace MyLibrary
{
    public class MyString
    {
        public const string testmesag = "starIndex > length";
        public const string testmesag2 = "starIndex < 0";
        public static int IndexOf(string subStr, string str)
        {
            return IndexOf(subStr, str, 0);
        }
        public static int IndexOf(string subStr, string str, int startIndex)
        {
            if (subStr.Length == 0)
                return startIndex;
            if (str.Length == 0)
                return -1;
            for (int i = startIndex; i < str.Length; i++)
            {
                if (str[i] == subStr[0])
                {
                    int k = 0;
                    for (int j = 0; j < subStr.Length; j++)
                    {
                        if (i + j == str.Length)
                            break;
                        if (str[i + j] != subStr[j])
                            break;
                        k++;
                    }
                    if (k == subStr.Length)
                        return i;
                }
            }
            return -1;
        }

        public static bool StartsWith(string subStr, string str)
        {
            int i = IndexOf(subStr, str);
            if (i == 0)
                return true;
            return false;
        }

        public static bool EndsWith(string subStr, string str)
        {
            int i = IndexOf(subStr, str);
            if (i == str.Length - subStr.Length)
                return true;
            if (subStr == "")
                return true;
            return false;
        }

        public static int LastIndexOf(string subStr, string str)
        {
            return LastIndexOf(subStr, str, str.Length - 1);
        }

        public static int LastIndexOf(string subStr, string str, int startIndex)
        {
            if ((subStr == "") && (str == ""))
                return 0;
            if (subStr == "")
                return startIndex;
            if (str == "")
                return -1;
            for (int i = startIndex; i >= 0; i--)
            {
                if (str[i] == subStr[subStr.Length - 1])
                {
                    for (int j = (subStr.Length - 1); j > 0; j--)
                    {
                        if (i <= 0)
                        {
                            return -1;
                        }
                        if (str[i] != subStr[j])
                            break;
                        i--;
                    }
                    return i;
                }
            }
            return -1;
        }

        public static string SubString(string str, int startIndex)
        {
            return SubString(str, startIndex, str.Length - startIndex);
        }

        public static string SubString(string str, int startIndex, int length)
        {
            string subStr = "";
            if (str.Length == 0)
                return subStr="";
            if (startIndex > str.Length - 1)
                throw new ArgumentOutOfRangeException("startIndex",startIndex, testmesag );
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException("startIndex",startIndex, testmesag2);
            if (startIndex + length > str.Length)
                throw new ArgumentOutOfRangeException("length",length,testmesag);
            for (int i = startIndex; i < startIndex + length; i++)
            {                 
                subStr += str[i];
            }
            return subStr;
        }

        public static bool ArrayCompare(string[] strArray1, string[] strArray2)
        {
            if (strArray1.Length != strArray2.Length)
                return false;
            for (int i = 0; i < strArray1.Length; i++)
                if (strArray1[i] != strArray2[i])
                {
                    return false;
                }
            return true;
        }

        public static string[] Split(string str, string delimiter)
        {
            int starIndex = 0;
            int IndOf = 0;
            int length = 0;
            string subStr = "";
            string[] strArray = new string[] { };
            while (true)
            {
                IndOf = IndexOf(delimiter, str, starIndex);
                if (IndOf == -1)
                {
                    IndOf = str.Length;
                    length = IndOf - starIndex;
                    if (starIndex < IndOf)
                        subStr = SubString(str, starIndex, length);
                    else
                        subStr = "";
                    strArray = AddArray(strArray, subStr);
                    break;
                }
                else
                {
                    length = IndOf - starIndex;
                    subStr = SubString(str, starIndex, length);
                    strArray = AddArray(strArray, subStr);
                    starIndex = IndOf + delimiter.Length;
                }
                
            }
            return strArray;
        }

        public static string[] AddArray(string[] arr,string str)
        {
            string[] arrResult = new string[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
                arrResult[i] = arr[i];
            arrResult[arrResult.Length - 1] = str;
            return arrResult;
        }

        public static string Join(string delimiter, string[] arr)
        {
            string str="";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i];
                if (i < arr.Length-1)
                    str += delimiter;
           }
            return str;
        }

        public static string[] AddToArray(string[] strArray, string str, int index)
        {
            string[] arrResult = new string[strArray.Length + 1];
            int i = 0;
            int j = 0;

            if (strArray.Length == 0)
                arrResult[0] = str;
           
            if (index > strArray.Length)
                throw new ArgumentOutOfRangeException("Index",index,testmesag);

            if (index < 0)
                throw new ArgumentOutOfRangeException("IndexZero",index,testmesag2);

            while (j < strArray.Length)
            {
                if (strArray.Length == 0)
                    arrResult[0] = str;

                if (i == index)
                {
                    arrResult[i] = str;
                    i++;
                }
                else
                {
                    arrResult[i] = strArray[j];
                    i++; j++;
                }
               
            }
            return arrResult;
        }

        public static string[] DelFromArray(string[] strArray, int index)
        {
            string[] arrResult = new string[strArray.Length - 1];
            int resultCount = 0;
            int i = 0;
            
            if (index > strArray.Length-1)
                throw new ArgumentOutOfRangeException("Index",index,testmesag);

            if (index <0)
                throw new ArgumentOutOfRangeException("IndexZero",index,testmesag2);

            while (resultCount != arrResult.Length)
            {
                if (i != index)                                 
                {
                    arrResult[resultCount] = strArray[i];
                    resultCount++; 
                }
                i++;
            }
            return arrResult;
        }

        public static string DelFromString(string strIn, char val)
        {
            var resultStr = "";
                  for (int i = 0; i < strIn.Length; i++)
                {
                    if (strIn[i] != val)
                        resultStr = resultStr + strIn[i];
                }
            return resultStr;
        }
    }
}