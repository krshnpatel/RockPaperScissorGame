using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
	// Variables for wins, loses, and total games played
	public static int wins = 0;
	public static int loses = 0;
	public static int total = 0;

	// A variable for the GameObject
	GameObject go;

	// Variables to control the UI components
	public Button button;
	public Text resultText;

	void Start()
	{
		// Sets "go" to the GameObject holding this script
		go = this.gameObject;

		// Makes sure button exists
		if (button != null)
			button.gameObject.SetActive (false); // Disable the button

		resultText.gameObject.SetActive (false); // Disable the result text
	}

	// Update is called once per frame
	void Update ()
	{
		// Get the GUIText component
		GUIText gt = this.GetComponent<GUIText> ();

		// Check the GameObject's tag
		if (go.tag == "Wins")
		{
			// If the tag is "Wins" then update its text to the current number of wins
			gt.text = wins.ToString ();
		}
		if (go.tag == "Loses")
		{
			// If the tag is "Loses" then update its text to the current number of losses
			gt.text = loses.ToString ();
		}
		if (go.tag == "Total")
		{
			// If the tag is "Total" then update its text to the current number of total games played
			gt.text = total.ToString ();
		}
	
		// Checks if the total number of games played is greater than or equal to 10 AND makes sure that button is not null
		if (total >= 10 && button != null)
		{
			// Changes the result text depending on the player's wins and losses
			if (wins == loses)
				resultText.text = "Tied!";
			else if (wins > loses)
				resultText.text = "You Win!";
			else
				resultText.text = "You Lose...";

			// Delays the play again menu
			StartCoroutine (DelayPlayAgainMenu ());
			DelayPlayAgainMenu ();
		}
	}

	IEnumerator DelayPlayAgainMenu()
	{
		yield return new WaitForSeconds(1.5f); // This will delay the function by 5 seconds
		Time.timeScale = 0; // Pauses the game
		// then displays the result text and the buttons
		resultText.gameObject.SetActive (true); // Enable the result text
		button.gameObject.SetActive (true); // Enable the buttons
	}
}
