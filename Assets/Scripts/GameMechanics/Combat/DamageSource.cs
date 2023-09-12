using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
	public Action<IInteractable> OnHit;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent<IInteractable>(out IInteractable target))
		{
			if (OnHit != null)
				OnHit(target);
		}
	}
}
