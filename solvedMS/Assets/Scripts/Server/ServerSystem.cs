using System;
using UnityEngine;

public class ServerSystem : MonoBehaviour
{
    private static ServerSystem m_instance;

    public PlayerTable selectedUser = new PlayerTable();
    public static ServerSystem Instance
    {
        get
        {
            try
            {
                return m_instance;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return null;
            }
        }
    }
    private void Awake()
    {
        if (m_instance != null) Destroy(m_instance);
        m_instance = this;
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        WebServerManager.Init("127.0.0.1", 8000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}