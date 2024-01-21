using Godot;
using System;

public partial class MainMenu : Control
{
	[Export]
	public Button StartButton;
	[Export]
	public AudioStreamPlayer Music;
	[Export]
	public AudioStreamPlayer StartGameSound;
	[Export]
	public Timer StartTimer;

	public override void _Ready()
	{
		GetTree().Paused = false;
		StartButton.FocusButton();
	}

	public void _on_start_timer_timeout()
	{
		GetTree().ChangeSceneToFile("res://Levels/game_manager_level_1.tscn");
	}

	private void _on_start_button_pressed()
	{
		StartGameSound.Playing = true;
		StartTimer.Start();
	}
	
	private void _on_credits_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/Menus/CreditsMenu.tscn");
	}
	
	private void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
