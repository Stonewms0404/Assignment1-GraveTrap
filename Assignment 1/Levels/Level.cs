using Godot;
using System;

public partial class Level : Node2D
{
	[Export]
	private int LevelNum;
	[Export]
	public GameManager manager;

	public override void _Ready()
	{
		manager.SetLevelNumber(LevelNum);
	}
	
}