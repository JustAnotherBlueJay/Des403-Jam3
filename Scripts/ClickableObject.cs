using Godot;
using System;
using System.Threading.Tasks;

public partial class ClickableObject : Button
{
	[Export] private ShaderMaterial highlightShader;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += OnButtonPressed;

		Material = new Material();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnButtonPressed()
	{
		GD.Print("Hello World");
	}


}
