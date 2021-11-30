using System;

namespace BuilderDemo
{
    public class Text
    {
        public ConsoleColor Color { get; internal set; } = ConsoleColor.White;
        public ConsoleColor BackgroundColor { get; internal set; } = ConsoleColor.Black;
        public bool Bold { get; internal set; } = false;
        public bool Italic { get; internal set; } = false;
        public bool Underline { get; internal set; } = false;
        public string Content { get; internal set; } = "";
        public int HeaderLevel { get; internal set; } = 0;
        public string Font { get; internal set; } = "Arial";
        public int Size { get; internal set; } = 12;

        public Text(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }
            Content = content;
        }

        public string GetText()
        {
            var mainTag = HeaderLevel == 0 ? "P" : $"H{HeaderLevel}";

            var formatedContent = $"<{mainTag} style=\"background-color: {BackgroundColor};\">" +
                $"<FONT size=\"{Size}\" color=\"{Color}\" face=\"{Font}\">" +
                (Bold == true ? "<STRONG>" : "") +
                (Italic == true ? "<EM>" : "") +
                (Underline == true ? "<U>" : "") +
                Content +
                (Underline == true ? "</U>" : "") +
                (Italic == true ? "</EM>" : "") +
                (Bold == true ? "</STRONG>" : "") +
                $"</FONT></{mainTag}>";

            return formatedContent;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
