using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour, IDamageable, IKnockBack
{
	[SerializeField] private int maxHealth;
	[SerializeField] private int currentHealth;
	private Rigidbody2D rb;
	private CharacterEffects effects;
	public bool gettingCC { get; private set; }

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		effects = GetComponent<CharacterEffects>();
		gettingCC = false;
	}

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public void Damage(int amount = 0)
	{
		currentHealth -= amount;
		StartCoroutine(effects.FlashWhiteCorutine());

		if (currentHealth <= 0)
			Die();
	}

	public void Die()
	{
		effects.DeathParticles();
		Destroy(gameObject);
	}

	public void GetKnockedBack(Transform damageSource, float knockBackForce)
	{
		gettingCC = true;
		Vector2 difference = (transform.position - damageSource.position).normalized * knockBackForce * rb.mass;
		rb.AddForce(difference, ForceMode2D.Impulse);
		StartCoroutine("KnockBackRoutine");
	}
	private IEnumerator KnockBackRoutine()
	{
		yield return new WaitForSeconds(0.2f);
		rb.velocity = Vector2.zero;
		gettingCC = false;
	}
}
