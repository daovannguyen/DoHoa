using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class S_SendChat : MonoSingleton<S_SendChat>
{
    NetworkConnection Cnn;
    #region Register event
    private void OnEnable()
    {
        NetUtility.S_SENDCHAT += OnEventServer;
    }
    private void OnDisable()
    {
        NetUtility.S_SENDCHAT -= OnEventServer;
    }
    #endregion

    #region Server
    private void OnEventServer(NetMessage msg, NetworkConnection cnn)
    {
        CreateMessageToClient(msg);
    }
    // send toàn bộ
    public void CreateMessageToClient(NetMessage msg)
    {
        Server.Instance.BroadCat(msg);
    }
    #endregion
}