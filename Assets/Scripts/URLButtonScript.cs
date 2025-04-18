using UnityEngine;


public class URLButtonScript : MonoBehaviour
{
    [SerializeField]
    private string url;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Open() {
        Application.OpenURL(url);
    }
}
