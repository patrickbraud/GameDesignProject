using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadOnClickServer : MonoBehaviour
{
	public Text createText;
	public Button joinButton;
	public Button backButton;
	public InputField editable;

	void ServerStart ()
		
	{
		//quitMenu.enabled = false;
		//quitMenu = quitMenu.GetComponent<Canvas> ();
		//startMenu = startMenu.GetComponent<Canvas>();
		//serverMenu = serverMenu.GetComponent<Canvas>();
		//startMenu = startMenu.GetComponent<Canvas>();
		
		//createButton = createButton.GetComponent<Button> ();
		joinButton = joinButton.GetComponent<Button> ();
		backButton = backButton.GetComponent<Button> ();
		createText = createText.GetComponent<Text> ();
		editable = editable.GetComponent<InputField> ();
		//joinButton = joinButton.GetComponent<Button> ();
		//backButton = backButton.GetComponent<Button> ();
		
		
		//serverMenu.enabled = false;
		//startMenu.enabled = true;
		
		//createButton.gameObject.SetActive (true);
		joinButton.gameObject.SetActive (true);
		backButton.gameObject.SetActive (true);
		//createButton.gameObject.SetActive (false);
		//joinButton.gameObject.SetActive (false);
		//backButton.gameObject.SetActive (false);
		//startMenu.enabled = true;
	}

	public void ServerBackPress() //this function will be used on our Exit button
		
	{
		//createButton.enabled = true; //enable the Quit menu when we click the Exit button
		//startMenu.enabled = false;
		//createButton.gameObject.SetActive(false);
		joinButton.gameObject.SetActive(false);
		backButton.gameObject.SetActive(false);
		createText.gameObject.SetActive(false);
		editable.gameObject.SetActive(false);
		//createButton.gameObject.SetActive(false);
		//joinButton.gameObject.SetActive(false);
		//backButton.gameObject.SetActive(false);
		//createButton.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
		joinButton.enabled = false;
		backButton.enabled = false;
		Application.LoadLevel(0);
	}
}

