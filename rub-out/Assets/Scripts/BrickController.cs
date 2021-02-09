using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called before the first frame update
    public int hardness = 1;
    public Sprite[] hardnessSprites;
    private SpriteRenderer sr;
    // private Sprite currSprite;
    void Start()
    {
        GameEvents.current.onBrickHit += HandleBrickHit;

        sr = GetComponent<SpriteRenderer>();
    }

    private void OnDisable() {
        GameEvents.current.onBrickHit -= HandleBrickHit;
    }

    private void Update() {
        if (hardness < 0 || hardness > hardnessSprites.Length - 1) {
            Debug.LogError("Hardness invalid: " + hardness );
        } else {
            sr.sprite = hardnessSprites[hardness];
        }
    }

    
    void HandleBrickHit(int _id) 
    {
        if (_id == gameObject.GetInstanceID()) {
            Debug.Log("hit");
            if (hardness > 1) {
                hardness--;
            } else {
                Destroy(gameObject);
            }
        }
    }
}
