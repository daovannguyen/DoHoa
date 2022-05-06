using Unity.Networking.Transport;
using UnityEngine;

public class NetSendChatInRoom : NetMessage
{
    public NetSendChatInRoom()
    {
        Code = OpCode.SENDCHATINROOM;
    }
    public NetSendChatInRoom(DataStreamReader reader)
    {
        Code = OpCode.SENDCHATINROOM;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_SENDCHATINROOM?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_SENDCHATINROOM?.Invoke(this, cnn);
    }
}


public class SendChatInRoomMessage : BaseMessage<SendChatInRoomMessage>
{
    public int IdRoom;
    public string Username;
    public string Chat;

    public SendChatInRoomMessage(int idRoom, string username, string chat)
    {
        IdRoom = idRoom;
        Username = username;
        Chat = chat;
    }
    public SendChatInRoomMessage()
    {
        IdRoom = -1;
        Username = "";
        Chat = "";
    }

    public override string ToJson()
    {
        return base.ToJson();
    }

    public override SendChatInRoomMessage FromJson(string json)
    {
        return base.FromJson(json);
    }
}