using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MovePlayer : MonoBehaviour
{

    public float speedTranslate;
    public float speedRotate;
    public float speedTranslateCamera;
    public float speedRotateCamera;
    public GameObject gameObjectControl;

    Vector3 distanceCamera;

    #region UI
    private void Awake()
    {
        speedTranslateCamera = 10;
        speedRotateCamera = 30;
        speedTranslate = 0.1f;
        speedRotate = 10;
        distanceCamera = new Vector3(0, 3, -4);
    }
    void GetInput()
    {
        Vector3 direction = Vector3.zero;//gameObjectControl.transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward * speedTranslate;
            CreateMessageToServer(direction, Vector3.zero);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.back * speedTranslate;
            CreateMessageToServer(direction, Vector3.zero);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.zero;
            direction += Vector3.up;
            CreateMessageToServer(Vector3.zero, direction);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.zero;
            direction += Vector3.down;
            CreateMessageToServer(Vector3.zero, direction);
        }
    }


    private void FixedUpdate()
    {
        if (gameObjectControl == null)
        {
            try
            {
                gameObjectControl = DataOnClient.Instance.GetPlayerLocal();
                Camera.main.transform.position = gameObjectControl.transform.position + distanceCamera;
                Camera.main.transform.LookAt(gameObjectControl.transform.position);
            }
            catch
            { }
        }
        else
        {
            GetInput();
        }
    }


    #endregion
    #region Register event
    private void OnEnable()
    {
        NetUtility.C_MOVEPLAYER += OnEventClient;
    }
    private void OnDisable()
    {
        NetUtility.C_MOVEPLAYER -= OnEventClient;
    }
    #endregion

    #region Create Reveice 

    public void CreateMessageToServer(Vector3 _position, Vector3 _rotation)
    {
        MovePlayerMessage mm = new MovePlayerMessage(DataOnClient.Instance.room.RoomId, DataOnClient.Instance.InternalId, _position, _rotation);
        NetMovePlayer nm = new NetMovePlayer();
        nm.ContentBox = JsonUtility.ToJson(mm);
        Client.Instance.SendToServer(nm);
    }
    public void OnEventClient(NetMessage msg)
    {
        NetMovePlayer nmo = msg as NetMovePlayer;
        MovePlayerMessage mm = JsonUtility.FromJson<MovePlayerMessage>(nmo.ContentBox);
        GameObject gameObjectControl = DataOnClient.Instance.GetPlayerWithId(mm.Id);
        gameObjectControl.transform.Translate(mm.Position);
        gameObjectControl.transform.Rotate(mm.Rotation * speedRotate);
        //if (mm.Id == DataOnClient.Instance.InternalId)
        //{
        //    Camera.main.transform.position = gameObjectControl.transform.position + distanceCamera;
        //    Camera.main.transform.LookAt(gameObjectControl.transform.position);
        //}
    }
    #endregion
}
