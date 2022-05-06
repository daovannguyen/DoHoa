using Unity.Networking.Transport;
using UnityEngine;

public class NetSendChat : NetMessage
{
    public NetSendChat()
    {
        Code = OpCode.SENDCHAT;
    }
    public NetSendChat(DataStreamReader reader)
    {
        Code = OpCode.SENDCHAT;
        Deserialize(reader);
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_SENDCHAT?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_SENDCHAT?.Invoke(this, cnn);
    }
}
public class SendChatMessage : BaseMessage<SendChatMessage>
{
    public string Username;
    public string Chat;

    public SendChatMessage(string username, string chat)
    {
        Username = username;
        Chat = chat;
    }
    public SendChatMessage()
    {
        Username = "";
        Chat = "";
    }

    public override string ToJson()
    {
        return base.ToJson();
    }

    public override SendChatMessage FromJson(string json)
    {
        return base.FromJson(json);
    }
}