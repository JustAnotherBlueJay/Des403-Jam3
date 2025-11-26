using Godot;
using System;

public partial class TextManager : RichTextLabel
{

    public void AddEntry(string text)
    {
        Text += $"- {text}\n\n";
    }
}
