using Godot;
using System;

public partial class GameManager : Node
{
	[Signal]
	public delegate void ToggleGamePausedEventHandler(bool IsPaused);

	[Export]
	public AudioStreamPlayer MainMusic;
	[Export]
	public Player player;

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
			MainMusic.StreamPaused = !MainMusic.StreamPaused;
			SetGamePaused(!GamePaused);
		}
	}

	public void _on_player_toggle_death_menu()
	{
		MainMusic.Playing = false;
		AbleToPause = false;
		GetTree().ChangeSceneToFile("res://Levels/Menus/DeathMenu.tscn");
	}

	public void _on_player_toggle_win_menu()
	{
		MainMusic.Playing = false;
		AbleToPause = false;
		GetTree().ChangeSceneToFile("res://Levels/Menus/WinMenu.tscn");
	}

	public void SetGamePaused(bool IsGamePaused)
	{
		MainMusic.StreamPaused = IsGamePaused;
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
