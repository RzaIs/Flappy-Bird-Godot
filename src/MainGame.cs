using Godot;
using System;

public class MainGame : Node2D
{
	public UI ui;
	public Bird bird;
	public Timer timer;
	public Timer starterTimer;
	public ObstacleGenerator obstacleGenerator;

	public override void _Process(float delta)
	{
		ui.UpdateCountDown((int)starterTimer.TimeLeft + 1);
	}

	public override void _Ready()
	{
		ui = GetNode<UI>("UI");
		bird = GetNode<Bird>("Bird");
		timer = GetNode<Timer>("Timer");
		starterTimer = GetNode<Timer>("StarterTimer");
		obstacleGenerator = GetNode<ObstacleGenerator>("ObstacleGenerator");
	}

	public void OnBirdGameOver()
	{
		bird.isGameOver = true;
		bird.animatedSprite.Stop();

		timer.Stop();

		foreach (Tube tube in obstacleGenerator.GetChildren())
		{
			tube.isGameOver = true;
		}
		ui.ShowGameOver();
	}

	public void OnStarterTimerTimeout()
	{
		bird.isGameOver = false;
		obstacleGenerator.Generate();
		timer.Start();
		ui.countDownLabel.Visible = false;
	}

	public void IncreaseScore()
	{
		ui.IncreaseScore();
	}

	public void OnUIRestart()
	{
		bird.Reset();

		foreach (Tube tube in obstacleGenerator.GetChildren())
		{
			tube.OnVisibilityNotifier2DScreenExited();
		}

		starterTimer.Start();
		
	}
}
