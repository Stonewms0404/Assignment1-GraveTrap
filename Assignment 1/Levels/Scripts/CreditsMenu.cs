using Godot;
using System;

public partial class CreditsMenu : Control
{
	public Button BackButton;

	public override void _Ready()
	{
		BackButton = (Button)GetNode("BackgroundMovement/BackButton");
		BackButton.FocusButton();
	}

	public void _on_back_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/Menus/MainMenu.tscn");
	}

	public void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
