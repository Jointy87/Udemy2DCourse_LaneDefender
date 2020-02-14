using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorFox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if(otherObject.GetComponent<Defender>() && other.tag == "Wall")
        {
            Jump();
        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    public void Jump()
    {
        GetComponent<Animator>().SetTrigger("JumpTrigger");
    }
}
