using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	public int health = 100;

	public GameObject deathEffect;

	void Start()
    {
        switch (GameSettings.CurrentDifficulty)
        {
            case GameSettings.Difficulty.BC:
                health = 800;
                break;
            case GameSettings.Difficulty.Medium:
                health = 100;
                break;
            case GameSettings.Difficulty.Impossible:
                health = 60;
                break;
        }
    }
	public void TakeDamage(int damage)
	{
		health -= damage;

		StartCoroutine(DamageAnimation());

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
    	PlayerPrefs.SetString("GameResult", "lose"); // Mark that the player lost
    	SceneManager.LoadScene("game-win-scene");    // Load the result scene
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

}
