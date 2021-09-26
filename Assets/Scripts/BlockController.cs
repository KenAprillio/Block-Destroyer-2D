using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{
    public Sprite[] sprites;

    public int score;
    public int blockLife;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        blockLife = sprites.Length;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[blockLife - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void blockDamage(int damageAmount)
    {
        blockLife -= damageAmount;

        if (blockLife > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[blockLife - 1];
        }
        
    }
}
