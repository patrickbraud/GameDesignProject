using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class Networkman : NetworkManager
{
	private NetworkMatch networkMatch;
	//[SerializeField] public Camera PlayerCam;


	
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


}
