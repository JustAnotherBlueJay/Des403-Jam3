using Godot;
using System;

public partial class UserInterface : Control
{
	[Export] Control clickableObectsParent;
	[Export] Button continueButton;

	//toatl number of clickable objects
	private int numberOfObjects;

	//number of clickable objects that have been clicked
	private int clickedCount = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		numberOfObjects = clickableObectsParent.GetChildCount();

		foreach (ClickableObject clickableObject in clickableObectsParent.GetChildren())
		{
			clickableObject.E_Clicked += OnClickableObjectClicked;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnClickableObjectClicked()
	{
		clickedCount += 1;

		if (clickedCount == numberOfObjects)
		{
			EnableContinueButton();
		}

	}

	private void EnableContinueButton()
	{
		//make the button visible and listen for when its pressed
		continueButton.Visible = true;
        continueButton.Pressed += OnContinueButtonPressed;
	}

    private void OnContinueButtonPressed()
    {
		//disconect
		continueButton.Pressed -= OnContinueButtonPressed;

		GameManager.TransitionToNextScene();
    }
}
