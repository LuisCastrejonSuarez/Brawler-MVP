using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraManager : MonoBehaviour
{
    public CinemachineTargetGroup targets;

    public void SetFollowAndTarget()
    {
        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();
        if(players.Length>0)
        {
            foreach (PlayerController player in players)
            {
                if(targets.FindMember(player.gameObject.transform)<0)
                    targets.AddMember(player.gameObject.transform, 1, 1);
            }
        }
    }
}
