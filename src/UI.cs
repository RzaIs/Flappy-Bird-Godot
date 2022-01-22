using Godot;
using System;

public class UI : Control
{
    [Signal] public delegate void Restart();

    public Label scoreLabel;
    public Label gameOverLabel;
    public Label countDownLabel;
    public Button restartButton;

    public int score;


    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("ScoreLabel");
        gameOverLabel = GetNode<Label>("GameOverLabel");
        countDownLabel = GetNode<Label>("CountDownLabel");
        restartButton = GetNode<Button>("RestartButton");
        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
        scoreLabel.Text = "Score : " + score;
    }

    public void ShowGameOver()
    {
        gameOverLabel.Visible = true;
        restartButton.Visible = true;
    }

    public void ResetScore()
    {
        score = 0;
        scoreLabel.Text = "Score : " + score;
    }

    public void OnRestartButtonPressed()
    {
        gameOverLabel.Visible = false;
        restartButton.Visible = false;
        ResetScore();
        EmitSignal(nameof(Restart));
        countDownLabel.Visible = true;
    }

    public void UpdateCountDown(int value)
    {
        countDownLabel.Text = value.ToString();
    }
}
