using Godot;
using System;

public partial class PlayerHealth : Control
{
	[Export]
	public Player player;
	[Signal]
	public delegate void ChangeHealthEventHandler(int value);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player.Hit += _OnPlayerHit;
	}

	public void _OnPlayerHit(int health)
	{
		EmitSignal("ChangeHealth", health);
	}
}
