using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private bool canShoot = true;
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float sshootCooldown = 1f;

	// Update is called once per frame
	void Update()
	{
		Move();
	}
	
	private void Move()
	{
		if(Input.GetKey(KeyCode.A))
		{
			
		}
	}
}
