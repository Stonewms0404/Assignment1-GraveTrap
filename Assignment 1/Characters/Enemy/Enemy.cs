using Godot;
using System;
using System.Threading.Tasks;

public partial class Enemy : CharacterBody2D
{
    //Normal Movement varibles.
    public float Speed = 50.0f;
    public float MaxSpeed = 150.0f;

    //Animation Variable.
    protected AnimationPlayer anim;

    [Signal]
    public delegate void HitEventHandler(int amount);
    [Signal]
    public delegate void PlayLandParticleEventHandler(Vector2 PlayerPosition);

    [Export]
    public HealthComponent Health;
    [Export]
    public AudioStreamPlayer Hurt;
    [Export]
    public GpuParticles2D HitParticles;
    [Export]
    public CollisionShape2D Hitbox;
    [Export]
    public Node2D moveLocation1;
    [Export]
    public Node2D moveLocation2;
    [Export]
    public float maxWaitTime = 1.0f;
    float waitTimer = 0.0f;
    int facing = 0;
    int direction = 0;

    Node2D target;

    bool isMovingToLoc1 = true;

    //When the game first loads.
    public override void _Ready()
    {
        Health.SetHealth(2);
        anim = (AnimationPlayer)GetNode("AnimationPlayer");
        anim.Active = true;
        anim.Play("Enemy_Idle_Right");
        target = moveLocation1;
    }

    //Runs Every Frame.
    public override async void _PhysicsProcess(double delta)
    {
        if (Health.GetHealth() == 0)
        {
            if (!anim.IsPlaying())
                QueueFree();
            return;
        }

        //Creates the move direction by the speed and direction.
        if ((moveLocation1.GlobalPosition - GlobalPosition).Length() < 0.2f && isMovingToLoc1)
        {
            if (waitTimer > maxWaitTime)
            {
                waitTimer = 0.0f;
                isMovingToLoc1 = false;
                target = moveLocation2;
                facing = (moveLocation2.GlobalPosition - GlobalPosition).Normalized().X < 0 ? -1 : 1;
                direction = facing;
            }
            else
            {
                waitTimer += (float)delta;
                direction = 0;
            }
        }
        else if ((moveLocation2.GlobalPosition - GlobalPosition).Length() < 0.2f && !isMovingToLoc1)
        {
            if (waitTimer > maxWaitTime)
            {
                waitTimer = 0.0f;
                isMovingToLoc1 = true;
                target = moveLocation1;
                facing = (moveLocation1.GlobalPosition - GlobalPosition).Normalized().X < 0 ? -1 : 1;
                direction = facing;
            }
            else
            {
                waitTimer += (float)delta;
                direction = 0;
            }
        }
        else
        {
            GlobalPosition = GlobalPosition.MoveToward(target.GlobalPosition, (float)delta * Speed);
        }

        SetAnimation(direction, facing);
        await Task.Yield();
    }

    //Animation Function.
    public void SetAnimation(int direction, int facing)
    {
        switch (direction)
        {
            case 0:
                if (facing == -1)
                    anim.Play("Enemy_Idle_Left");
                else if (facing == 1)
                    anim.Play("Enemy_Idle_Right");
                break;
            case 1:
                anim.Play("Enemy_Walk_Right");
                break;
            case -1:
                anim.Play("Enemy_Walk_Left");
                break;
        }
    }

    //Enemy's Death Function for anything related to the enemy's death.
    public void Death()
    {
        anim.Play("Enemy_Death");
    }

    public void _on_hitbox_body_entered(Node2D body)
    {
        if (body.Name == "Sword")
        {
            Health.TookDamage(1);
            HitParticles.Emitting = true;
            Hurt.Playing = true;
            if (Health.GetHealth() <= 0)
            {
                Death();
            }
        }
        else if (body.Name == "Player")
        {
            Player player = (Player)body;
            player.HitPlayer(4, "Enemy");
        }
    }
}
