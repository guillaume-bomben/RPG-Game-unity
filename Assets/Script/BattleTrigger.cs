using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public GameObject battleUI; // Le Canvas de combat
    public float battleChance = 0.1f;
    public float triggerInterval = 2f; // Intervalle de déclenchement en secondes

    private float timeSinceLastTrigger = 0f; // Temps écoulé depuis le dernier déclenchement

    private void Update()
    {
        timeSinceLastTrigger += Time.deltaTime; // Met à jour le temps écoulé
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Vérifie si le joueur est en mouvement
        Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null && playerRigidbody.linearVelocity.magnitude > 0f)
        {
            // Vérifiez si l'intervalle a été atteint
            if (timeSinceLastTrigger >= triggerInterval)
            {
                timeSinceLastTrigger = 0f;
                float randomValue = Random.value;
                Debug.Log("Random Value: " + randomValue);
                Debug.Log("Time since last trigger: " + timeSinceLastTrigger);
                if (collision.CompareTag("Player") && randomValue < battleChance)
                {
                    EnterBattle();
                }
            }
        }
    }

    private void EnterBattle()
    {
        battleUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseBattle()
    {
        battleUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Attack()
    {
        Debug.Log("Attaque !");
    }

    public void Flee()
    {
        Debug.Log("Fuite !");
        CloseBattle();
    }
}
