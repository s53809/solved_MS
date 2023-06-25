using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgorithmSelectedButton : MonoBehaviour
{
    private bool m_isClicked = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickButton);
    }
    public void OnClickButton()
    {
        m_isClicked = !m_isClicked;
        if (m_isClicked)
        {
            Color color = Color.white;
            if(ColorUtility.TryParseHtmlString("#9AC5F4", out color)) //9AC5F4
            {
                transform.GetComponent<Image>().color = color;
            }
        }
        else
        {
            Color color = Color.white;
            if (ColorUtility.TryParseHtmlString("#99DBF5", out color))
            {
                transform.GetComponent<Image>().color = color;
            }
        }
    }
}
