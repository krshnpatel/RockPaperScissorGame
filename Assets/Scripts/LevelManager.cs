using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	public void PlayAgain()
	{
		// Resets the wins, loses, and total games played
		Score.wins = 0;
		Score.loses = 0;
		Score.total = 0;
		// Unpauses the game
		Time.timeScale = 1;
		// Loads the scene again
		Application.LoadLevel ("_MainScene");
	}

	public void Exit()
	{
		// Quits the game
		Application.Quit ();
	}
}