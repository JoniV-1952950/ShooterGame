using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MoveTarget : MonoBehaviour
{
    private Vector3 destination;
    private TextMeshPro scoreText;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = UnityEngine.Random.Range(0.7f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, destination) <= 0.001f)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            var location = gameObject.transform.position;
            Vector3 point = collision.GetContact(0).point;

            Vector3 relLoc = (point - location) * 100;
            double distance = Math.Sqrt((Math.Pow(relLoc.x, 2) + Math.Pow(relLoc.y, 2)));
            int score = 10 - (int)distance / 3; // /3 because the radius is 0.3 
            int totaalScore = Int32.Parse(scoreText.text) + score;
            scoreText.SetText(totaalScore.ToString());
            UnityEngine.Object.Destroy(this.gameObject);
        }

    }

    public void setScoreText(TextMeshPro textMeshPro)
    {
        scoreText = textMeshPro;
    }

    public void setDestination(Vector3 dest)
    {
        destination = dest;
    }
}