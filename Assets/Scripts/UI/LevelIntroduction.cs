using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntroduction : MonoBehaviour
{
    public string levelName;
    Text levelText;
    public GameObject startingSlipgate;

    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponent<Text>();
        levelText.text = levelName;
        StartCoroutine(fadeIn());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(1f);
        levelText.color = new Color(levelText.color.r, levelText.color.g, levelText.color.b, 0);

        while (levelText.color.a < 1.0f)
        {
            levelText.color = new Color(levelText.color.r, levelText.color.g, levelText.color.b, levelText.color.a + (0.75f * Time.deltaTime));
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        levelText.color = new Color(levelText.color.r, levelText.color.g, levelText.color.b, 1);

        while (levelText.color.a > 0.0f)
        {
            levelText.color = new Color(levelText.color.r, levelText.color.g, levelText.color.b, levelText.color.a - (0.75f * Time.deltaTime));
            yield return null;
        }
        startingSlipgate.SetActive(true);
    }
}
