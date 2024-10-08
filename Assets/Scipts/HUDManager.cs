using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Chapter.Singleton
{
	public class Singleton<T> : MonoBehaviour where T : Component
	{
		private static T _instance;
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindAnyObjectByType<T>();
					if (_instance == null)
					{
						GameObject obj = new();
						obj.name = typeof(T).Name;
						_instance = obj.AddComponent<T>();
					}
				}
				return _instance;
			}
		}
		private float score = 0f;
		public TextMeshPro scoreDisplay;
		public TextMeshPro lifeCount;
		private void Awake()
		{
			if (_instance == null)
			{
				_instance = this as T;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
		public void updateScore(float _score)
		{
			score += score;
			scoreDisplay.text = score.ToString();
		}
		public void updateLives(float lives)
		{
			lifeCount.tag = lives.ToString();
		}
	}
}
