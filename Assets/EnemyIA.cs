using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyIA : MonoBehaviour
{
	public AIPath aiPath;
	private Animator anim;
	private Quaternion lookLeft;
	private Quaternion lookRight;
	private float timeCount = 1.0f;
	
    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
        lookRight = transform.rotation;
		lookLeft = lookRight * Quaternion.Euler(0, 180, 0); 
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
		
		
        if (aiPath.desiredVelocity.x >= 0.01f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, lookLeft, timeCount);
		}
		else if(aiPath.desiredVelocity.x <= 0.01f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRight, timeCount);
		}
		timeCount = timeCount + Time.deltaTime;
    }
}
