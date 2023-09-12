using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockBack : IInteractable
{

	public void GetKnockedBack(Transform damageSource, float knockBackForce);
}
