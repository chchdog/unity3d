using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject WonImageObject;

    [SerializeField]
    GameObject LoseImageObject;

    public void ShowWonImage()
    {
        WonImageObject.SetActive(true);
    }


    public void ShowLoseImage()
    {
        LoseImageObject.SetActive(true);
    }

}
