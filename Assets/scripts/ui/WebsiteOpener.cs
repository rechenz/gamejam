using UnityEngine;

public class WebsiteOpener : MonoBehaviour
{
    [SerializeField] private string url;
    
    public void OpenURL()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
    }
}