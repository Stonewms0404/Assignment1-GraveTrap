using Godot;
using System;

public partial class CameraMovement : CharacterBody2D
{
    [Export]
    public Player player;

    //Runs Every Frame.
    public override async void _PhysicsProcess(double delta)
    {
        float modifier = 0.75f;
        if (player.IsDashing)
        {
            modifier = 0.3f;
        }
        Position = Position.Lerp(player.Position, (float)(delta * player.Speed * modifier));
    }
    
    float DotProduct(Vector2 a, Vector2 b)
    {
        return a.X * b.X + a.Y * b.Y;
    }
}
