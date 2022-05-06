using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class NetMovePlayer : NetMessage
{
    // cái này máy chủ quản lý;
    public NetMovePlayer()
    {
        Code = OpCode.MOVEPLAYER;
    }
    public NetMovePlayer(DataStreamReader reader)
    {
        Code = OpCode.MOVEPLAYER;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_MOVEPLAYER?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_MOVEPLAYER?.Invoke(this, cnn);
    }

}

public class MovePlayerMessage
{
    public int IdRoom;
    public int Id;
    public Vector3 Position;
    public Vector3 Rotation;
    public MovePlayerMessage(int idRoom, int _id, Vector3 _position, Vector3 _rotation)
    {
        IdRoom = idRoom;
        Id = _id;
        Position = _position;
        Rotation = _rotation;
    }
    public MovePlayerMessage()
    {
        IdRoom = -1;
        Id = 0;
        Position = Vector3.zero;
        Rotation = Vector3.zero;
    }
}
