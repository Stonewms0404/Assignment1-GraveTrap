using Godot;
using System;

public partial class BackgroundMovement : CharacterBody2D
{
	public const float Speed = 30.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		velocity.X = Speed;
		
		Velocity = velocity;
		MoveAndSlide();
	}

	public void AddFade(PackedScene Fade)
	{
		Node fade = Fade.Instantiate();
		AddChild(fade);
	}
}
