using System;
using System.Collections;
using UnityEngine;

public class Interstitial : MonoBehaviour
{
    [SerializeField] private Menus menus;
    [SerializeField] private GameObject[] interstitialAds; // Assign ad GameObjects in Inspector
    [SerializeField] private GameObject adCanvas; // Assign the UI Canvas in Inspector
    [SerializeField] private float exitButtonDelay = 2f; // Time before the Canvas appears

    private static int adIndex = 0; // Tracks current ad
    private bool isAdActive = false;


    public bool DoOnce = true;

    public bool Reset = true;

    public float CurrentTime = 2.0f;
    public float MaxTime = 2.0f;

    private void Update()
    {
        if (GameManager.Instance.gameOver)
        {

            if (DoOnce)
            {
                DoOnce = !DoOnce;

                isAdActive = true;
                HideAllAds();
                interstitialAds[adIndex].SetActive(true);
            }


            CurrentTime -= Time.deltaTime;

            if (CurrentTime <= 0.0f && Reset)
            {
                Reset = !Reset;

                CurrentTime = MaxTime;


                adCanvas.SetActive(true);
            }



        }




    }

    public void ResetBools(bool Condition)
    {
        Reset = Condition;
        DoOnce = Condition;
    }


    public void OnExitButtonPressed()
    {
        // Hide the current ad and disable the entire ad canvas
        interstitialAds[adIndex].SetActive(false);
        adCanvas.gameObject.SetActive(false);
        adIndex = (adIndex + 1) % interstitialAds.Length;
        menus.GameOverActive();
    }

    /*    private void Update()
        {
            if (GameManager.Instance.gameOver && !isAdActive)
            {
                //StartCoroutine(nameof(ShowNextAd));
                ShowNextAd();
            }
        }

        private async void ShowNextAd()
        {
            isAdActive = true;
            HideAllAds();
            interstitialAds[adIndex].SetActive(true);
            //yield return new WaitForSeconds(2f);
            await Task.Delay(TimeSpan.FromSeconds(2));
            adCanvas.SetActive(true);
        }*/
    private void HideAllAds()
    {
        foreach (GameObject ad in interstitialAds)
        {
            ad.SetActive(false);
        }
    }
}
