using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexHelper;

public class Util
{
    public static List<(int, int)> GetPairs(string input, char start, char end)
    {
        Log.LogExecutionTime();
        var pairs = new List<(int, int)>();
        var stack = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == start && (i == 0 || input[i - 1] != '\\'))
            {
                stack.Push(i);
            }
            else if (input[i] == end && (i == 0 || input[i - 1] != '\\'))
            {
                if (stack.Count > 0)
                {
                    int openingIndex = stack.Pop();
                    pairs.Add((openingIndex, i));
                }
                else
                {

                }
            }
        }

        if (stack.Count > 0)
        {
        }

        Log.LogExecutionTime();
        return pairs;
    }


    public static void MarkTextFull(int indexStart, int indexEnd, Color color, Color colorBack, RichTextBox input)
    {
        input.SelectionStart = indexStart;
        input.SelectionLength = indexEnd - indexStart;
        input.SelectionColor = color;
        //input.SelectionBackColor = colorBack;
    }

    //void MarkText(int indexStart, int indexEnd, Color color, RichTextBox regexInput)
    //{
    //    regexInput.SelectionStart = indexStart;
    //    regexInput.SelectionLength = 1;
    //    regexInput.SelectionColor = color;

    //    regexInput.SelectionStart = indexEnd;
    //    regexInput.SelectionLength = 1;
    //    regexInput.SelectionColor = color;
    //}

    //static List<(int, int)> GetBracketPairs(string input)
    //{
    //    var pairs = new List<(int, int)>();
    //    var stack = new Stack<int>();

    //    for (int i = 0; i < input.Length; i++)
    //    {
    //        if (input[i] == '(' && (i == 0 || input[i - 1] != '\\'))
    //        {
    //            stack.Push(i);
    //        }
    //        else if (input[i] == ')' && (i == 0 || input[i - 1] != '\\'))
    //        {
    //            if (stack.Count > 0)
    //            {
    //                int openingIndex = stack.Pop();
    //                pairs.Add((openingIndex, i));
    //            }
    //            else
    //            {

    //            }
    //        }
    //    }

    //    if (stack.Count > 0)
    //    {
    //    }

    //    return pairs;
    //}
}
