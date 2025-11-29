using Godot;
using System;

public partial class ReflectionScene : Control
{
    [Export] Button continueButton;

    public override void _Ready()
    {
        continueButton.Pressed += OnContinueButtonPressed;
    }

    private void OnContinueButtonPressed()
    {
        GameManager.TransitionToNextScene();
    }
}
