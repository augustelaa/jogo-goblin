using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyIA : MonoBehaviour
{
	public AIPath aiPath;
	private Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		
		if (aiPath.desiredVelocity.x != 0f)
		{
			anim.SetBool ("Walk_Cycle_1", true);
			anim.SetBool ("Rest_1", false);
		}
		else
		{
			anim.SetBool ("Walk_Cycle_1", false);
			anim.SetBool ("Rest_1", true);
		}
    }
}
