using Godot;
using System;

public partial class HealthComponent : Node2D
{
	private int Health;

	public void SetHealth(int amount)
	{
		Health = amount;
	}
	public int GetHealth()
	{
		return Health;
	}

	public int TookDamage(int amount)
	{
		Health -= amount;
		return Health;
	}
}
