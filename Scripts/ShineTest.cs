using Godot;
using System;

public partial class ShineTest : TextureRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Space))
		{
			Shine(0.5f);

		}
	}

	private void Shine(float length)
	{
		ResetShader();

		Tween progressTween = CreateTween();

        progressTween.SetTrans(Tween.TransitionType.Sine);
        progressTween.SetEase(Tween.EaseType.In);
        progressTween.TweenProperty(Material, "shader_parameter/shine_progress",1.0,length);

		Tween sizeTween = CreateTween();
		sizeTween.SetTrans(Tween.TransitionType.Cubic);
		sizeTween.SetEase(Tween.EaseType.In);
		sizeTween.TweenProperty(Material, "shader_parameter/shine_size",0.5,length);


	}

	private void ResetShader()
	{
        (Material as ShaderMaterial).SetShaderParameter("shine_progress", 0.0);
        (Material as ShaderMaterial).SetShaderParameter("shine_size", 0.05);


    }
}
