using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Parameters
    [SerializeField] float projectileSpeed;
    [SerializeField] float spinSpeed;
    [SerializeField] int projectileDamage;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed, Space.World);

        transform.Rotate(0, 0, -spinSpeed * Time.deltaTime, Space.World);
    }

    public int SetDamage()
    {
        return projectileDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attacker")
        {
            other.gameObject.GetComponent<Health>().GetHit(projectileDamage);

            Destroy(gameObject);
        }
    }
}
