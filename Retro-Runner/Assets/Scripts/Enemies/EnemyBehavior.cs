using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public Transform playerTransfrom;
    public Vector3 axis;
    public int speed;
    public Vector3 enemyHeight;
    public int heightOffset;
    public float damage = 10f;
    public int waitTime;

    void Start() {
        StartCoroutine(Shoot(waitTime));
    }

    void FixedUpdate () {
        playerTransfrom = GameObject.Find("Test Player").GetComponent<Transform>();
        transform.RotateAround(playerTransfrom.position, axis, speed);
        transform.LookAt(playerTransfrom);
        enemyHeight = transform.position;
        enemyHeight.y = playerTransfrom.position.y + heightOffset;
        transform.position = enemyHeight;
	}

    IEnumerator Shoot(int waitTime) {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            Debug.Log("Shooting");
            Debug.DrawRay(transform.position, transform.forward * 100, Color.black, 10f, false);
            Debug.Log(hit.transform.name);
            PlayerDamage playerDamage = hit.transform.GetComponent<PlayerDamage>();
            if (playerDamage != null) {
                playerDamage.Damage(damage);
            }
        }
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Shoot(waitTime));
    }
}
