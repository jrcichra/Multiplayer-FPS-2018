using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    public Behaviour[] components;

    Camera sceneCamera;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer) {
            for(int i = 0; i < components.Length; i++)
            {
                components[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
	}

    void OnDisable() {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
