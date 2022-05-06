using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_PlayerState : RegisterEvent
{
    //// quy định biến viết hoa hết là dành cho máy chủ
    

    //void FixedUpdate()
    //{

    //    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        CreateMessageToServer("Run");
    //    }
    //    if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
    //    {
    //        CreateMessageToServer("Normal");
    //    }
    //}

    //#region REGISTEEVENT
    //private void OnEnable()
    //{
    //    RegisterEvents(ref NetUtility.S_PLAYERSTATE, ref NetUtility.C_PLAYERSTATE);
    //}
    //private void OnDisable()
    //{
    //    UnRegisterEvents(ref NetUtility.S_PLAYERSTATE, ref NetUtility.C_PLAYERSTATE);
    //}
    //#endregion
    //#region Server
    //public void CreateMessageToClient()
    //{
    //}
    //public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    //{
    //    Server.Instance.BroadCatOnRoom(cnn ,msg);
    //}
    //#endregion

    //#region Client
    //// chỉ gửi kiểu object và chỉ số prefabs
    //public void CreateMessageToServer(string state)
    //{
    //    NetPlayerState nps = new NetPlayerState();
    //    PlayerState ps = new PlayerState(DataOnClient.Instance.InternalId, state);
    //    nps.ContentBox = JsonUtility.ToJson(ps);
    //    Client.Instance.SendToServer(nps);
    //}
    //public override void OnEventClient(NetMessage msg)
    //{
    //    NetPlayerState nps = msg as NetPlayerState;
    //    PlayerState ps = JsonUtility.FromJson<PlayerState>(nps.ContentBox);
    //    Debug.Log(nps.ContentBox);
    //    GameObject player = DataOnClient.Instance.GetPlayerWithId(ps.Id);
    //    Animator animator = player.GetComponent<Animator>();
    //    animator.SetTrigger(ps.Trigger);
    //}

    //#endregion
}
