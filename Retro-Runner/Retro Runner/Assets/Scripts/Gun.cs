using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public Camera fpsCam;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.black, 100f);
        }
    }
}
