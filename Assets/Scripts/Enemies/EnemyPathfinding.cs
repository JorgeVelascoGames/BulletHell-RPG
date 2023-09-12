using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 2f;

	private Rigidbody2D rb;
	private Vector2 moveDir;
	private EnemyCore core;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		core = GetComponent<EnemyCore>();
	}

	private void FixedUpdate()
	{
		if(!core.gettingCC)
			rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveDir * moveSpeed * Time.fixedDeltaTime);
	}

	public void MoveTo(Vector2 targetPosition)
	{
		moveDir = targetPosition;
	}
}
