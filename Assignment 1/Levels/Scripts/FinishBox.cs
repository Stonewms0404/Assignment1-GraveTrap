using Godot;
using System;

public partial class FinishBox : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public void _on_body_entered(Node2D body)
	{
		if (body is Player player)
		{
			player.Win();
		}
	}
}
