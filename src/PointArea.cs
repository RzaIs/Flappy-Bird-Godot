using Godot;
using System;

public class PointArea : Area2D
{
    public MainGame mainGame;

    public override void _Ready()
    {
        mainGame = (MainGame)GetTree().CurrentScene;
    }

    public void OnPointAreaBodyExited(Node _)
    {
        mainGame.IncreaseScore();
    }
}
