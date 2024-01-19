using Godot;
using System;

public partial class Heart : TextureRect
{
	[Export]
	public AnimationPlayer anim;
	[Export]
	public PlayerHealth phealth;
	[Export]
	public int HeartNum;

	private bool IsHit = false;

	public override void _Ready()
	{
		phealth.ChangeHealth += _OnPlayerHealthChangeHealth;
	}

	public void _OnPlayerHealthChangeHealth(int value)
	{
		if (value == 0)
		{
			Visible = false;
		}
		if (!IsHit && value <= HeartNum)
		{
			anim.Play("PlayerHit");
			IsHit = true;
		}
	}
}
