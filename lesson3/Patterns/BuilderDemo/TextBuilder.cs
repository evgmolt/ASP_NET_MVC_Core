using System;

namespace BuilderDemo
{
    public static class TextBuilder
    {
        public static Text Font(this Text text, Fonts font)
        {
            text.Font = Enum.GetName(typeof(Fonts), font);
            return text;
        }

        public static Text Size(this Text text, int size)
        {
            const int MinFontSize = 6;
            const int MaxFontSize = 72;

            if (size <= MinFontSize)
            {
                text.Size = MinFontSize;
            }
            else if (size >= MaxFontSize)
            {
                text.Size = MaxFontSize;
            }
            else
            {
                text.Size = size;
            }
            return text;
        }

        public static Text Color(this Text text, ConsoleColor color)
        {
            text.Color = color;
            return text;
        }

        public static Text BackgroundColor(this Text text, ConsoleColor color)
        {
            text.BackgroundColor = color;
            return text;
        }

        public static Text Bold(this Text text, bool bold)
        {
            text.Bold = bold;
            return text;
        }

        public static Text Italic(this Text text, bool italic)
        {
            text.Italic = italic;
            return text;
        }

        public static Text Underline(this Text text, bool underline)
        {
            text.Underline = underline;
            return text;
        }

        public static Text HeaderLevel(this Text text, int headerLevel)
        {
            const int NormalText = 0;
            const int MinHeader = 6;

            if (headerLevel <= NormalText)
            {
                text.HeaderLevel = NormalText;
            }
            else if (headerLevel >= MinHeader)
            {
                text.HeaderLevel = MinHeader;
            }
            else
            {
                text.HeaderLevel = headerLevel;
            }
            return text;
        }
    }
}
