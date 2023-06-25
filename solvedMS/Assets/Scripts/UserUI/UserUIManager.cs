using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserUIManager : MonoBehaviour
{
    public ProfileImage image;

    private void Start()
    {
        image.SetProfile(ServerSystem.Instance.selectedUser.playerProfile, "Diamond5");
    }
}
