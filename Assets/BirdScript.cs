using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public GameObject birdy;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject startScreen;
    private bool gameStart = false;

    // Added wings as a feature
    public SpriteRenderer wings;
    public Sprite up;
    public Sprite down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        wings = transform.Find("Wing1").GetComponent<SpriteRenderer>();
        myRigidbody.simulated = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (!gameStart)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdy.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 10;
            // myRigidbody.velocity = Vector2.up * flapStrength;
            wings.sprite = up;
        }

        if(Input.GetKeyUp(KeyCode.Space) && birdIsAlive)
        {
            wings.sprite = down;
        }

        if (myRigidbody.position.y > 17 && birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

        else if (myRigidbody.position.y < -17 && birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    public void startedGame()
    {
        gameStart = true;
        myRigidbody.simulated = true;
        startScreen.SetActive(true);
    }
}
