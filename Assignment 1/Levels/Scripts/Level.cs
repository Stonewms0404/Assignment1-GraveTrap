using Godot;
using System;

public partial class Base_Game : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("pause"))
		{
			Pause();
		}
	}
	
	public void Pause()
	{
		GetTree().Paused = !GetTree().Paused;
	}
}