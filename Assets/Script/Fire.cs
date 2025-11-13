using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] int damage = 5;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer backImage;
    bool InRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Idamageable idamageable))
        {
            InRange = true;
            StartCoroutine(dealdDamage(idamageable));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InRange = false;
    }

    IEnumerator dealdDamage(Idamageable idamageable)
    {
        if(InRange == true)
        {
            idamageable.GetDamage(damage);
            backImage.sprite = sprites[Random.Range(0, sprites.Length)];
            backImage.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);

            backImage.gameObject.SetActive(false);

            yield return new WaitForSeconds(.5f);

            StartCoroutine(dealdDamage(idamageable));
        } 
    }
}
