using Godot;
using System;

public class Bird : KinematicBody2D
{
	[Export] public float SPEED;
	[Export] public float FALL_SPEED;
	[Export] public float GRAVITY;

	[Signal] public delegate void GameOver();


	public Vector2 initialPosition;
	public Vector2 velocity = Vector2.Zero;

	public AnimatedSprite animatedSprite;

	public bool isGameOver;

	public override void _Ready()
	{
		initialPosition = GlobalPosition;
		animatedSprite = GetNode<AnimatedSprite>("Anim");
		animatedSprite.Play("flap");
		isGameOver = true;
		velocity.y = 0;
	}

	public override void _Process(float delta)
	{

		if (!isGameOver)
		{
			GetMove(delta);
			Rotate();
		}
	}

	public void GetMove(float delta)
	{
		if (Input.IsActionJustPressed("jump"))
			velocity.y = -SPEED;

		velocity.y += GRAVITY * delta;

		velocity.y = Mathf.Min(velocity.y, FALL_SPEED);

		MoveAndCollide(velocity * delta);
	}

	public void Rotate()
	{
		RotationDegrees = 40 * (velocity.y / SPEED);
	}

	public void OnHitBoxBodyEntered(Node _)
	{
		EmitSignal(nameof(GameOver));
	}

	public void Reset()
    {
		GlobalPosition = initialPosition;
		animatedSprite.Play("flap");
		RotationDegrees = 0;
		velocity = Vector2.Zero;
	}
}
