using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;

    void Start()
    {
        
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (Input.GetKey(KeyCode.E) && distance < 5)
            playerController.bowQuality = "gold";
    }
}
