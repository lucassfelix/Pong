using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject ball;
    public GameObject playerGB;
    public GameObject opponent;
    public Text score;
    
    private int[] _score;
    private float _ballPosition;

    private Camera _cam;
    // Start is called before the first frame update
    void Awake()
    {
        if (Camera.main==null) {Debug.LogError("Camera.main not found."); return;}

        _cam = Camera.main;

        _score = new [] {0,0};
        

    }

    private void RegisterScore(int player)
    {
        _score[player]++;
        
        var scoreString = _score[0] + "-" + _score[1];
        score.text = scoreString;
        ball.BroadcastMessage("ResetPositions",player);
        playerGB.BroadcastMessage("ResetPositions");
        opponent.BroadcastMessage("ResetPositions");
    }
    
    // Update is called once per frame
    void Update()
    {
        _ballPosition = _cam.WorldToScreenPoint(ball.transform.position).x;

        //Check for winners
        if (_ballPosition < 10)
        {
            RegisterScore(1);
        }

        if (_ballPosition > _cam.pixelWidth - 10)
        {
            RegisterScore(0);
        }
    }
}
