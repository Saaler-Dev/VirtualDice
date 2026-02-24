using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{

    private Sprite[] diceSides;
    private SpriteRenderer rend;

    public int finalValue = 0;
    public bool isRolling = false;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        // IMPORTANTE: Tus imágenes deben estar en: Assets/Resources/DiceSides/
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    private void OnMouseDown()
    {
        if (!isRolling)
        {
            StartCoroutine(RollTheDice());
        }
    }

    private IEnumerator RollTheDice()
    {
        isRolling = true;
        int randomDiceSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, diceSides.Length);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        finalValue = randomDiceSide + 1;
        isRolling = false;

        Debug.Log("Salió un: " + finalValue);

    }
}