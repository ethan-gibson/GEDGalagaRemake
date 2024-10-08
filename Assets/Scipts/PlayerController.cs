using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private bool canShoot = true;
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float shootCooldown = 1f;
	[SerializeField] private GameObject Projectile;
	public float playerLives;

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();
		if (canShoot)
		{
			var temp = Instantiate(Projectile, transform.position, Quaternion.identity);
			Destroy(temp, 4f);
			StartCoroutine(ShootCooldownTimer(shootCooldown));
		}
	}

	private void Move()
	{
		transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, 0);
	}

	private IEnumerator ShootCooldownTimer(float time)
	{
		canShoot = false;
		yield return new WaitForSeconds(time);
		canShoot = true;
	}
	public void TakeDamage(float damage)
	{
		playerLives--;
	}
}
