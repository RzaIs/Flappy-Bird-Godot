using Godot;
using System;

public class Tube : KinematicBody2D
{
    [Export] public float SPEED;

    public bool isGameOver;

    public override void _Ready()
    {
        isGameOver = false;
    }

    public override void _PhysicsProcess(float delta)
    {
        if(!isGameOver)
            MoveAndSlide(Vector2.Left * SPEED);
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
