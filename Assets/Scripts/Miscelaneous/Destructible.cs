using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IDamageable, IKnockBack
{
	[SerializeField] private GameObject destroyVFX;

	public void Damage(int amount = 0)
	{
		DestroyThisObject();
	}

	public void GetKnockedBack(Transform damageSource, float knockBackForce)
	{
	}

	private void DestroyThisObject()
	{
		Instantiate(destroyVFX, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
