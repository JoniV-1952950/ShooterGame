using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DontCare : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighLightComponent()
    {
        buttonText.color = Color.blue;
    }

    public void SelectComponent()
    {
        buttonText.color = Color.green;

    }

    public void Reset()
    {
        buttonText.color = Color.black;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "bullet")
        {
            SelectComponent();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Reset();
        }
    }
}
