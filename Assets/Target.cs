
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public void TakeDamage(float dmg) {
        health -= dmg;
        if (health<= 0f) {
            Destroy(gameObject);
        }
    }
}
