using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        WebServerManager.Init("127.0.0.1", 8000);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SendMessage();
        }
    }

    void SendMessage()
    {
        playerprofile test = new playerprofile();
        
        WebServerManager.ins.Post<playerprofile, playerprofile>(test, "API/user_login/", response => {
            if (response.is_success)
            {
                
            }
            else
            {
                Debug.LogError("ERROR");
            }
        }, () => { Debug.LogError("Network Error!"); });
    }
}