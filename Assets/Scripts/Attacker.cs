using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
	//Parameters
	[SerializeField] int attackDamage;
	float currentSpeed = 1f;
	GameObject currentTarget;
	Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	void Update()
	{
		transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
		UpdateAnimationState();
	}

	private void UpdateAnimationState()
	{
		if(!currentTarget)
		{
			animator.SetBool("isAttacking", false);
		}
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

	public void Attack(GameObject target)
	{
		animator.SetBool("isAttacking", true);
		currentTarget = target;
	}

	public void StrikeCurrentTarget()
	{
		if(!currentTarget) { return; }

		Health health = currentTarget.GetComponent<Health>();
		if(health)
		{
			health.GetHit(attackDamage);
		}
	}
}
