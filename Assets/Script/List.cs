using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class List : MonoBehaviour
{
    [SerializeField]
    private List<string> liststring = new List<string>();

    [SerializeField]
    private List<Sprite> listsprite = new List<Sprite>();


    [SerializeField]
    private TMP_Text _Text;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private GameObject _canvasstring;

    [SerializeField]
    private GameObject _canvassprite;

    private int indexliststring;
    private int indexlistsprite;

    private void Awake()
    {
        indexliststring = 0;
        indexlistsprite = 0;
    }

    private void Start()
    { 
        liststring.Add("Budi");
        liststring.Add("Asep");
        liststring.Add("Yanto");
    }

    public void NextNama()
    {
        if (indexliststring < liststring.Count - 1)
        {
            indexliststring++;
            _Text.text = liststring[indexliststring];
        }
        else
        {
            _canvasstring.SetActive(false);
        }
    }


    public void PreviousNama()
    {
        if (indexliststring > 0)
        {
            indexliststring--;
            _Text.text = liststring[indexliststring];
        }
        else
        {
            _canvasstring.SetActive(false);
        }
    }

    public void NextSprite()
    {
        if (indexlistsprite < listsprite.Count - 1)
        {
            indexlistsprite++;
            _image.sprite = listsprite[indexlistsprite];
        }
        else
        {
            _canvassprite.SetActive(false);
        }
    }


    public void PrevSprite()
    {
        if (indexlistsprite > 0)
        {
            indexlistsprite--;
            _image.sprite = listsprite[indexlistsprite];
        }
        else
        {
            _canvassprite.SetActive(false);
        }
    }
}
