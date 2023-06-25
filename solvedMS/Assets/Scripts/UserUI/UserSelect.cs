using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserSelect : MonoBehaviour
{
    private PlayerTable m_playerInfo;
    private Image m_image;
    private Text m_name;

    private void Awake()
    {
        m_playerInfo = new PlayerTable();
        m_name = transform.GetChild(1).GetComponent<Text>();
        m_image = transform.GetChild(0).GetComponent<Image>();
    }
    public void SetPlayerInfo(PlayerTable pPlayerInfo)
    {
        this.m_playerInfo = pPlayerInfo;
        m_name.text = m_playerInfo.playerName;
        Debug.Log(Constant.profilePath + m_playerInfo.playerProfile);
        m_image.sprite = Resources.Load<Sprite>(Constant.profilePath + m_playerInfo.playerProfile);
    }

    public void OnClick()
    {
        ServerSystem.Instance.selectedUser = m_playerInfo;
        SceneManager.LoadScene(1);
    }
}
