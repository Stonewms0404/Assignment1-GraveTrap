using Godot;
using System;

public partial class Thorns : StaticBody2D
{
	[Export]
	public AttackComponent Attack;
	[Export]
	public HealthComponent Health;

	[Signal]
	public delegate void PlayParticleEventHandler(Vector2 ThornPosition);
	
	public Sprite2D sprite;
	public Texture2D DamagedThorn;
	public Texture2D FullThorn;
	private int hitpoints;
	private string DeathBy = "";

	public override void _Ready()
	{
		DamagedThorn = (Texture2D)GD.Load("res://Assets/Obstacles/Thorn2.png");
		FullThorn = (Texture2D)GD.Load("res://Assets/Obstacles/Thorn1.png");
		sprite = (Sprite2D)GetNode("Sprite2D");
		Random rand = new Random();
		hitpoints = rand.Next(1,3);
		Attack.SetAttack(1);
		Health.SetHealth(hitpoints);
		CheckHealth();
	}

	public void _on_hitbox_body_entered(Node2D body)
	{
		if (body is Player player)
		{
			player.HitPlayer(Attack.GetAttack(), DeathBy);
		}
		if (body is Sword sword)
		{
			EmitSignal("PlayParticle", GlobalPosition);
			hitpoints -= sword.Attack.GetAttack();
			Health.SetHealth(hitpoints);
			CheckHealth();
		}
	}

	private void CheckHealth()
	{
		if (Health.GetHealth() == 2)
		{
			sprite.Texture = FullThorn;
		}
		else if (Health.GetHealth() == 1)
		{
			sprite.Texture = DamagedThorn;
		}
		else
		{
			QueueFree();
		}
	}
}
