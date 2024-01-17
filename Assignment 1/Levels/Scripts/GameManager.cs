using Godot;
using System;

public partial class GameManager : Node
{
	[Signal]
	public delegate void ToggleGamePausedEventHandler(bool IsPaused);

	public bool GamePaused = false;
	public bool AbleToPause = false;

	public override void _Ready()
	{
		SetGamePaused(false);
		AbleToPause = true;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("pause") && AbleToPause)
		{
			SetGamePaused(!GamePaused);
		}
	}

	public void _OnPlayerPlayerDeath(String DeathMsg)
	{
		AbleToPause = false;
		SetGamePaused(true);
	}

	public void SetGamePaused(bool IsGamePaused)
	{
		GamePaused = IsGamePaused;
		GetTree().Paused = GamePaused;
		EmitSignal("ToggleGamePaused", GamePaused);
	}


}
