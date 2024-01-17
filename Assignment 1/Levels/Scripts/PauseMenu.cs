using Godot;
using System;

public partial class PauseMenu : Control
{
	[Export]
	public GameManager gamemanager;
	[Export]
	public Button ResumeButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		gamemanager.ToggleGamePaused += _OnGameManagerToggleGamePaused;
	}

	// Signal for pausing and unpausing the game.
	public void _OnGameManagerToggleGamePaused(bool IsPaused)
	{
		if(IsPaused)
		{
			Show();
			ResumeButton.FocusButton();
		}
		else
		{
			Hide();
		}
	}

	public void _on_resume_button_pressed()
	{
		gamemanager.SetGamePaused(false);
	}

	public void _on_main_menu_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/Menus/MainMenu.tscn");
	}

	public void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
