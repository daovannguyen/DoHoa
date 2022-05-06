using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class S_SendChatInRoom : MonoSingleton<S_SendChatInRoom>
{
    NetworkConnection Cnn;
    #region Register event
    private void OnEnable()
    {
        NetUtility.S_SENDCHATINROOM += OnEventServer;
    }
    private void OnDisable()
    {
        NetUtility.S_SENDCHATINROOM -= OnEventServer;
    }
    #endregion

    private void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        SendChatInRoomMessage scm = new SendChatInRoomMessage().FromJson((msg as NetSendChatInRoom).ContentBox);
        CreateMessageToClient(msg, scm.IdRoom);
    }
    // send toàn bộ
    public void CreateMessageToClient(NetMessage msg, int idRoom)
    {
        Server.Instance.BroadCatOnRoom(msg, idRoom);
    }
}