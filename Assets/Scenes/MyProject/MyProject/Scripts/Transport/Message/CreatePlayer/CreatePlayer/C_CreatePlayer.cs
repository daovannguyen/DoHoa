using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CreatePlayer : MonoBehaviour
{

    #region Register event
    private void OnEnable()
    {
        NetUtility.C_CREATEPLAYER += OnEventClient;
    }
    private void OnDisable()
    {
        NetUtility.C_CREATEPLAYER -= OnEventClient;
    }
    #endregion

    #region Create Reveice 

    public void CreateMessageToServer(int idRoom, int id, int indexPrefab, string displayName, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        CreatePlayerMessage scm = new CreatePlayerMessage(idRoom, id, indexPrefab, displayName, position, rotation, scale);
        NetCreatePlayer nco = new NetCreatePlayer();
        nco.ContentBox = JsonUtility.ToJson(scm);
        Client.Instance.SendToServer(nco);
    }
    public void OnEventClient(NetMessage msg)
    {
        CreatePlayerMessage com = JsonUtility.FromJson<CreatePlayerMessage>((msg as NetCreatePlayer).ContentBox);
        DataOnClient.Instance.SetPlayer(com);
    }
    #endregion

    private void Start()
    {
        StartCoroutine(IntancePlayer());
    }

    IEnumerator IntancePlayer()
    {
        yield return new WaitForSeconds(1);
        int indexPrefab = DataOnClient.Instance.indexPlayerPrefab;
        Vector3 randomPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        CreateMessageToServer(DataOnClient.Instance.room.RoomId, -1, indexPrefab,
            DataOnClient.Instance.playerData.DisplayName, randomPosition, Vector3.zero, Vector3.zero);
    }
}
