using System.Collections;
using UnityEngine;

public class Interstitial : MonoBehaviour
{
    [SerializeField] private GameObject[] interstitialAds; // Assign ad GameObjects in Inspector
    [SerializeField] private GameObject adCanvas; // Assign the UI Canvas in Inspector
    [SerializeField] private float exitButtonDelay = 15f; // Time before the Canvas appears

    private int adIndex = 0; // Tracks current ad
    private bool isAdActive = false;

    private void Update()
    {
        if (GameManager.Instance.gameOver && !isAdActive)
        {
            StartCoroutine(ShowNextAd());
        }
    }

    private IEnumerator ShowNextAd()
    {
        isAdActive = true;
        HideAllAds();
        interstitialAds[adIndex].SetActive(true);
        adCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(exitButtonDelay);
        adCanvas.gameObject.SetActive(true);
    }

    public void OnExitButtonPressed()
    {
        // Hide the current ad and disable the entire ad canvas
        interstitialAds[adIndex].SetActive(false);
        adCanvas.gameObject.SetActive(false);
        isAdActive = false;

        // Move to the next ad (loop back to start if needed)
        adIndex = (adIndex + 1) % interstitialAds.Length;
    }

    private void HideAllAds()
    {
        foreach (GameObject ad in interstitialAds)
        {
            ad.SetActive(false);
        }
    }
}
