using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexHelper;

public class WhiteSpace
{
    private const string SpaceReplacementInView = "∘";

    private const string TabReplacementInView = "→";

    private const string crlfNewLineReplacementInView = "↵↲\r\n";

    private const string lfNewLineReplacementInView = "↲\n";

    private const string crlfSymbol = "↵↲";

    private const string crSymbol = "↵";

    private const string lfSymbol = "↲";

    public static string ToVisibleNewLine(string text)
    {
        if (text.Contains("\r\n"))
        {
            text = text.Replace("\r\n", crlfSymbol + "\n");
        }
        else
        {
            text = text.Replace("\n", lfSymbol + "\n");
        }
        return text;
    }

    public static string searchToVisibleNewLine(string text)
    {
        if (text.Contains("\\r\\n"))
        {
            text = text.Replace("\\r\\n", crlfSymbol + "\\n");
        }
        else
        {
            text = text.Replace("\\n", lfSymbol + "\\n");
        }

        text = text.Replace("\\r", crSymbol);
        return text;
    }

    public static string ToViewableWhitespace(string text)
    {
        text = text.Replace(" ", SpaceReplacementInView);
        text = text.Replace("\t", TabReplacementInView);

        if (text.Contains("\r\n"))
        {
            text = text.Replace("\r\n", crlfNewLineReplacementInView);
        }
        else
        {
            text = text.Replace("\n", lfNewLineReplacementInView);
        }

        return text;
    }


    public static string ToInvisibleWhiteSpace(string text)
    {
        text = text.Replace(SpaceReplacementInView, " ");
        text = text.Replace(TabReplacementInView, "\t");

        if (text.Contains("\r\n"))
        {
            text = text.Replace(crlfNewLineReplacementInView, "\n");
        }
        else
        {
            text = text.Replace(lfNewLineReplacementInView, "\n");
        }

        return text;
    }

}
