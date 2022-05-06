using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class NetCreatePlayer : NetMessage
{
    // cái này máy chủ quản lý;
    public NetCreatePlayer()
    {
        Code = OpCode.CREATEPLAYER;
    }
    public NetCreatePlayer(DataStreamReader reader)
    {
        Code = OpCode.CREATEPLAYER;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_CREATEPLAYER?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_CREATEPLAYER?.Invoke(this, cnn);
    }
}

public class CreatePlayerMessage
{
    public int IdRoom;
    public int Id;
    public int IndexPrefab;
    public string DisplayName;
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;

    public CreatePlayerMessage(int idRoom, int id, int indexPrefab, string displayName, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        IdRoom = idRoom;
        Id = id;
        IndexPrefab = indexPrefab;
        DisplayName = displayName;
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }
    public CreatePlayerMessage()
    {
        IdRoom = -1;
        Id = -1;
        IndexPrefab = -1;
        DisplayName = "";
        Position = Vector3.zero;
        Rotation = Vector3.zero;
        Scale = Vector3.zero;
    }
}

