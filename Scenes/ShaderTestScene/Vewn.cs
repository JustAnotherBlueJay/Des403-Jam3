using Godot;
using System;

public partial class Vewn : Sprite2D
{
	[Export] float minScale = 30f;
	[Export] float maxScale = 32f;

	private int frame = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//TweenPatternScaling(maxScale);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		frame += 1;

		if (frame % 10 == 0)
		{
			SetRandomPatternScaling();
		}

    }

    public override void _PhysicsProcess(double delta)
    {


    }

    private async void TweenPatternScaling(float value)
	{
		Tween tween = CreateTween();
		tween.TweenProperty(Material, "shader_parameter/pattern_scaling", value, 1f);

		await ToSignal(tween, "finished");

		if (value == minScale)
		{
			TweenPatternScaling(maxScale);
		}
		else
		{
			TweenPatternScaling(minScale);
		}

	}

	private void SetRandomPatternScaling()
	{
		(Material as ShaderMaterial).SetShaderParameter("pattern_scaling",GD.RandRange(minScale, maxScale));
	}
}
