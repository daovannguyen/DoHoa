using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C_SendChat : MonoSingleton<C_SendChat>
{
    public TMP_Text chat_Text;
    public TMP_InputField chat_Input;
    List<string> chatList = new List<string>();
    int countMax = 5;

    #region Register event
    private void OnEnable()
    {
        NetUtility.C_SENDCHAT += OnEventClient;
    }
    private void OnDisable()
    {
        NetUtility.C_SENDCHAT -= OnEventClient;
    }
    #endregion

    #region Create Reveice 
    public void CreateMessageToServer(string username, string chat)
    {
        SendChatMessage scm = new SendChatMessage(username, chat);
        NetSendChat nsc = new NetSendChat();
        nsc.ContentBox = scm.ToJson();
        Client.Instance.SendToServer(nsc);
    }
    private void OnEventClient(NetMessage msg)
    {
        SendChatMessage scm = new SendChatMessage().FromJson((msg as NetSendChat).ContentBox);
        InsertChatToContent(scm.Username + ": <color=\"grey\">" + scm.Chat + "</color>");

    }
    #endregion

    #region Work With UI
    private void Start()
    {
        chat_Text.text = "";
        chat_Input.onEndEdit.AddListener(delegate { OnEndEditSendChat(chat_Input); });
        InitContent();
    }

    void InitContent()
    {
        chatList = new List<string>();
        for (int i = 0; i < countMax; i++)
        {
            chatList.Add("");
        }
        ConvetListToText();
    }
    void ConvetListToText()
    {
        string content = "";
        foreach (var i in chatList)
        {
            content += "\n" + i;
        }
        chat_Text.text = content;
    }
    void InsertChatToContent(string chat)
    {
        if (chatList.Count == countMax)
        {
            chatList.RemoveAt(0);
        }
        chatList.Add(chat);
        ConvetListToText();
    }

    void OnEndEditSendChat(TMP_InputField chat_Input)
    {
        CreateMessageToServer(DataOnClient.Instance.playerData.DisplayName, chat_Input.text);
        chat_Input.text = "";
    }
    #endregion
}