using Godot;
using System;

public partial class DashGraves : Node
{
	public AnimationPlayer anim;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		anim = (AnimationPlayer)GetNode("AnimationPlayer");
		anim.Play("DashInstructions");
	}
}
