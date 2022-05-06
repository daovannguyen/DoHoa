﻿using UnityEngine;
using System;
using Unity.Networking.Transport;

public enum OpCode
{
    NULL,
    KEEP_ALIVE,
    SENDCHAT,
    SENDCHATINROOM,
    CHANGESCENE,
    CREATEOBJECT,
    CREATEPLAYER,
    WELCOME,
    JOINROOM,
    PLAYERSTATE,
    MOVEPLAYER,
    COUNTITEM,
    MOVEOBJECT,






}
public static class NetUtility
{
    //Net messages

    public static void OnData(DataStreamReader stream, NetworkConnection cnn, Server server = null )
    {
        NetMessage msg = null;
        var opCode = (OpCode)stream.ReadByte();
        switch(opCode)
        {
            case OpCode.KEEP_ALIVE: msg = new NetKeepAlive(stream); break;
            case OpCode.WELCOME: msg = new NetWelcome(stream); break;
            case OpCode.SENDCHAT: msg = new NetSendChat(stream); break;
            case OpCode.SENDCHATINROOM: msg = new NetSendChatInRoom(stream); break;
            case OpCode.JOINROOM: msg = new NetJoinRoom(stream); break;
            case OpCode.CHANGESCENE: msg = new NetChangeScene(stream); break;
            case OpCode.CREATEOBJECT: msg = new NetCreateObject(stream); break;
            case OpCode.CREATEPLAYER: msg = new NetCreatePlayer(stream); break;
            case OpCode.PLAYERSTATE: msg = new NetPlayerState(stream); break;
            case OpCode.MOVEPLAYER: msg = new NetMovePlayer(stream); break;
            case OpCode.COUNTITEM: msg = new NetCountItem(stream); break;
            case OpCode.MOVEOBJECT: msg = new NetMoveObject(stream); break;

            default:
                Debug.LogError("Message received had no OpCode");
                break;
        }
        if (server != null)
        {
            msg.ReceivedOnServer(cnn);
        }
        else
            msg.ReceivedOnClient();
    }



    // đay là ở máy client
    public static Action<NetMessage> C_KEEP_ALIVE;
    public static Action<NetMessage> C_WELCOME;
    public static Action<NetMessage> C_SENDCHAT;
    public static Action<NetMessage> C_SENDCHATINROOM;
    public static Action<NetMessage> C_CREATEOBJECT;
    public static Action<NetMessage> C_CREATEPLAYER;
    public static Action<NetMessage> C_CHANGESCENE;
    public static Action<NetMessage> C_JOINROOM;
    public static Action<NetMessage> C_PLAYERSTATE;
    public static Action<NetMessage> C_MOVEPLAYER;
    public static Action<NetMessage> C_COUNTITEM;
    public static Action<NetMessage> C_MOVEOBJECT;

    // đây ở máy server
    public static Action<NetMessage, NetworkConnection> S_KEEP_ALIVE;
    public static Action<NetMessage, NetworkConnection> S_WELCOME;
    public static Action<NetMessage, NetworkConnection> S_SENDCHAT;
    public static Action<NetMessage, NetworkConnection> S_SENDCHATINROOM;
    public static Action<NetMessage, NetworkConnection> S_CREATEOBJECT;
    public static Action<NetMessage, NetworkConnection> S_CREATEPLAYER;
    public static Action<NetMessage, NetworkConnection> S_CHANGESCENE;
    public static Action<NetMessage, NetworkConnection> S_JOINROOM;
    public static Action<NetMessage, NetworkConnection> S_PLAYERSTATE;
    public static Action<NetMessage, NetworkConnection> S_MOVEPLAYER;
    public static Action<NetMessage, NetworkConnection> S_COUNTITEM;
    public static Action<NetMessage, NetworkConnection> S_MOVEOBJECT;

}
