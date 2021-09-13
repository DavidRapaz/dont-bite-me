using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Weapon Options")]
    public float damage           = 10f;
    public float range            = 100f;
    public int maxMagazineBullets = 10;

    [Header("FPS Camera")]
    public Camera fpsCam;

    [Header("UI Elements")]
    public Image crosshairUI;
    public GameObject reloadUI;

    private int _magazine;

    void Start()
    {
        _magazine = maxMagazineBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _magazine != 0)
            Shoot();

        if (Input.GetButtonDown("Reload"))
            Reload();
    }

    void Shoot ()
    {
        RaycastHit hit;

        _magazine -= 1;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            EnemyController enemy = hit.transform.GetComponentInParent<EnemyController>();

            if (enemy != null)
                enemy.TakeDamage(hit.transform.tag, damage);
        }

        if (_magazine == 0)
        {
            reloadUI.SetActive(true);
            crosshairUI.gameObject.SetActive(false);
        }
    }

    void Reload ()
    {
        _magazine = maxMagazineBullets;

        crosshairUI.gameObject.SetActive(true);
        reloadUI.SetActive(false);
    }
}
