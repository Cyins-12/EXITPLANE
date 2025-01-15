using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Penampung : MonoBehaviour
{
    public TextMeshProUGUI PenampunganText;
    public Image PenampunganImage;

    public Sprite HasilImage;
    public string HasilText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void meggantigambar()
    {
        PenampunganImage.sprite = HasilImage;
    }

    public void menggantitext()
    {
        PenampunganText.text = HasilText;
    }

    public void gantiscene(string AERORESCUE)
    {
        SceneManager.LoadScene(AERORESCUE);
    }
}