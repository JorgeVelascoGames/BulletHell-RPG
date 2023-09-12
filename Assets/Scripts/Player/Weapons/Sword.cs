using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	[SerializeField] private int damage;
	[SerializeField] private int knockBackForce;

	[SerializeField] private GameObject slashPrefab;
	private GameObject slashEffect;

	private PlayerControls playerControls;
	private Animator animator;

	private PlayerController playerController;
	private ActiveWeapon activeWeapon;

	[SerializeField] private GameObject hitBox;

	private void Awake()
	{
		playerController = GetComponentInParent<PlayerController>();
		activeWeapon = GetComponentInParent<ActiveWeapon>();
		playerControls = new PlayerControls();
		animator = GetComponent<Animator>();

		slashEffect = Instantiate(slashPrefab, transform.parent.position, Quaternion.identity);
		slashEffect.transform.parent = transform.parent;

		slashEffect.SetActive(false);
		hitBox.SetActive(false);
	}

	private void OnEnable()
	{
		playerControls.Enable();	
		
		if(hitBox.TryGetComponent<DamageSource>(out DamageSource dmgSource))
		{
			dmgSource.OnHit += OnHit;
		}
	}

	private void OnDisable()
	{
		playerControls.Disable();
		Destroy(slashEffect);

		if (hitBox.TryGetComponent<DamageSource>(out DamageSource dmgSource))
		{
			dmgSource.OnHit -= OnHit;
		}
	}	

	private void Start()
	{
		playerControls.Combat.Attack.started += _ => Attack();
	}

	private void Update()
	{
		MouseFollow();
	}

	#region Combat

	private void Attack()
	{
		animator.SetTrigger("Attack");
		slashEffect.SetActive(true);
	}

	private void OnHit(IInteractable target)
	{
		if(target is IDamageable)
		{
			IDamageable dmg = (IDamageable)target;
			dmg.Damage(damage);
		}
		if(target is IKnockBack)
		{
			IKnockBack knock = (IKnockBack)target;
			knock.GetKnockedBack(transform, knockBackForce);
		}

	}

	#endregion

	#region Animation and movement
	public void SwingUpAnimation()
	{
		slashEffect.gameObject.transform.localRotation = Quaternion.Euler(-180, 0, 0);
		hitBox.SetActive(true);
	}

	public void SwingDownAnimation()
	{
		slashEffect.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
		hitBox.SetActive(true);
	}

	public void EndSwingAnimation()
	{
		hitBox.SetActive(false);
	}

	private void MouseFollow()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

		if(mousePos.x < playerScreenPoint.x)
		{
			activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
		}
		else
		{
			activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
	#endregion
}
