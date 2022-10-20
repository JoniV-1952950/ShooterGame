using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro scoreText;
    [SerializeField]
    private GameObject leftWall;
    [SerializeField]
    private GameObject rightWall;
    [SerializeField]
    private GameObject targetPrefab;
    [SerializeField]
    private int targetAmount;
    [SerializeField]
    private int totaalTargets;
    private int totaalScore;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void newTarget()
    {
        
        int rand = UnityEngine.Random.Range(0, 2);
        Vector3 start = new Vector3(0,0,0);
        Vector3 destination = new Vector3(0, 0, 0);


        if (rand == 0)
        {
            start = new Vector3(leftWall.transform.position.x + 0.7f, UnityEngine.Random.Range(0.7f, 2.5f), UnityEngine.Random.Range(6f, 18f));
            destination = new Vector3(rightWall.transform.position.x - 0.7f, UnityEngine.Random.Range(0.7f, 2.5f), UnityEngine.Random.Range(6f, 18f));

        }
        else
        {
            start = new Vector3(rightWall.transform.position.x - 0.7f, UnityEngine.Random.Range(0.7f, 2.5f), UnityEngine.Random.Range(6f, 18f));
            destination = new Vector3(leftWall.transform.position.x + 0.7f, UnityEngine.Random.Range(0.7f, 2.5f), UnityEngine.Random.Range(6f, 18f));
        }
        GameObject newTarget = Instantiate(targetPrefab, this.transform, true);
        newTarget.transform.position = start;
        newTarget.GetComponent<MoveTarget>().setDestination(destination);
        newTarget.GetComponent<MoveTarget>().setScoreText(scoreText);
        totaalTargets -= 1;
    }

    private void endGame()
    {
        UnityEngine.Object.Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (totaalTargets == 0)
            endGame();
        // iets dat kijkt wanneer een target kapot is
        if(transform.childCount < targetAmount)
        {
            newTarget();
            
        }
    }
}
