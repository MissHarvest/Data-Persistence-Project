using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Microsoft.SqlServer.Server;

public class MenuUIHandler : MonoBehaviour
{
    public InputField inputPlayerName;
    public TextMeshProUGUI textBestRecord;

    private void Start()
    {
        textBestRecord.SetText($"Best Score : {GameManager.Instance.BestPlayerName} : {GameManager.Instance.BestScore}");
    }

    public void ClickStartButton()
    {
        GameManager.Instance. PlayerName = inputPlayerName.text;
        SceneManager.LoadScene("Main");
    }

    public void ClickQuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
