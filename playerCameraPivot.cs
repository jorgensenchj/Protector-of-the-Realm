using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCameraPivot : MonoBehaviour {


    GameObject player;
    Vector3 offset = new Vector3(0, 1, 0);

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

