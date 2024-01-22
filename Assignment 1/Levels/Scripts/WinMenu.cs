using Godot;
using System;

public partial class WinMenu : Control
{
	[Export]
	public Button MainMenuButton;
	[Export]
	public Button NextLevelButton;
	[Export]
	public AudioStreamPlayer Music;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Music.Playing = true;
		MainMenuButton.FocusButton();
	}
	
	private void _on_main_menu_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/Menus/MainMenu.tscn");
	}

	private void _on_next_level_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/game_manager_level_2.tscn");
	}
	
	private void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
