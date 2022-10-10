using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TargetScore : MonoBehaviour
{
    private Vector3 location;
    [SerializeField]
    private TextMeshPro scoreText;

    [SerializeField]
    private float lifeTime;

    private void OnCollisionEnter(Collision collision) {
        StopAllCoroutines();

        location = gameObject.transform.position;
        Vector3 point = collision.GetContact(0).point;
        
        Vector3 relLoc = (point - location)*100;
        double distance = Math.Sqrt((Math.Pow(relLoc.x,2) + Math.Pow(relLoc.y, 2)));
        int score = 10 - (int)distance/3; // /3 because the radius is 0.3 
        scoreText.SetText(score.ToString());
        StartCoroutine(RemoveTextAfterDelay(scoreText,lifeTime));
    }

    private IEnumerator RemoveTextAfterDelay(TextMeshPro scoreText, float delay)
    {
        yield return new WaitForSeconds(delay);
        scoreText.SetText("");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }        

    // Update is called once per frame
    void Update()
    {
        
    }

}
