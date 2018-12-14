using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBeerController : MonoBehaviour 
{

    [SerializeField] private GameObject beerVisualisation; //gameobject ref
    [SerializeField] private Rigidbody beerProjectile; //prefab

    [SerializeField] private Transform throwOrigin;

    [SerializeField] private float throwForce = 10f;

    [SerializeField] private AudioSource throwAudioSource;

    private bool canThrow = true;

    private void Update()
    {
        if(canThrow && Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }

    private void Throw()
    {
        GameObject spawnedPrefab = Instantiate(beerProjectile.gameObject, throwOrigin.position, throwOrigin.rotation);

        spawnedPrefab.GetComponent<Rigidbody>().AddForce( transform.forward * throwForce, ForceMode.Impulse);
        Destroy(spawnedPrefab, 3f);

        throwAudioSource.Play();

        StartCoroutine(MugReload());
    }

    private IEnumerator MugReload(){
        canThrow = false;
        beerVisualisation.SetActive(false);

        yield return new WaitForSeconds(2f);

        beerVisualisation.SetActive(true);
        canThrow = true;

    }



}
