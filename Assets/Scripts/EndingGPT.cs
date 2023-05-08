using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class EndingGPT : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float changeInterval = 0.5f; // the interval between string changes in seconds

    private string baseText = "Please wait";
    private int dotCount = 0;

    private const string API_KEY = "";
    private const string API_URL = "https://api.openai.com/v1/chat/completions";

    private string prompt_input = "";

    public bool gptDone;

    private string textForLogging;

    void Start()
    {
        prompt_input = DataManager.Instance.stringToPass;
        gptDone = false;
        textForLogging = "";
        StartCoroutine(SendRequestToChatGPT(prompt_input));
    }

    // Update is called once per frame
    void Update()
    {
        if (gptDone == false)
        {
           loadingText();
        }

        
    }

    void loadingText()
    {
        float timeElapsed = Time.time;
        int dotCount = Mathf.FloorToInt(timeElapsed / changeInterval) % 7;
        string dots = new string('.', dotCount);

        textMeshPro.text = baseText + dots;
    }

    void loadResponseGPT (string inp)
    {
        textMeshPro.text = inp;
    }

    private IEnumerator SendRequestToChatGPT(string promptStr)
    {
        var request = new UnityWebRequest(API_URL, "POST");
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", $"Bearer {API_KEY}");

        var messageData = new
        {
            model = "gpt-3.5-turbo",
            messages = new[] { new { role = "user", content = promptStr } }
        };

        string jsonBody = JsonConvert.SerializeObject(messageData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            gptDone = true;

            string jsonResponse = request.downloadHandler.text;
            Debug.Log($"Response: {jsonResponse}");
            
            var deserializedResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);
            var choices = JsonConvert.DeserializeObject<List<object>>(deserializedResponse["choices"].ToString());
            var messages = JsonConvert.DeserializeObject<Dictionary<string, object>>(choices[0].ToString());
            var messageDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(messages["message"].ToString());

            Debug.Log(messageDict["content"]);
            loadResponseGPT(messageDict["content"].ToString());
            textForLogging = messageDict["content"].ToString();
            textMeshPro.text = messageDict["content"].ToString();

        }
        else
        {
            Debug.LogError($"Error: {request.error}");
        }
    }

    private void OnApplicationQuit()
    {
        var id = System.Guid.NewGuid().ToString();
        string path = Application.dataPath + "/../saved_text_" + id + ".txt"; // Change the file path as needed

        // Create a new file and write the text to it
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write("Prompt:\n" + DataManager.Instance.stringToPass + "\n\nGenerated Ending:\n" + textForLogging);
            Debug.Log("Saved to " + path);
        }
    }
}
