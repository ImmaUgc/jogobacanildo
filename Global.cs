using Godot;
using System;
public partial class Global : Node
{
	public static int Gravity = 980;
	public static CameraComponent Camera { get; set; }

	public void SetCamera(CameraComponent Cam) {
		Camera = Cam;
	}
    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("Swap")) {
			Camera.Swap();
		}
    }
}
