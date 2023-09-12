using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable : IInteractable
{
	public void Damage(int amount = 0);
}
