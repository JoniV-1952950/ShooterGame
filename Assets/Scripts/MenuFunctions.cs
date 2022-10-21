using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI sliderText;
    [SerializeField]
    private TextMeshProUGUI simTargetText;
    [SerializeField]
    private TextMeshPro scoreText;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject uiHelper;
    private bool menuActive = false;
    [SerializeField]
    private GameObject spawner;
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.A)) {
            menuActive = !menuActive;
            menu.SetActive(menuActive);
            uiHelper.SetActive(menuActive);
        }

    }
    
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/AimTraining.unity", LoadSceneMode.Single);
        
    }

    public void startHomeScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Scene_01.unity", LoadSceneMode.Single);
    }

    public void startGame()
    {
        spawner.SetActive(true);
        menuActive = false;
        menu.SetActive(menuActive);
        uiHelper.SetActive(menuActive);
        scoreText.text = "0";
    }

    public void setBulletSpeedString(System.Single speed)
    {
        sliderText.text = "Bullet speed: " + speed.ToString();
        
    }

    public void setSimultaneousTargetString(System.Single simTargets)
    {
        simTargetText.text = "Simultaneous targets: " + simTargets.ToString();
    }

}
