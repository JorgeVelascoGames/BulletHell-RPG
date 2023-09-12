using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
	[Title("WhiteFlashEffect")]
	[SerializeField] private Material whiteFlashMat;
	[SerializeField] private float whiteFlashTimer = 0.2f;

	[Title("DeathParticles")]
	[SerializeField] private GameObject deathParticles;

	private Material defaultMat;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		defaultMat = spriteRenderer.material;
	}

	public IEnumerator FlashWhiteCorutine()
	{
		if (whiteFlashMat == null)
			StopCoroutine(FlashWhiteCorutine());

		spriteRenderer.material = whiteFlashMat;

		yield return new WaitForSeconds(whiteFlashTimer);

		spriteRenderer.material = defaultMat;
	}

	public void DeathParticles()
	{
		Instantiate(deathParticles, transform.position, Quaternion.identity);
	}


}
