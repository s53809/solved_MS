using UnityEngine;
using UnityEngine.UI;

public class TierSelectButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonDown);
    }
    public void OnButtonDown()
    {
        transform.parent.parent.parent.parent.GetComponent<PlusProblem>().SetProblemTier(int.Parse(transform.name));
    }
}
