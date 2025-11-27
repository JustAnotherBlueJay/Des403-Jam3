using Godot;
using System;

public partial class ObjectBox : TextureRect
{
	Texture2D obtainedObjectTexture;

	[Export] TextureRect objectIcon;

    public override void _Ready()
    {
		obtainedObjectTexture = GD.Load<Texture2D>("uid://bjdp8d2x2icdr");

		if (objectIcon == null )
		{
			objectIcon = GetChild<TextureRect>(0);
		}
    }
    public void OnObjectObtained()
	{
		this.Texture = obtainedObjectTexture;
		objectIcon.Visible = true;
	}
	
}
