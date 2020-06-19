
using System.Collections;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public GameObject winUI;
    public ParticleSystem winCelebration;
    public int playerReach;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winCelebration.Play();
        StartCoroutine(waitForCelebration());
        
    }
    public IEnumerator waitForCelebration()
    {
        yield return new WaitForSeconds(2.5f);
        winUI.SetActive(true);
        PlayerPrefs.SetInt("levelReached", playerReach);
        Time.timeScale = 0f;
    }
}
