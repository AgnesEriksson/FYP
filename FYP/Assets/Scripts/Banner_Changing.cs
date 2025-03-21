using System.Collections;
using UnityEngine;

public class Banner_Changing : MonoBehaviour
{
    [SerializeField] private GameObject[] banners;
    [SerializeField] private float displayTime = 5f;

    private int index = 0;
    private GameObject[] shuffledArray;

    private void Start()
    {
        shuffledArray = (GameObject[])banners.Clone();
        ShuffleArray();
        StartCoroutine(SpawnCycle());
    }

    private IEnumerator SpawnCycle()
    {
        while (true)
        {
            shuffledArray[index].SetActive(true);
            yield return new WaitForSeconds(displayTime);
            shuffledArray[index].SetActive(false);

            index++;
            if (index >= shuffledArray.Length)
            {
                index = 0;
                ShuffleArray();
            }
        }
    }

    private void ShuffleArray()
    {
        for (int i = shuffledArray.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (shuffledArray[i], shuffledArray[randomIndex]) = (shuffledArray[randomIndex], shuffledArray[i]);
        }
    }
}

