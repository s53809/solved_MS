using UnityEngine;

public class GaugeBar : MonoBehaviour
{
    private RectTransform m_parentRect;
    private RectTransform m_childRect;

    private void Awake()
    {
        m_parentRect = GetComponent<RectTransform>();
        m_childRect = GetComponent<RectTransform>();
    }

    public void FillGauge(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_childRect.sizeDelta = new Vector2(m_parentRect.sizeDelta.x * percent, m_childRect.sizeDelta.y);
    }
}