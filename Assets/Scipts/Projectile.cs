using UnityEngine;

namespace Chapter.Singleton
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private float projectileSpeed;
		private const int damage = 1;
		void FixedUpdate()
		{
			transform.position += transform.up * projectileSpeed;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			Debug.Log("" + collision.gameObject.name);
			var temp = collision.gameObject.GetComponent<EnemyStationary>();
			if (temp == null) { return; }
			temp.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
