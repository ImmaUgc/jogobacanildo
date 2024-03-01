using Godot;
using System;

[GlobalClass]
public partial class Character : CharacterBody2D
{
	[Export]
	public int Speed = 100;

	[Export]
	public int Jump_Power = 300;

	[Export]
	public bool Can_Move = false;

	public void Movement(double delta) {
		if(!Can_Move) {
			Modulate = Modulate.Lerp(Color.FromHtml("#222222"), (float)delta);
			return;
		}
		Modulate = Modulate.Lerp(Color.FromHtml("#ffffff"), (float)delta);

		Vector2 velocity = Velocity;
		Vector2 direction = new Vector2(Input.GetAxis("Move left", "Move right"), 0);

		if(!IsOnFloor()) {
			velocity.Y += Global.Gravity * (float)delta;
		}

		if(Input.IsActionJustPressed("Jump") && IsOnFloor()) {
			velocity.Y -= Jump_Power;
		}

		if(direction != Vector2.Zero) {
			velocity.X = direction.X * Speed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	public override void _Process(double delta)
	{
		Movement(delta);
	}
}
