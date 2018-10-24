using UnityEngine;

[CreateAssetMenu(fileName = "Collectable Object", menuName = "Collectables")]
public class CollectableObject : ScriptableObject {

    // Containes all the data for each collectable object so cool
    public string objectName = "Collectable";
    public Sprite icon;

    public virtual void Use () {
        // Use object
        Debug.Log("Using " + objectName);
    }
}
