using UnityEngine;
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
        int currentScore = int.Parse(score.GetComponent<GUIText>().text) + 1;
        score.GetComponent<GUIText>().text = currentScore.ToString();
        GetComponent<AudioSource>().Play();
    }
}