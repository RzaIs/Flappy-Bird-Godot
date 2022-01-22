using Godot;
using System;

public class Border : StaticBody2D
{
    [Signal] public delegate void OutOfBorder();

    public void OnDetectorBodyEntered(Node _)
    {
        EmitSignal(nameof(OutOfBorder));
    }

}
