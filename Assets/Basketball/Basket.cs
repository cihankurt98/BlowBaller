using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Basket : MonoBehaviour
{
    public GameObject score;

    void OnCollisionEnter()
    {
       // als je de basket raakt
    }

    void OnTriggerEnter()
    {
        int currentScore = int.Parse(score.GetComponent<Text>().text) + 1;
        score.GetComponent<Text>().text = currentScore.ToString();
        GetComponent<AudioSource>().Play();
    }
}