using Godot;
using System;

public partial class AttackComponent : Node2D
{
	private int Attack;

	public void SetAttack(int amount)
	{
		Attack = amount;
	}
	public int GetAttack()
	{
		return Attack;
	}
}
