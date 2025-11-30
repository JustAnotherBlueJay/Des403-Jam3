using Godot;
using System;
using System.Collections;
using System.IO;

public partial class GameManager : Control
{	
	public static GameManager Instance { get; private set; }

	[Export] PackedScene[] gameScenes;
	private int currentSceneindex = 0;
	private Node currentScene;
	[Export] AudioStreamPlayer audioPlayer;
	private AudioStreamPlaybackInteractive interactiveStream;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		Instance.audioPlayer.Play();
		Instance.interactiveStream = Instance.audioPlayer.GetStreamPlayback() as AudioStreamPlaybackInteractive;
		InstantiateScene(0);

    }

    private void InstantiateScene(int sceneIndex)
	{
		currentScene = gameScenes[sceneIndex].Instantiate();

		AddChild(currentScene);
	}

	public static void TransitionToNextScene()
	{
		//free up the current scene
		Instance.currentScene.QueueFree();

		//progress along the array of scenes
		Instance.currentSceneindex += 1;

		//instantiate the new scene
		Instance.InstantiateScene(Instance.currentSceneindex);

		GD.Print("Switching audio stream");
		Instance.interactiveStream.SwitchToClip(Instance.currentSceneindex + 1);


	}

}
