using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerState : MonoSingleton<C_PlayerState>
{
    #region Register event
    private void OnEnable()
    {
        NetUtility.C_PLAYERSTATE += OnEventClient;
    }
    private void OnDisable()
    {
        NetUtility.C_PLAYERSTATE -= OnEventClient;
    }
    #endregion

    #region Create Reveice 

    public void CreateMessageToServer(string state)
    {
        NetPlayerState nps = new NetPlayerState();
        PlayerStateMessage ps = new PlayerStateMessage(DataOnClient.Instance.room.RoomId ,DataOnClient.Instance.InternalId, state);
        nps.ContentBox = JsonUtility.ToJson(ps);
        Client.Instance.SendToServer(nps);
    }
    public void OnEventClient(NetMessage msg)
    {
        NetPlayerState nps = msg as NetPlayerState;
        PlayerStateMessage ps = JsonUtility.FromJson<PlayerStateMessage>(nps.ContentBox);
        GameObject player = DataOnClient.Instance.GetPlayerWithId(ps.Id);
        Animator animator = player.GetComponent<Animator>();
        animator.SetTrigger(ps.Trigger);
       
    }
    #endregion
    #region UI
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CreateMessageToServer("Run");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CreateMessageToServer("Run");
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            CreateMessageToServer("Normal");
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            CreateMessageToServer("Normal");
        }
    }
    #endregion
}
