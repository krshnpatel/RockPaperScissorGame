using UnityEngine;
using System.Collections;

public class RockBox : MonoBehaviour
{
	IEnumerator DestroyAfterAnimation(GameObject go, GameObject go2 = null)
	{
		yield return new WaitForSeconds(1.3f); // This will wait 1.3 seconds
		Destroy (go); // Destroy the GameObject

		// Make sure there is a second GameObject, otherwise cannot destroy it
		if (go2 != null)
			Destroy (go2);
	}

	void OnCollisionEnter(Collision col)
	{
		// Depending on which object the PaperBox is colliding with... play the appropriate animations and decide if the player wins, loses, or ties
		if (col.gameObject.name == "PaperBox_Enemy") // Lose case
		{
			Animator anim = this.gameObject.GetComponent<Animator> (); // Get the animator from the object colliding
			PlayAnimation(anim, "RockBoxKill", "Lost");
			Score.loses++; // Increment number of games lost
			Score.total++; // Increment the total games played
		}
		else if (col.gameObject.name == "RockBox_Enemy") // Tie case
		{
			Animator anim = col.gameObject.GetComponent<Animator> (); // Get the animator from the object colliding
			PlayAnimation(anim, "RockBox_EnemyKill", "Tie", col.gameObject);
			Score.total++; // Increment the total games played
		}
		else if (col.gameObject.name == "ScissorBox_Enemy") // Win case
		{
			Animator anim = col.gameObject.GetComponent<Animator> (); // Get the animator from the object colliding
			PlayAnimation(anim, "ScissorBox_EnemyKill", "Win", col.gameObject);
			Score.wins++; // Increment number of games won
			Score.total++; // Increment the total games played
		}
	}

	// Plays the appropriate animation depending on the parameters sent
	void PlayAnimation (Animator anim, string animName, string result, GameObject go = null)
	{
		anim.CrossFade (animName, 0f); // Play animation

		// Depending on the case, play the appropriate animation and destroy the appropriate GameObjects
		if (result == "Lost")
		{
			StartCoroutine (DestroyAfterAnimation (this.gameObject)); // This will run the timer for destroying the GameObject
			DestroyAfterAnimation (this.gameObject);
		}
		else if (result == "Win")
		{
			StartCoroutine (DestroyAfterAnimation (go)); // This will run the timer for destroying the GameObject
			DestroyAfterAnimation (go);
		}
		else if (result == "Tie")
		{
			this.gameObject.GetComponent<Animator>().CrossFade ("RockBoxKill", 0f);
			StartCoroutine (DestroyAfterAnimation (go, this.gameObject)); // This will run the timer for destroying the GameObject
			DestroyAfterAnimation (go, this.gameObject);
		}
	}
}
