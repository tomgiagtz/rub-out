using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public KeyCode launchKey = KeyCode.Space;
    public Transform startPos;
    public Rigidbody2D rb;
    public float launchForce = 500f;
    public float minimumVelocity = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onBallDestroy += HandleBallDestroy;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //while paused
        if (!GameState.state.gc_playing) {
            transform.position = startPos.position;

            if (Input.GetKey(launchKey)) {
                rb.AddForce(Vector2.up * launchForce);
                GameState.state.gc_playing = true;
            }

        } else {

            if (rb.velocity.magnitude < minimumVelocity) {
                Debug.Log("addingForde");
                rb.AddForce(rb.velocity *  0.2f);
            }

        }

        

        
    }

    void HandleBallDestroy() {
        transform.position = startPos.position;
        rb.velocity = Vector2.zero;
        GameState.state.gc_playing = false;
    }
}
