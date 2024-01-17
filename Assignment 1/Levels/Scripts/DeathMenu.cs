using Godot;
using System;

public partial class DeathMenu : Control
{
	public Label DeathBy;

	[Export]
	public Button TryAgainButton;
	[Export]
	public Player player;
	[Export]
	public GameManager gamemanager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DeathBy = (Label)GetNode("TextureRect/DeathBy");
		Hide();
		player.ToggleDeathMenu += _OnPlayerToggleDeathMenu;
	}

	// Signal for pausing and unpausing the game.
	public void _OnPlayerToggleDeathMenu(String DeathMsg)
	{
		DeathBy.Text = DeathMsg;
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
	
	private void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
