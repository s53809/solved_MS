using System;
using UnityEngine;
using UnityEngine.UI;

public class TopTen : MonoBehaviour
{
    [SerializeField] private GameObject m_tier;

    public void RefreshTopTen(string[] pStrs)
    {
        for(int i = 0; i < pStrs.Length; i++)
        {
            try
            {
                GameObject obj = Instantiate(m_tier, transform);
                obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.tierPath + pStrs[i]);
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
    }
}
