using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    [SerializeField]
    private List<Bahan> quest = new List<Bahan>();

    [SerializeField]
    private TMP_Text _Text;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private GameObject _canvasstring;

    [SerializeField]

    private int index;

    private void Awake()
    {
       index = 0;
    }

    public void NextNama()
    {
        if (index < quest.Count - 1)
        {
            index++;
            _Text.text = quest [index].text;
            _image.sprite = quest [index].sprite;
        }
        else
        {
            _canvasstring.SetActive(false);
        }
    }


    public void PreviousNama()
    {
        if (index > 0)
        {
            index--;
            _Text.text = quest [index].text;
            _image.sprite = quest [index].sprite;
        }
        else
        {
            _canvasstring.SetActive(false);
        }
    }
}
