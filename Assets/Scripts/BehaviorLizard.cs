using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorLizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    public void ActivateCollider()
    {
        Collider2D myCollider = GetComponent<Collider2D>();
        myCollider.enabled = true;
    }
}
