using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class Networkman : NetworkManager
{
	[SerializeField] public GameObject Player1;
	[SerializeField] public GameObject Player2;
	[SerializeField] public GameObject Player3;
	[SerializeField] public GameObject Player4;

	private int NumberofPlayers = 0;
	private NetworkMatch networkMatch;

	public GameObject startMenu;
	public CanvasGroup CG;

	void Start(){

		CG = startMenu.GetComponent<CanvasGroup> ();
	}


	void Update()
	{
		if(networkMatch == null)
		{
			var nm = GetComponent<NetworkMatch>();
			if (nm != null) {
				networkMatch = nm as NetworkMatch;
				UnityEngine.Networking.Types.AppID appid = (UnityEngine.Networking.Types.AppID)339051;
				networkMatch.SetProgramAppID(appid);
			}
		}
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{

		if (NumberofPlayers == 0){

			var player = (GameObject)GameObject.Instantiate (Player1, new Vector3(-21,8,0), Quaternion.identity);
			NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
			ClientScene.RegisterPrefab(Player1);
			NumberofPlayers++; 

			HideMenu();

		} 

		else if (NumberofPlayers == 1) {
			CG.alpha = 1f;
			var player = (GameObject)GameObject.Instantiate (Player2, new Vector3(21,8,0), Quaternion.identity);
			NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
			ClientScene.RegisterPrefab(Player2);
			NumberofPlayers++;

			CG.alpha = 0f;
			HideMenu();

		}

		else if (NumberofPlayers == 2) {
			CG.alpha = 1f;
			var player = (GameObject)GameObject.Instantiate (Player3, new Vector3(-21,-8,0), Quaternion.identity);
			NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
			ClientScene.RegisterPrefab(Player3);
			NumberofPlayers++;

			CG.alpha = 0f;
			HideMenu();
		}

		else if (NumberofPlayers == 3) {

			var player = (GameObject)GameObject.Instantiate (Player4, new Vector3(21,-8,0), Quaternion.identity);
			NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
			ClientScene.RegisterPrefab(Player4);
			NumberofPlayers++;

			HideMenu();
		}
	}

	// called when a client disconnects
	public override void OnServerDisconnect(NetworkConnection conn)
	{
		NetworkServer.DestroyPlayersForConnection(conn);
		NumberofPlayers--;
	}

	void HideMenu(){

		CG.alpha = 0f;
	}
}
