using Godot;
using System;

public partial class PlayerHealth : Control
{
	[Export]
	public Player player;
	[Signal]
	public delegate void ChangeHealthEventHandler(int value);

	public void _on_player_hit(int health)
	{
		EmitSignal("ChangeHealth", health);
	}
}
