using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WebServerManager.Init("127.0.0.1", 8000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}