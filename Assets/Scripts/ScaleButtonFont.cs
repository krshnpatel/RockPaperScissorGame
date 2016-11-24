using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]

// This class was made to scale the font in the buttons
public class ScaleButtonFont : MonoBehaviour
{
	public float ratio = 10; // // The ratio for the new font size

	void OnGUI()
	{
		float finalSize = (float)Screen.width/ratio; // Calculate the new font size
		this.GetComponent<Text>().fontSize = (int)finalSize; // Set the calculated font size
	}
}