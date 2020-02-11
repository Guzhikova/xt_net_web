using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Encapsulation
{
    internal class MyString
    {
        private char[] _chars;

        public MyString(string newString = "")
        {
            Value = newString;
        }

        public string Value
        {
            get { return ConvertToString(); }
            set { _chars = value.ToArray(); }
        }

        public string ConvertToString()
        {
            return ConvertToString(_chars);
        }

        public char[] ConvertToArray()
        {
            return _chars;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return Equals(obj as MyString);
        }

        public override int GetHashCode()
        {
            return _chars?.GetHashCode() ?? 0;
        }

        public static bool operator ==(MyString myString1, MyString myString2)
        {
            return Equals(myString1, myString2);
        }

        public static bool operator !=(MyString myString1, MyString myString2)
        {
            return !Equals(myString1, myString2);
        }

        public void Concatenate(MyString myString)
        {
            MyString sumString = this + myString;
            _chars = sumString._chars;
        }

        public static MyString operator +(MyString myString1, MyString myString2)
        {
            char[] chars1 = myString1._chars;
            char[] chars2 = myString2._chars;

            int sumLength = chars1.Length + chars2.Length;
            char[] charsSum = new char[sumLength];

            chars1.CopyTo(charsSum, 0);
            chars2.CopyTo(charsSum, chars1.Length);

            MyString myString = new MyString();
            myString.Value = myString.ConvertToString(charsSum);

            return myString;
        }

        public int IndexOf(MyString myString)
        {
            char[] chars2 = myString._chars;
            bool isEquals = false;
            int index = -1;

            if (_chars.Length >= chars2.Length && chars2.Length != 0)
            {
                index = Array.IndexOf(_chars, chars2[0]);

                if (index >= 0)
                {
                    do
                    {
                        index = Array.IndexOf(_chars, chars2[0], index);

                        if (chars2.Length <= _chars.Length - index)
                        {
                            isEquals = true;

                            for (int i = 0; i < chars2.Length; i++)
                            {
                                if (_chars[index + i] != chars2[i])
                                {
                                    isEquals = false;
                                    index++;
                                    break;
                                }
                            }
                        }

                        if (isEquals)
                            break;

                    } while (index < _chars.Length);
                }
            }
            return index;
        }

        private string ConvertToString(char[] chars)
        {
            StringBuilder sb = new StringBuilder(chars.Length);

            for (int i = 0; i < chars.Length; i++)
            {
                sb.Append(chars[i]);
            }
            return sb.ToString();
        }
        private bool Equals(MyString myString)
        {
            if (ReferenceEquals(myString, null)) return false;
            if (ReferenceEquals(myString, this)) return true;
            return Array.Equals(_chars, myString._chars);
        }

    }

}
