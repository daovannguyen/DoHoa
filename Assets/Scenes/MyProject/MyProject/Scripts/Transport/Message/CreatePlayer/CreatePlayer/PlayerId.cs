using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerId: MonoBehaviour
{
    public GameObject canvas;
    public TMP_Text displayName_Text;
    [HideInInspector]
    public string displayName;
    [HideInInspector]
    public int Id;
    [HideInInspector]
    public Vector3 gobalSpawnTarget;
    public GameObject spawnHere;
    public GameObject CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        displayName_Text.text = displayName;
    }

    public void SetId(int id)
    {
        Id = id;
    }
    public int GetId()
    {
        return Id;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.LookAt(Camera.main.transform.position);
        gobalSpawnTarget = spawnHere.transform.transform.position;
        if (displayName != "")
        {
            displayName_Text.text = displayName;
        }
    }
}
