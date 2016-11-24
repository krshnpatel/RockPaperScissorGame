using UnityEngine;
using System.Collections;

public class DesiredAspectRatio : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
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
}
