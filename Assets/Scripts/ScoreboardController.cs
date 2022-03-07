using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardController : MonoBehaviour
{
    public Text scoreText;
    private float score = 0;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        score = gameController.score;
        scoreText.text = score.ToString();

        Vector3 rotation = new Vector3(0,-90,-45);
        transform.eulerAngles = rotation;
        transform.position = transform.parent.transform.position + new Vector3(0,9,-11.5f);
    }
}
