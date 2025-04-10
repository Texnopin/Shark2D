using Luna.Unity.FacebookInstantGames;
using System.Collections;
using UnityEngine;

public class PartOne : MonoBehaviour
{
    [SerializeField] private GeneralControl Controller;
    [SerializeField] private ScreenOrientation screenOrientation;
    [SerializeField] private GameObject spear;

    [SerializeField] private Animator player;
    [SerializeField] private AudioSource playerAudio;

    [SerializeField] private SpriteRenderer Shark;
    [SerializeField] private Animator AnimationSharkBite;
    [SerializeField] private Animator tapToPlay;

    /*[SerializeField] private UnityEngine.Video.VideoPlayer videoShark;*/
    /*[SerializeField] private Animator MaterialvideoShark_animator;*/

    [SerializeField] private Animator success;

    [SerializeField] private Animator _tutorial;

    private bool nextPart = false;

    private void Start()
    {
        tapToPlay.gameObject.SetActive(true);
        tapToPlay.Play("Scale");
        /*MaterialvideoShark_animator = MaterialvideoShark_animator.GetComponent<Animator>();*/
        Invoke("Tutorial", 5f);
    }

    private void Update()
    {
        if (screenOrientation.isLandscape)
        {
            spear.transform.localPosition = new Vector3(4.39999962f, -1.74000001f, -1f);
        }
        else
        {
            spear.transform.localPosition = new Vector3(3.3499999f, -1.74000001f, -1f);
        }
    }

    public void Attack()
    {
        _tutorial.SetBool("TapAnim", false);
        _tutorial.gameObject.SetActive(false);
        tapToPlay.gameObject.SetActive(false);
        nextPart = true;
        player.Play("Attack");
        playerAudio.Play();
        SharkDied();
    }

    public void SharkDied()
    {
        /*videoShark.Stop();
        MaterialvideoShark_animator.Play("SharkDied");*/
        AnimationSharkBite.StopPlayback();
        AnimationSharkBite.Play("Transparament");
        Invoke("NextPart", 1f);
    }

    private void AutomaticComplitePart()
    {
        if(!nextPart)
            Attack();
    }


    private void NextPart()
    {
        /*videoShark.gameObject.SetActive(false);*/
        Shark.gameObject.SetActive(false);
        success.gameObject.SetActive(true);
        success.Play("Success");
        Invoke("Wait", 2f);
    }

    private void Wait() 
    {
        //_tutorial.gameObject.SetActive(false);
        _tutorial.SetBool("TapAnim", false);
        success.gameObject.SetActive(false);
        Controller.Complite(this.gameObject);
    }

    private void Tutorial()
    {
        if (!nextPart)
        {
            _tutorial.gameObject.SetActive(true);
            _tutorial.SetBool("TapAnim", true);
        }
    }

}
