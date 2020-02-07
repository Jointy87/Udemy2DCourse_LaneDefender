using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorLizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        Debug.Log("Colliding");
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().PlayAttackAnimation(otherObject);
            Debug.Log("Got This Far");
        }
    }
}
