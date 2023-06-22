using System;
using UnityEngine;
using UnityEngine.UI;

public class ProfileImage : MonoBehaviour
{
    private Image m_profileImage;
    private Image m_tierImage;
    private Text m_name;
    private Text m_tier;

    private void Awake()
    {
        m_tier = transform.GetChild(1).GetComponent<Text>();
        m_name = transform.GetChild(2).GetComponent<Text>();
        m_profileImage = GetComponent<Image>();
        m_tierImage = transform.GetChild(0).GetComponent<Image>();
    }
    public void SetProfile(string pProfile, string pTier)
    {
        try
        {
            m_profileImage.sprite = Resources.Load<Sprite>(Constant.profilePath + pProfile);
            m_tierImage.sprite = Resources.Load<Sprite>(Constant.tierPath + pTier);
            m_tier.text = pTier;
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public void SetName(string pName)
    {
        m_name.text = pName;
    }
}