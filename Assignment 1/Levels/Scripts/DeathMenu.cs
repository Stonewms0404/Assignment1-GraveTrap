using Godot;
using System;

public partial class DeathMenu : Control
{

	[Export]
	public Button MainMenuButton;
	[Export]
	public AudioStreamPlayer Music;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Music.Playing = true;
		GetTree().Paused = true;
		Show();
		MainMenuButton.FocusButton();
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
