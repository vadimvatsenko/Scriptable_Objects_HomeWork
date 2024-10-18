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
        _notifyPrefab = Resources.Load<GameObject>("Prefabs/Notify/NotifyWrap");
        _perentCanvas = GameObject.Find("Canvas");

        Debug.Log("Create Notify");
    }

    ~Notify()
    {
        _notifyText = null;
    }
    public async void CreateNotify(string text)
    {
        GameObject notifyPanel = GameObject.Instantiate(_notifyPrefab, _perentCanvas.transform);
        _notifyText = notifyPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _notifyText.text = text;

        await Task.Delay(3000);

        RemoveNotify(notifyPanel);

    }

    public void RemoveNotify(GameObject notifyPanel)
    {
        if (notifyPanel != null)
        {
            GameObject.Destroy(notifyPanel);
        }
    }

}
