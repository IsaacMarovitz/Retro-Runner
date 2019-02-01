using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public GameObject rayOrigin;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if(Physics.Raycast(rayOrigin.transform.position, this.transform.forward, out hit)) {
            Debug.DrawRay(rayOrigin.transform.position, this.transform.forward, Color.black, 100f);
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.Damage(10);
            }
        }
    }
}
