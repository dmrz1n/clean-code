﻿namespace Markdown.TagEvents
{
    public class TagEvent
    {
        public TagSide Side;
        public TagName Name;
        public string Content;

        public TagEvent()
        {
            Side = TagSide.None;
            Name = TagName.Text;
            Content = "";
        }

        public TagEvent(TagSide side, TagName name, string content)
        {
            Side = side;
            Name = name;
            Content = content;
        }

        public static TagEvent GetHeaderTagEvent(char symbol)
        {
            return symbol == '#'
                ? new TagEvent(TagSide.Left, TagName.Header, symbol.ToString())
                : new TagEvent(TagSide.Right, TagName.Header, symbol.ToString());
        }
        public static TagEvent GetTextTagEvent(string content)
            => new TagEvent(TagSide.None, TagName.Text, content);

        public override string ToString()
        {
            return $"Content = {Content}\n";
        }

        public bool IsUnderliner()
            => Name == TagName.Underliner || Name == TagName.DoubleUnderliner;

        public bool IsTextContainingWhitespace()
            => Name == TagName.Text && Content.Contains(" ");

        public void ChangeMarkAndSideTo(TagName mark, TagSide side)
        {
            Name = mark;
            Side = side;
        }

        public void ChangeSideTo(TagSide side)
            => Side = side;

        public void ChangeMarkTo(TagName newMark)
            => Name = newMark;

        public bool IsPlainText()
            => Name == TagName.Text;

        public bool IsEmpty()
            => string.IsNullOrEmpty(this.Content);

        public bool IsSideUnknown()
            => Side == TagSide.Unknown;
    }
}