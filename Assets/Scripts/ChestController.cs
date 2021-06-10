using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject player;
    public MeshRenderer coins;
    public PlayerController playerController;
    private bool hasGold = true;

    void Start()
    {
        
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 5 && hasGold)
		{
			playerController.score += 5;
            hasGold = false;
            coins.enabled = false;
		}
    }
}
