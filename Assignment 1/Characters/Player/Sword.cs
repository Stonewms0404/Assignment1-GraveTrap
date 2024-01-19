using Godot;
using System;

public partial class Sword : CharacterBody2D
{
	[Export]
	public CollisionShape2D coll;
	[Export]
	public AttackComponent Attack;

	public override void _Ready()
	{
		Attack.SetAttack(1);
	}
}
