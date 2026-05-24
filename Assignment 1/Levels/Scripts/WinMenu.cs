using Godot;
using System;

public partial class WinMenu : Node2D
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
		if (Global.Instance.LevelNum == 3)
		{
			NextLevelButton.Visible = false;
			NextLevelButton.FocusButton();
		}
		else
		{
            MainMenuButton.FocusButton();
		}
	}
	
	private void _on_main_menu_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/Menus/MainMenu.tscn");
	}

	private void _on_next_level_button_pressed()
	{
		int levelNum = Global.Instance.LevelNum + 1;
		String scene = "res://Levels/game_manager_level_" + levelNum.ToString() + ".tscn";
		GetTree().ChangeSceneToFile(scene);
	}
	
	private void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
