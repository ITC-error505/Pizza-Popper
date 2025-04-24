using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices; 
using System.Collections;
using UnityEngine.Networking;
using System;

public class GameoverScreenScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject pauseButton;

    private string uri = "https://backend-aqzm.onrender.com/score/post";
   
    public void Setup(string score) { 

        gameObject.SetActive(true);
        pauseButton.SetActive(false);
        
        scoreText.text = "Score: " + score;
        
        Time.timeScale = 0f;

        int scoreInt = Int32.Parse(score);

        #if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        static extern IntPtr GetLocalStorageValue();
        #endif

        string token = "SetInBrowser";

        #if UNITY_WEBGL && !UNITY_EDITOR
                IntPtr ptr = GetLocalStorageValue();
        token = Marshal.PtrToStringUTF8(ptr);
        #endif

        StartCoroutine(PostScoreToEndpoint(uri, 10, 3, token));

    }

    public void RestartButton() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    IEnumerator PostScoreToEndpoint(string uri, int score, int gameId, string accountIdToken)
    {
        ScoreData scoreData = new();
        scoreData.score = score;
        scoreData.gameId = gameId;
        string json = JsonUtility.ToJson(scoreData);

        Debug.Log(json);

        var req = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        req.SetRequestHeader("Authorization", "Bearer " + accountIdToken);
        req.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error:" + req.error);
        }
        else
        {
            Debug.Log("Received: " + req.downloadHandler.text);
        }
    }

    [System.Serializable]
    private class ScoreData
    {
        public int score;
        public int gameId;
    }

}
