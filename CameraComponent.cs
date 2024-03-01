using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class CameraComponent : Node
{

	[Export]
	public Character[] Focuses;

	public Character Focus;
	public int FocusIndex;

	[Export]
	public float Speed = 3.0f;

	public Camera2D Camera;

    public override void _Ready()
    {
		Focus = Focuses[0];
		FocusIndex = 0;
        Camera = new();
		Camera.Zoom = new Vector2(5, 5);
		Camera.GlobalPosition = Focus.GlobalPosition;
		AddChild(Camera);
		Global G = GetNode<Global>("/root/Global");
		G.SetCamera(this);
    }

	public void Swap() {
		if(FocusIndex + 1 > Focuses.Length - 1) FocusIndex = -1;
		Focus.Can_Move = false;
		FocusIndex += 1;
		Focus = Focuses[FocusIndex];
		Focus.Can_Move = true;
	}

    public override void _Process(double delta)
	{
		Camera.GlobalPosition = new Vector2((float)Mathf.Lerp(Camera.GlobalPosition.X, Focus.GlobalPosition.X, delta * Speed), (float)Mathf.Lerp(Camera.GlobalPosition.Y, Focus.GlobalPosition.Y, delta * Speed));
	}
}
