using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    public LayerMask deathLayer;
    public LayerMask brickLayer;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == GetLayerMaskValue(deathLayer)) {
            GameEvents.current.BallDestroy();
        } 

        if (other.gameObject.layer == GetLayerMaskValue(brickLayer)) {
            GameEvents.current.BrickHit(other.gameObject.GetInstanceID());
        }
        // Destroy(other.gameObject);
    }

    
    //convert layer mask value to int seen in Layer selector
    private int GetLayerMaskValue(LayerMask layerMask) {
        //layer mask value comes in as 2 ^ layerValue, use log to reduce to layer value
        return (int) Mathf.Log(layerMask, 2);
    }
}