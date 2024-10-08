using System.Collections;
using UnityEngine;

namespace Chapter.Singleton
{
	public class EnemyStationary : MonoBehaviour
	{
		private int health = 1;
		[SerializeField] private float moveCount;
		[SerializeField] private float moveAmount = 10;
		[SerializeField] private float moveDelay = 2f;

		private bool canMove = true;

		void FixedUpdate()
		{
			if (canMove)
			{
				if (moveCount < 3)
				{
					moveCount++;
					transform.position += Vector3.left * moveAmount;
				}
				if (moveCount > 3)
				{
					moveCount = 0;
					moveAmount *= -1;
				}

				StartCoroutine(MoveCooldown(moveDelay));
			}
		}

		private IEnumerator MoveCooldown(float time)
		{
			canMove = false;
			yield return new WaitForSeconds(time);
			canMove = true;
		}

		public void TakeDamage(int damage)
		{
			health -= damage;
			if (health < 0)
			{
				//T.InstanceupdateScore(100);
				Destroy(gameObject);
			}
		}
	}
}
