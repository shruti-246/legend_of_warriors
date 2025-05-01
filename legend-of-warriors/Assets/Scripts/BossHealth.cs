using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

	public int health = 300;
	public int EnragedPoint = 300;

	public GameObject deathEffect;

	public bool isInvulnerable = true;

	void Start()
    {
        switch (GameSettings.CurrentDifficulty)
        {
            case GameSettings.Difficulty.BC:
                health = 300;
                break;
            case GameSettings.Difficulty.Medium:
                health = 800;
                break;
            case GameSettings.Difficulty.Impossible:
                health = 1200;
                break;
        }
    }

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= EnragedPoint)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		PlayerPrefs.SetString("GameResult", "win");
		Destroy(gameObject);
		SceneManager.LoadScene("game-win-scene");
	}

}
