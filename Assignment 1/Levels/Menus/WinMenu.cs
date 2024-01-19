using Godot;
using System;

public partial class WinMenu : Control
{
	[Export]
	public Button TryAgainButton;
	[Export]
	public Button NextLevelButton;
	[Export]
	public Player player;
	[Export]
	public GameManager gamemanager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		player.ToggleWinMenu += _OnPlayerToggleWinMenu;
	}

	// Signal for pausing and unpausing the game.
	public void _OnPlayerToggleWinMenu()
	{
		gamemanager.AbleToPause = false;

		GetTree().Paused = true;
		Show();
		TryAgainButton.FocusButton();
	}

	private void _on_try_again_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/GameManager.tscn");
	}
	
	private void _on_main_menu_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/Menus/MainMenu.tscn");
	}

	private void _on_next_level_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/Menus/MainMenu.tscn");
	}
	
	private void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
