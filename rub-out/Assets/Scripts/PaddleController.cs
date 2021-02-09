using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public Vector2 edgeMinMax = new Vector2(-5.5f, 5.5f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime* speed);
        if (transform.position.x < edgeMinMax.x) {
            transform.position = new Vector2(edgeMinMax.x, transform.position.y);
        }
        if (transform.position.x > edgeMinMax.y) {
            transform.position = new Vector2(edgeMinMax.y, transform.position.y);
        }
    }
}
