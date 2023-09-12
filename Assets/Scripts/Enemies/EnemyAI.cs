using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
	{
		Roaming,
	}

	private State state;
	private EnemyPathfinding pathfinding;

	private void Awake()
	{
		state = State.Roaming;
		pathfinding = GetComponent<EnemyPathfinding>();
	}

	private void Start()
	{
		StartCoroutine(RoamingRoutine());
	}

	private IEnumerator RoamingRoutine()
	{
		while(state == State.Roaming)
		{
			Vector2 roamPosition = GetRoamingPosition();
			pathfinding.MoveTo(roamPosition);
			yield return new WaitForSeconds(2f);
		}
	}

	private Vector2 GetRoamingPosition()
	{
		return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
	}

}
