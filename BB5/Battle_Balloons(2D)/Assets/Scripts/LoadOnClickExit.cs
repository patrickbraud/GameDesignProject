using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadOnClickExit : MonoBehaviour
{
	public Button yesButton;
	public Button noButton;
	public Text AreYouSure;


	void ExitStart ()
		
	{		
		yesButton = yesButton.GetComponent<Button> ();
		noButton = noButton.GetComponent<Button> ();
		AreYouSure = AreYouSure.GetComponent<Text> ();
		
		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (true);

	} 

	public void YesButtonPress() //this function will be used on our Exit button
		
	{
		Application.Quit();
	}

	public void NoButtonPress() //this function will be used on our Exit button
		
	{
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);
		AreYouSure.gameObject.SetActive (false);
		Application.LoadLevel(0);
	}
}
