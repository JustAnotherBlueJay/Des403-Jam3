using Godot;
using System;
using System.ComponentModel;

public partial class ClickableObject : Control
{
    [Export] Button myButton;

    //text to write to the output label
    [Export] string myText;

    //label to write text to
    [Export] TextManager textManager;
    [Export] ObjectBox myObjectBox;

    public Action E_Clicked;

    public override void _Ready()
    {
        myButton.Pressed += OnObjectClicked;
    }

    private void OnObjectClicked()
    {

        //emmit the clicked signal
        E_Clicked();

        //add this objects text to the output 
        textManager.AddEntry(myText);
        //disconnect from the buttons signal
        myButton.Pressed -= OnObjectClicked;

        //show the objects icon and change the outline
        myObjectBox.OnObjectObtained();
    }
}
