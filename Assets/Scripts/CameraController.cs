using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] public Transform player;

    private int zoom = -20;
    private bool zFlag;

    // Start is called before the first frame update
    private void Start()
    {
        zFlag = true;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + .5f, zoom);

        if (Input.GetKeyDown(KeyCode.C))
        {
            
            if (zFlag) 
            {
                zoom = -10;
                zFlag = false;
            }
            else
            {
                zoom = -20;
                zFlag = true;
            }
        }
    }
}
