using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public float speed;
    public string axis;

    public float wallLeft;
    public float wallRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(axis) * speed * Time.deltaTime;

        float nextPos = transform.position.x + move;
        if (nextPos > wallRight)
        {
            move = 0;
        }
        if (nextPos < wallLeft)
        {
            move = 0;
        }
        transform.Translate(move, 0, 0);
    }
}
