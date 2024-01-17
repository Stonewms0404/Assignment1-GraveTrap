using Godot;
using System;

public partial class MainMenu : Control
{
	[Export]
	public Button StartButton;

	public override void _Ready()
	{
		GetTree().Paused = false;
		StartButton.FocusButton();
	}

	private void _on_start_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/GameManager.tscn");
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
