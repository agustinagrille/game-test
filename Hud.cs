using Godot;
using System;

public partial class HUB : CanvasLayer
{
	
	[Signal]
	public delegate void StartGameEventHandler(); //Define evento de inicio de juego.
	
	public void ShowMessage(string text)  //Muestro el nodo "Message"
	{
		var message = GetNode<Label>("Message");
		message.Text = text;
		message.Show();

		GetNode<Timer>("MessageTimer").Start();
	}
	
	async public void ShowGameOver() //Este metodo se activa cuando el jugador pierde, muestra "game over" durante dos segundos y luego se reinicia el juego.
	{
		ShowMessage("Game Over");

		var messageTimer = GetNode<Timer>("MessageTimer");
		await ToSignal(messageTimer, Timer.SignalName.Timeout);

		var message = GetNode<Label>("Message");
		message.Text = "Dodge the Creeps!";
		message.Show();

		await ToSignal(GetTree().CreateTimer(1.0), SceneTreeTimer.SignalName.Timeout);
		GetNode<Button>("StartButton").Show();
	}
	
	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = score.ToString();
	}
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_start_button_pressed()
	{
		GetNode<Button>("StartButton").Hide();
		EmitSignal(SignalName.StartGame);
	}


	private void _on_message_timer_timeout()
	{
		GetNode<Label>("Message").Hide();
	}

}
