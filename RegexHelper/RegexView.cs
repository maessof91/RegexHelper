using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexHelper;

public class RegexView
{
    public static string AlterRegexViewText(string regexPattern)
    {
        var text = regexPattern;

        text = text.Replace(@"[\s\S\r\n]", "●");
        text = text.Replace(@"[\s\S\n\r]", "●");
        text = text.Replace(@"[\s\r\S\n]", "●");
        text = text.Replace(@"[\s\r\n\S]", "●");
        text = text.Replace(@"[\s\n\S\r]", "●");
        text = text.Replace(@"[\s\n\r\S]", "●");
        text = text.Replace(@"[\S\s\r\n]", "●");
        text = text.Replace(@"[\S\s\n\r]", "●");
        text = text.Replace(@"[\S\r\s\n]", "●");
        text = text.Replace(@"[\S\r\n\s]", "●");
        text = text.Replace(@"[\S\n\s\r]", "●");
        text = text.Replace(@"[\S\n\r\s]", "●");
        text = text.Replace(@"[\r\s\S\n]", "●");
        text = text.Replace(@"[\r\s\n\S]", "●");
        text = text.Replace(@"[\r\S\s\n]", "●");
        text = text.Replace(@"[\r\S\n\s]", "●");
        text = text.Replace(@"[\r\n\s\S]", "●");
        text = text.Replace(@"[\r\n\S\s]", "●");
        text = text.Replace(@"[\n\s\S\r]", "●");
        text = text.Replace(@"[\n\s\r\S]", "●");
        text = text.Replace(@"[\n\S\s\r]", "●");
        text = text.Replace(@"[\n\S\r\s]", "●");
        text = text.Replace(@"[\n\r\s\S]", "●");
        text = text.Replace(@"[\n\r\S\s]", "●");

        text = text.Replace("\\r?\\n", "⏎");
        text = text.Replace("\\r", "`r");
        text = text.Replace("\\n", "`n");

        text = text.Replace("\\w", "💬");
        text = text.Replace("\\d", "🔟");
        //text = text.Replace(".", "🤷‍");
        text = text.Replace("^", "🏁");
        text = text.Replace("$", "🔚");
        text = text.Replace("\\b", "🎁");
        //text = text.Replace("+", "🍄");
        //text = text.Replace("*", "♾");
        //text = text.Replace("?", "❓");
        text = text.Replace("\\s", "﹏");

        text = text.Replace("\\", "\u200D");
        text = text.Replace("(", "\u200B");
        text = text.Replace(")", "\u200C");
        text = text.Replace("\u200D" + "\u200B", "\u200D" + "(");
        text = text.Replace("\u200D" + "\u200C", "\u200D" + ")");
        return text;
    }
}
