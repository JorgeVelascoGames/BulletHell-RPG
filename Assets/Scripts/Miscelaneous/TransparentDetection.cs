using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TransparentDetection : MonoBehaviour
{
	[Range(0, 1)]
	[SerializeField] private float transparencyAmount = 0.8f;
	[SerializeField] private float fadeTime = 0.4f;

	private SpriteRenderer spriteRenderer;
	private Tilemap tilemap;

	private void Awake()
	{
		if(TryGetComponent<SpriteRenderer>(out SpriteRenderer renderer))
		{
			spriteRenderer = renderer;
		}

		if (TryGetComponent<Tilemap>(out Tilemap tm))
		{
			tilemap = tm;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerBrain>())
		{
			if(spriteRenderer != null)
				StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, transparencyAmount));

			if(tilemap != null)
				StartCoroutine(FadeRoutine(tilemap, fadeTime, tilemap.color.a, transparencyAmount));
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerBrain>())
		{
			if (spriteRenderer != null)
				StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, 1));

			if (tilemap != null && tilemap.isActiveAndEnabled)
				StartCoroutine(FadeRoutine(tilemap, fadeTime, tilemap.color.a, 1));
		}
	}

	private IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime, float startValue, float targetTransparency)
	{
		float elapseTime = 0;

		while(elapseTime < fadeTime)
		{
			elapseTime += Time.deltaTime;
			float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapseTime / fadeTime);

			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.g, newAlpha);

			yield return null;
		}
	}

	private IEnumerator FadeRoutine(Tilemap tilemap, float fadeTime, float startValue, float targetTransparency)
	{
		float elapseTime = 0;

		while (elapseTime < fadeTime)
		{
			elapseTime += Time.deltaTime;
			float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapseTime / fadeTime);

			tilemap.color = new Color(tilemap.color.r, tilemap.color.b, tilemap.color.g, newAlpha);

			yield return null;
		}
	}

}
