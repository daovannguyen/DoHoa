using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

public class L_MovePlayer : RegisterEvent
{
    
    //public float speedTranslate;
    //public float speedRotate;
    //public float speedTranslateCamera;
    //public float speedRotateCamera;
    //public GameObject gameObjectControl;


    //Vector3 distanceCamera;
    //private void Awake()
    //{
    //    speedTranslateCamera = 10;
    //    speedRotateCamera = 30;
    //    speedTranslate = 0.05f;
    //    speedRotate = 5;
    //    distanceCamera = new Vector3(0, 3, -4);
    //}
    //void GetInput()
    //{
    //    int Id = DataOnClient.Instance.InternalId;
    //    Vector3 direction = Vector3.zero;//gameObjectControl.transform.position;
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        direction += Vector3.forward * speedTranslate;
    //        CreateMessageToServer(Id, direction, Vector3.zero);
    //    }
    //    else if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        direction += Vector3.back * speedTranslate;
    //        CreateMessageToServer(Id, direction, Vector3.zero);
    //    }
    //    else if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        direction = Vector3.zero;
    //        direction += Vector3.up;
    //        CreateMessageToServer(Id, Vector3.zero, direction);
    //    }
    //    else if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        direction = Vector3.zero;
    //        direction += Vector3.down;
    //        CreateMessageToServer(Id, Vector3.zero, direction);
    //    }
    //}


    //private void FixedUpdate()
    //{
    //    if (gameObjectControl == null)
    //    {
    //        try
    //        {
    //            gameObjectControl = DataOnClient.Instance.GetPlayerLocal();
    //            Camera.main.transform.position = gameObjectControl.transform.position + distanceCamera;
    //            Camera.main.transform.LookAt(gameObjectControl.transform.position);
    //        }
    //        catch
    //        { }
    //    }
    //    else
    //    {
    //        GetInput();
    //    }
    //}




    //#region REGISTEEVENT
    //private void OnEnable()
    //{
    //    RegisterEvents(ref NetUtility.S_MOVEPLAYER, ref NetUtility.C_MOVEPLAYER);
    //}
    //private void OnDisable()
    //{
    //    UnRegisterEvents(ref NetUtility.S_MOVEPLAYER, ref NetUtility.C_MOVEPLAYER);
    //}
    //#endregion
    //#region Server
    //public void CreateMessageToClient()
    //{
    //}
    //public override void OnEventServer(NetMessage msg, NetworkConnection cnn)
    //{
    //    Server.Instance.BroadCatOnRoom(cnn, msg);
    //}
    //#endregion

    //#region Client
    //// chỉ gửi kiểu object và chỉ số prefabs
    //public void CreateMessageToServer(int _id, Vector3 _position, Vector3 _rotation)
    //{
    //    ObjectMessage mm = new ObjectMessage(_id, _position, _rotation);
    //    NetMovePlayer nm = new NetMovePlayer();
    //    nm.ContentBox = JsonUtility.ToJson(mm);
    //    Client.Instance.SendToServer(nm);
    //}
    //public override void OnEventClient(NetMessage msg)
    //{
    //    NetMovePlayer nmo = msg as NetMovePlayer;
    //    ObjectMessage mm = JsonUtility.FromJson<ObjectMessage>(nmo.ContentBox);
    //    gameObjectControl = DataOnClient.Instance.GetPlayerWithId(mm.Id);
    //    gameObjectControl.transform.Translate(mm.Position);
    //    gameObjectControl.transform.Rotate(mm.Rotation * speedRotate);
    //    if (mm.Id == DataOnClient.Instance.InternalId)
    //    {
    //        Camera.main.transform.position = gameObjectControl.transform.position + distanceCamera;
    //        Camera.main.transform.LookAt(gameObjectControl.transform.position);
    //    }
    //}

    //#endregion
}
