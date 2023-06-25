using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UserPlus : MonoBehaviour
{
    [SerializeField] private GameObject registerPopup;
    public void OnButtonClicked() => registerPopup?.SetActive(true);
}
