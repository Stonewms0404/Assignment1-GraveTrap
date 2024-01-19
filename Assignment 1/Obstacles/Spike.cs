using Godot;
using System;

public partial class Spike : StaticBody2D
{
	[Export]
	public AttackComponent Attack;
	
	private String DeathBy = "Death by Spike.";

	public override void _Ready()
	{
		Attack.SetAttack(2);
	}

	// Called when an entity enters the collision shape.
	public void _on_hitbox_body_entered(Node2D body)
	{
		if (body is Player player)
		{
			player.HitPlayer(Attack.GetAttack(), DeathBy);
		}
	}
}
