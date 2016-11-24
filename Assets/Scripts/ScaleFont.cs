using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

// This class is made to scale the fonts with respect to the screen size
public class ScaleFont : MonoBehaviour
{
	public Vector2 offset = Vector2.zero; // Creates a vector for the text offset

	public float ratio = 10; // The ratio for the new font size

	void OnGUI()
	{
		float finalSize = (float)Screen.width/ratio; // Calculate the new font size
		this.GetComponent<GUIText>().fontSize = (int)finalSize; // Set the calculated font size
		this.GetComponent<GUIText>().pixelOffset = new Vector2( offset.x * Screen.width, offset.y * Screen.height); // Calculate and set the text offset
	}
}