using Godot;
using System;

public partial class Mob : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		string[] mobTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();
			// Check if there are animations available
		if (mobTypes.Length > 0)
		{
			// Play a random animation
			animatedSprite2D.Play(mobTypes[GD.Randi() % mobTypes.Length]);
			System.Console.WriteLine("Hay animacion");
		}
		else
		{
			GD.PrintErr("No animations found in AnimatedSprite2D");
		}
	}
// We also specified this function name in PascalCase in the editor's connection window.
	private void _on_visible_on_screen_notifier_2d_screen_exited()
	{
		QueueFree();
	}

}
