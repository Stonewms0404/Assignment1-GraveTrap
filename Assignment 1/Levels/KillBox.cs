using Godot;
using System;

public partial class KillBox : Area2D
{
	private void _on_body_entered(Node2D body)
	{
		if (body is Player player)
		{
			player.Death("Fell into grave.");
		}
	}
}
