using Godot;
using System;

public partial class PlayerCamera : Camera2D
{
	[Export]
	public AnimationPlayer anim;

	public void Hit()
	{
		Random rand = new Random();
		int num = rand.Next(1,3);
		
		switch (num)
		{
			case 1:
				anim.Play("ScreenShake1");
				break;
			case 2:
				anim.Play("ScreenShake2");
				break;
			case 3:
				anim.Play("ScreenShake3");
				break;
		}
	}

	public void Death()
	{
		anim.Play("Death");
	}
}
