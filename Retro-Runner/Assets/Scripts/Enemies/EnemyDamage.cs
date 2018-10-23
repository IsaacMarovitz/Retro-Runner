using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float health = 50f;

    public void Damage (float amount) {
        health -= amount;
        if (health <= 0f) {
            Debug.Log("Object Destroyed");
            Destroy(gameObject);
        }
    }
}
