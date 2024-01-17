using Godot;
using System;

public partial class TextureProgressBar : Godot.TextureProgressBar
{
	public Timer Cooldown;

	[Signal]
	public delegate void CooldownOverEventHandler();

	[Export]
	public Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		Cooldown = (Timer)GetNode("DashCooldown");
		player.StartDashCooldown += _OnPlayerStartDashCooldown;
	}

	public override async void _PhysicsProcess(double delta)
	{
		if (Cooldown.TimeLeft != 2.0f)
		{
			Value = 100.0f - Cooldown.TimeLeft * 50.0f;
		}
	}

	public void _on_dash_cooldown_timeout()
	{
		Hide();
		EmitSignal("CooldownOver");
	}

	public void _OnPlayerStartDashCooldown()
	{
		Show();
		Cooldown.Start();
	}
}