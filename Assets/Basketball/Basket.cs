using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Basket : MonoBehaviour
{
    public GameObject score;
    private bool goRight = true;
    private bool goLeft = false;


    void OnCollisionEnter()
    {
        // als je de basket raakt
    }

    void Update()
    {
        if (GameMaster.instance.getMovingBasket() == true)
        {
            if (transform.position.x >= 208)
            {
                goRight = false;
                goLeft = true;
            }
            else if (transform.position.x <= -71)
            {
                goLeft = false;
                goRight = true;
            }
            if (goRight) transform.Translate(-Vector3.right * GameMaster.instance.getBasketSpeed() * Time.deltaTime);
            else if (goLeft) transform.Translate(-Vector3.left * GameMaster.instance.getBasketSpeed() * Time.deltaTime);
        }
    }

    void OnTriggerEnter()
    {
        int currentScore = int.Parse(score.GetComponent<Text>().text) + 1;
        GameMaster.instance.setMinimumValue(currentScore);
        score.GetComponent<Text>().text = currentScore.ToString();
        GetComponent<AudioSource>().Play();
    }

    public void Reset()
    {
        transform.position = GameMaster.instance.getBasketStartPosition();
    }
}