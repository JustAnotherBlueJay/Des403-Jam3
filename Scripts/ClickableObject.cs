using Godot;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

public partial class ClickableObject : Control
{
    [Export] Button myButton;

    //text to write to the output label
    [Export] string myText;

    //label to write text to
    [Export] TextManager textManager;
    [Export] ObjectBox myObjectBox;
    [Export] TextureRect shineTexture;

    public Action E_Clicked;
    private bool hasBeenClicked = false;

    public override void _Ready()
    {
        myButton.Pressed += OnObjectClicked;
        myButton.MouseEntered += OnMouseEnter;
    }

    private void OnObjectClicked()
    {

        //emmit the clicked signal
        E_Clicked();

        hasBeenClicked = true;

        //add this objects text to the output 
        textManager.AddEntry(myText);
        //disconnect from the buttons signal
        myButton.Pressed -= OnObjectClicked;

        //show the objects icon and change the outline
        myObjectBox.OnObjectObtained();
    }

    private bool isShinePlaying = false;
    private async void OnMouseEnter()
    {
        //if there is a shine texture, its not currently playing, and this object hasnt already been clicked play the shine
        if (shineTexture != null && !isShinePlaying && !hasBeenClicked)
        {   
            isShinePlaying=true;
            await Shine(0.5f);
            isShinePlaying = false;
        }
    }

    private async Task Shine(float length)
    {
        ResetShader();

        Tween progressTween = CreateTween();

        progressTween.SetTrans(Tween.TransitionType.Sine);
        progressTween.SetEase(Tween.EaseType.In);
        progressTween.TweenProperty(shineTexture.Material, "shader_parameter/shine_progress", 1.0, length);

        Tween sizeTween = CreateTween();
        sizeTween.SetTrans(Tween.TransitionType.Cubic);
        sizeTween.SetEase(Tween.EaseType.In);
        sizeTween.TweenProperty(shineTexture.Material, "shader_parameter/shine_size", 0.5, length);

        await ToSignal(sizeTween, "finished");
        return;


    }

    private void ResetShader()
    {
        (shineTexture.Material as ShaderMaterial).SetShaderParameter("shine_progress", 0.0);
        (shineTexture.Material as ShaderMaterial).SetShaderParameter("shine_size", 0.05);


    }
}
