using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Weapon Options")]
    public float damage           = 10f;
    public float range            = 100f;

    public int maxMagazineBullets = 10;

    [Header("Score Options")]
    public int pointsPerShot = 10;

    [Header("FPS Camera")]
    public Camera fpsCam;

    [Header("UI Elements")]
    public Image crosshairUI;

    public GameObject reloadUI;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI magazineUI;

    private int _magazine;
    private int _score;

    void Start()
    {
        _magazine       = maxMagazineBullets;
        _score          = 0;
        magazineUI.text = string.Format("{0} / {1}", _magazine, maxMagazineBullets);
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
        magazineUI.text = string.Format("{0} / {1}", _magazine, maxMagazineBullets);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            EnemyController enemy = hit.transform.GetComponentInParent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(hit.transform.tag, damage);
                DisplayScore(hit.transform.tag);
            }
        }

        if (_magazine == 0)
        {
            reloadUI.SetActive(true);
            crosshairUI.gameObject.SetActive(false);
        }
    }

    void Reload ()
    {
        _magazine       = maxMagazineBullets;
        magazineUI.text = string.Format("{0} / {1}", _magazine, maxMagazineBullets);

        crosshairUI.gameObject.SetActive(true);
        reloadUI.SetActive(false);
    }

    void DisplayScore (string tag)
    {
        _score += (tag == "Enemy Head" ? pointsPerShot * 2 : pointsPerShot);
        scoreUI.text = string.Format("{0}", _score);
    }
}
