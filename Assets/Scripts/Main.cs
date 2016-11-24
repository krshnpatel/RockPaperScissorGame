using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour
{
	int clicks; // A variable for the amount of VALID clicks
	public GameObject[] computerBox; // An array of the opponent's boxes

	void Start()
	{
		// Initializes the number of clicks to 0
		clicks = 0; // So the player cannot initiate any other GameObject's animation after already choosing one

		//// Calculations for a desired screen size
		// Sets the screen's aspect ratio to 20:9
		float targetAspect = 20f / 9f;

		// Calculates the window aspect ratio
		float windowAspect = (float)Screen.width / (float)Screen.height;

		// Scales the height according to the two aspect ratios
		float scaleHeight = windowAspect / targetAspect;

		Camera camera = GetComponent<Camera> ();

		// Setup up the camera accordingly
		if (scaleHeight < 1f)
		{
			Rect rect = camera.rect;

			rect.width = 1f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1f - scaleHeight) / 2f;

			camera.rect = rect;
		}
		else
		{
			float scaleWidth = 1f / scaleHeight;

			Rect rect = camera.rect;

			rect.width = scaleWidth;
			rect.height = 1f;
			rect.x = (1f - scaleWidth) / 2f;
			rect.y = 0;

			camera.rect = rect;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// If the user left-clicks then...
		if (Input.GetButtonDown ("Fire1"))
		{
			GameObject playerBox = GetClickedGameObject (); // Get the clicked GameObject

			// If GetClickedGameObject returns a GameObject and its tag is "Clickable" then...
			if (playerBox != null && playerBox.tag == "Clickable" && clicks == 0)
			{
				clicks = 1; // The first valid click will make this variable 1 so the user cannot click any other valid GameObjects and disrupt gameplay

				// Get the animator of the clicked GameObject
				Animator animPlayer = playerBox.GetComponent<Animator> ();
				animPlayer.enabled = true; // Play the first animation

				// Call the opponent's box
				CallRandomBox();

				// Reloads the scene after the animation is done
				StartCoroutine(ReloadScene());
				ReloadScene ();
			}
		}
	}

	GameObject GetClickedGameObject ()
	{
		// Building a ray
		RaycastHit hit;
		Ray point = Camera.main.ScreenPointToRay (Input.mousePosition);

		// Casts the ray and gets the first GameObject that is hit
		if (Physics.Raycast (point, out hit, 10f))
			return hit.transform.gameObject;
		else
			return null;
	}
		
	IEnumerator ReloadScene()
	{
		yield return new WaitForSeconds(3f); // This will wait 5 seconds
		Application.LoadLevel("_MainScene"); // Reload the scene
	}

	// This acts as the computer player
	void CallRandomBox()
	{
		// Generate a random index for the computer box
		int randomIndex = Random.Range (0,3);

		// Get the animator of the random index generated
		Animator animComputer = computerBox[randomIndex].GetComponent<Animator> ();
		animComputer.enabled = true; // Play the first animation
	}
}