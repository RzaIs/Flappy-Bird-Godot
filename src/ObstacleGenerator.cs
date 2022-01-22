using Godot;
using System;

public class ObstacleGenerator : Node2D
{
    [Export] public PackedScene tubeScene;
    [Export] public PackedScene pointAreaScene;

    Random rand;

    public override void _Ready()
    {
        rand = new Random();
    }

    public void Generate()
    {
        int height = rand.Next(80, 140);


        Tube upperTube = tubeScene.Instance<Tube>();
        Tube lowerTube = tubeScene.Instance<Tube>();
        PointArea pointArea = pointAreaScene.Instance<PointArea>();

        CallDeferred("add_child", upperTube);
        CallDeferred("add_child", lowerTube);
        
        upperTube.CallDeferred("add_child", pointArea);

        lowerTube.Position = new Vector2(20, height);
        upperTube.Position = new Vector2(20, height - 220);
        pointArea.Position = new Vector2(0, -110);

        upperTube.RotationDegrees = 180;

    }

    public void OnTimerTimeout()
    {
        Generate();
    }
}
