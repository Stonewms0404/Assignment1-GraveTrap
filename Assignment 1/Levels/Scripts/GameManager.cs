using Godot;
using System;

public partial class GameManager : Node
{
	[Signal]
	public delegate void ToggleGamePausedEventHandler(bool IsPaused);

	[Export]
	public AudioStreamPlayer MainMusic;

	public bool GamePaused = false;
	public bool AbleToPause = false;
	private int LevelNumber;

	public override void _Ready()
	{
		SetGamePaused(false);
		AbleToPause = true;
	}

	public void SetLevelNumber(int LevelNum)
	{
		LevelNumber = LevelNum;
	}

	public int GetLevelNumber()
	{
		GD.Print(LevelNumber);
		return LevelNumber;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("pause") && AbleToPause)
		{
			MainMusic.StreamPaused = !MainMusic.StreamPaused;
			SetGamePaused(!GamePaused);
		}
	}

	public void PlayerDeath()
	{
		MainMusic.Playing = false;
		AbleToPause = false;
	}

	public void SetGamePaused(bool IsGamePaused)
	{
		GamePaused = IsGamePaused;
		GetTree().Paused = GamePaused;
		EmitSignal("ToggleGamePaused", GamePaused);
	}

	public void _OnPlayerPlayerWin()
	{
		AbleToPause = false;
		MainMusic.Playing = false;
	}
}
