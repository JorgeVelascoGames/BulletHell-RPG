using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerComponent
{
	[SerializeField] private float baseMoveSpeed = 1f;
	[DisplayAsString]private float moveSpeed = 1f;

	private PlayerControls playerControls;
	private Vector2 movement;
	private Rigidbody2D rb;
	private Animator myAnimator;
	private SpriteRenderer spriteRenderer;

	public float MoveSpeed => moveSpeed;
	public float BaseMoveSpeed => baseMoveSpeed;


	private void Awake()
	{
		moveSpeed = baseMoveSpeed;
		playerControls = new PlayerControls();
		rb = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		playerControls.Combat.Power.performed += _ => UsePower();
	}

	private void OnEnable()
	{
		playerControls.Enable();
	}

	private void OnDisable()
	{
		playerControls.Disable();
	}

	private void Update()
	{
		PlayerInput();
	}

	private void FixedUpdate()
	{
		AdjusPlayerFaceDirection();
		Move();
	}

	private void PlayerInput()
	{
		movement = playerControls.Movement.Move.ReadValue<Vector2>();

		myAnimator.SetFloat("MoveX", movement.x);
		myAnimator.SetFloat("MoveY", movement.y);
	}

	private void Move()
	{
		if (movement == Vector2.zero)
			return;

		rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
		//rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + movement * moveSpeed * Time.fixedDeltaTime);
	}

	private void AdjusPlayerFaceDirection()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

		if(mousePos.x < playerScreenPoint.x)
		{
			spriteRenderer.flipX = true;
		}
		else
		{
			spriteRenderer.flipX = false;
		}
	}

	public void ChangePlayerSpeed(float newSpeed)
	{
		moveSpeed = newSpeed;
	}
	public void RestoreBaseSpeed()
	{
		moveSpeed = baseMoveSpeed;
	}

	private void UsePower()
	{
		Brain.PlayerPowers.UseActivePower();
	}
}
