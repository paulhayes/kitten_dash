using UnityEngine;
using System.Collections;

public class RunAndJump2 : MonoBehaviour 
{

	public float forwardSpeed;
	public float jumpForce;
	public Collider2D groundDetection;
	public AudioSource jumpSound;
	public float startRunningAt;
	
	private bool jump = false;
	private Rigidbody2D m_rigidBody;
	
	private Collider2D[] overlappingColliders;
	private bool isTouchingGround;
	private Bounds groundDetectionBox;
	private Animator animator;
	private bool isRunning;
		
	void Awake () 
	{
		m_rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		overlappingColliders = new Collider2D[8];
	}
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(startRunningAt);	
		Run();	
	}
	
	void Run()
	{
		isRunning = true;
		animator.SetBool("Running",true);
	}
	
	void Stop()
	{
		isRunning = false;
		animator.SetBool("Running",false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetButtonDown("Jump") ){
			jump = true;
		}
	}
	
	void FixedUpdate()
	{
		GroundCheck();
		Vector2 velocity = m_rigidBody.velocity;
		
		if( !isRunning ){
			return;
		}
		
		velocity.x = forwardSpeed;
		m_rigidBody.velocity = velocity;
		
		if( jump ){
			if( isTouchingGround ){
				m_rigidBody.AddForce( Vector2.up * jumpForce, ForceMode2D.Impulse );
				jumpSound.Play();
			}
			jump = false;
		}
		
	}
	
	void GroundCheck()
	{
		Bounds box = groundDetection.bounds; 
		int numColliders = Physics2D.OverlapAreaNonAlloc( box.min, box.max, overlappingColliders );
		isTouchingGround = false;
		
		for( int i=0; i<numColliders; i++ ){
			if( overlappingColliders[i].gameObject != gameObject ){
				isTouchingGround = true;
				
				break;
			}
		} 
		
	}
	
	void OnGameOver()
	{
		Destroy(this);
	}
}
