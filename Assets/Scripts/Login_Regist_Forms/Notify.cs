using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Notify
{
    private GameObject _notifyPrefab;
    private TextMeshProUGUI _notifyText;
    private GameObject _perentCanvas;
    
    public Notify()
    {
        Debug.Log("Notify Create");
        _notifyPrefab = Resources.Load<GameObject>("Prefabs/Notify/NotifyWrap");
        _perentCanvas = GameObject.Find("Canvas");
    }

    ~Notify()
    {
        _notifyText = null;
    }
    public void CreateNotify(string text)
    {
        GameObject notifyPanel = GameObject.Instantiate(_notifyPrefab, _perentCanvas.transform);
        _notifyText = notifyPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _notifyText.text = text;

        ///await Task.Delay(2000);

        //RemoveNotify(notifyPanel);

    }

    public void RemoveNotify(GameObject notifyPanel)
    {
        if (notifyPanel != null)
        {
            GameObject.Destroy(notifyPanel);
        }
    }
}
