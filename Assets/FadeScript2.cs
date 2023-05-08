using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript2 : MonoBehaviour
{
    public float fadeSpeed = 1;
    private float fade;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        fade = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        fade -= Time.deltaTime * fadeSpeed;
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, fade);

    }
}
