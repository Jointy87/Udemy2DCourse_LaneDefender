using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //Parameters
    float currentSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void ActivateCollider()
    {
        Collider2D myCollider = GetComponent<Collider2D>();
        myCollider.enabled = true;
    }
}
