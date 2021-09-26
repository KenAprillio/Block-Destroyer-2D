using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    public bool launch = false;
    public GameObject player;
    GameObject mainCamera;
    public int damage = 1;
    public Text scoreText;

    int blocksMany;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        launchMech();
        mainCamera = GameObject.Find("Main Camera");

        GameObject[] blocksArray = GameObject.FindGameObjectsWithTag("Blocks");
        blocksMany = blocksArray.Length;
    }

    // Update is called once per frame
    void Update()
    {
        launchMech();
    }

    public void launchMech()
    {
        if (launch)
        {
            this.transform.position = new Vector2(
            player.transform.position.x,
            -4);
        }

        if(launch && Input.GetKeyDown(KeyCode.Space))
        {
            launch = false;
            Vector2 dir = new Vector2(0, 5).normalized;
            rigid.AddForce(dir * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom Wall")
        {
            launch = true;
            launchMech();
            Data.scoreData -= 15;
            scoreText.text = Data.scoreData.ToString();

            if (Data.scoreData < 0)
            {
                Destroy(gameObject);
                mainCamera.GetComponent<StartController>().gameoverPanel.SetActive(true);
            }
        }

        if (collision.gameObject.name == "Board")
        {
            float corner = (transform.position.x - collision.transform.position.x) * 5f;
            Vector2 direction = new Vector2(corner, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(direction * force);
        }

        if (collision.gameObject.tag == "Blocks")
        {
            collision.gameObject.GetComponent<BlockController>().blockDamage(damage);

            if (collision.gameObject.GetComponent<BlockController>().blockLife == 0)
            {
                Data.scoreData += collision.gameObject.GetComponent<BlockController>().score;
                scoreText.text = Data.scoreData.ToString();
                Destroy(collision.gameObject);

                blocksMany--;
            }

            if (blocksMany == 0)
            {
                mainCamera.GetComponent<StartController>().winPanel.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
