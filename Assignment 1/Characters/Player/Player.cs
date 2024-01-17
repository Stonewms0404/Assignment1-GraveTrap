using Godot;
using System;

public partial class Player : CharacterBody2D
{
	//Normal Movement varibles.
	public float Speed;
	public float MaxSpeed;
	public int facing = 0;
	public const float JumpVelocity = -600.0f;
	public float movement = 0.0f;
	public bool CanDash = true;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	//Animation Variable.
	protected AnimationPlayer anim;

	[Signal]
	public delegate void ToggleDeathMenuEventHandler(String DeathMsg);
	[Signal]
	public delegate void StartDashCooldownEventHandler();
	
	[Export]
	public GameManager gamemanager;
	[Export]
	public TextureProgressBar DashCooldown;
	[Export]
	public HealthComponent Health;
	[Export]
	public AttackComponent Attack;

	
	//When the game first loads.
	public override void _Ready()
	{
		Attack.SetAttack(1);
		Health.SetHealth(3);
		facing = 1;
		DashCooldown.CooldownOver += _OnDashCooldownCooldownOver;
		anim = (AnimationPlayer)GetNode("AnimationPlayer");
		anim.Active = true;
		anim.Play("Idle_Left");
	}
	
	//Runs Every Frame.
	public override async void _PhysicsProcess(double delta)
	{
		//Variable Declarations.
		Vector2 velocity = Velocity;
		// Gets the input directions and subtracts them.
		float MoveInput = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		int direction = (int)MoveInput;

		//Creates the move direction by the speed and direction.
		velocity = MovePlayer(velocity, MoveInput);

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity = Jump(velocity);
		}
		
		//Set Animation of the player.
		SetAnimation(anim, velocity, direction);

		// Calls the function for dashing and checks input within the dashing function.
		velocity = Dash(velocity);
		
		Velocity = velocity;
		Velocity.Normalized();
		MoveAndSlide();
	}
	
	//Move the Player Function.
	public Vector2 MovePlayer(Vector2 velocity, float MoveInput)
	{
		if (MoveInput != 0)
		{
			if (MoveInput < 0)
			{
				facing = -1;
			}
			else if (MoveInput > 0)
			{
				facing = 1;
			}
			movement = velocity.X + (Speed * facing);
			movement = (float)Math.Clamp(movement, -MaxSpeed, MaxSpeed);
			velocity.X = movement;
		}
		else
		{
			if (facing == -1 && IsOnFloor())
			{
				movement = velocity.X - 2 * (Speed * facing);
				movement = (float)Math.Clamp(movement, -MaxSpeed, 0);
			}
			else if (facing == 1 && IsOnFloor())
			{
				movement = velocity.X - 2 * (Speed * facing);
				movement = (float)Math.Clamp(movement, 0, MaxSpeed);
			}
			else if (facing == -1 && !IsOnFloor())
			{
				movement = velocity.X - 0.5f * (Speed * facing);
				movement = (float)Math.Clamp(movement, -MaxSpeed, 0);
			}
			else if (facing == 1 && !IsOnFloor())
			{
				movement = velocity.X - 0.5f * (Speed * facing);
				movement = (float)Math.Clamp(movement, 0, MaxSpeed);
			}
			velocity.X = movement;
		}

		return velocity;
	}

	//Animation Function.
	public void SetAnimation(AnimationPlayer anim, Vector2 velocity, int direction)
	{
		if (velocity.Y == 0)
		{
			switch (direction)
			{
				case 0:
					if (facing == -1)
						anim.Play("Idle_Left");
					else if (facing == 1)
						anim.Play("Idle_Right");
					break;
				case 1:
					anim.Play("Walk_Right");
					break;
				case -1:
					anim.Play("Walk_Left");
					break;
			}
		}
		else if (velocity.Y > 0)
		{
			if (facing == -1)
				anim.Play("Falling_Left");
			else if (facing == 1)
				anim.Play("Falling_Right");
		}
		else if (velocity.Y < 0)
		{
			if (facing == -1)
				anim.Play("JumpUp_Left");
			else if (facing == 1)
				anim.Play("JumpUp_Right");
		}
	}

	//Jump Function for anything related to Jumping.
	protected Vector2 Jump(Vector2 velocity)
	{
		velocity.Y = JumpVelocity;
		return velocity;
	}
	
	//Player Death Function for anything related to the player's death.
	public void Death(String DeathBy)
	{
		GD.Print(DeathBy);
		EmitSignal("ToggleDeathMenu", DeathBy);
	}

	//The Player's Dash Function for calculating if the player can dash or not.
	public Vector2 Dash(Vector2 velocity)
	{
		if (Input.IsActionJustPressed("dash") && CanDash)
		{
			CanDash = false;
			velocity.X = 15000.0f * facing;
			velocity.Y = 0;
			EmitSignal("StartDashCooldown");
		}
		return velocity;
	}

	//Once the dash cooldown is over this function is called to set the can dash boolean to true.
	public void _OnDashCooldownCooldownOver()
	{
		CanDash = true;
	}

	public void HitPlayer(int amount, String DeathBy)
	{
		Health.TookDamage(amount);
		if (Health.GetHealth() <= 0)
		{
			Death(DeathBy);
		}
	}
}
