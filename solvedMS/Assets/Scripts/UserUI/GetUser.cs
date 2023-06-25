using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUser : MonoBehaviour
{
    private static GetUser m_instance;
    private List<GameObject> m_users = new List<GameObject>();
    public int lastUserID = 10000;
    public static GetUser Instance
    {
        get
        {
            try
            {
                return m_instance;
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.Message);
                return null;
            }
        }
    }

    [SerializeField] private GameObject userSelect;
    public void ResponseGetUser()
    {
        for(int i = 0;i<m_users.Count;i++) Destroy(m_users[i]);
        m_users.Clear();

        PlayerProfiles profiles = new PlayerProfiles();
        WebServerManager.ins.Post<PlayerProfiles, PlayerProfiles>(profiles, "API/get_user_info/", response => {
            if (response.is_success)
            {
                foreach(var items in response.GetPlayerData())
                {
                    GameObject obj = Instantiate(userSelect, transform);
                    m_users.Add(obj);
                    lastUserID = Math.Max(items.playerID, lastUserID);
                    obj.GetComponent<UserSelect>().SetPlayerInfo(items);
                }
            }
            else Debug.LogError("ResponseGetUser Responce Error!");
        }, () => { Debug.LogError("ResponseGetUser Network Error!"); });
    }

    private void Awake()
    {
        if (m_instance != null) Destroy(gameObject);
        m_instance = this;
    }

    private void Start()
    {
        StartCoroutine(startRightNow());
    }
    IEnumerator startRightNow()
    {
        yield return new WaitForSeconds(2.0f);
        transform.GetChild(0).gameObject.SetActive(true);
        ResponseGetUser();
        yield return null;
    }
}
