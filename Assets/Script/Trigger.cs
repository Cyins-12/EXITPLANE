using UnityEngine;

public class TriggerPanel : MonoBehaviour
{
    public GameObject panelToShow;

    private void Start()
    {
        if (panelToShow != null)
        {
            panelToShow.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (panelToShow != null)
        {
            panelToShow.SetActive(true);
            Debug.Log("Panel diaktifkan oleh: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (panelToShow != null)
        {
            panelToShow.SetActive(false);
            Debug.Log("Panel dinonaktifkan karena " + other.name + " meninggalkan trigger.");
        }
    }
}
