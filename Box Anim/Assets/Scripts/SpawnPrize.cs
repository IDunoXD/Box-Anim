using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrize : MonoBehaviour
{
    int PrizesCount;
    bool Spawn = true, Despawn = true;
    public GameObject Prizes;
    public Transform PrizePos;
    [SerializeField]
    Animator BoxAnimator;
    Transform pr;
    void Start(){
        PrizesCount = Prizes.transform.childCount;
    }
    void Update()
    {
        if(Spawn && BoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("BoxOpen2")){ //spawn random prize at animation
            var Prize = GameObject.Instantiate(Prizes.transform.GetChild(Random.Range(0,PrizesCount)),transform);
            pr=Prize;
            Prize.GetComponent<PrizeAnimation>().enabled=true;
            Prize.GetComponent<PrizeAnimation>().MoveTo=PrizePos;
            Spawn = false;
        }
        if(BoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("Tap") && BoxAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime>0.7f && Despawn){ //remove prize after pressin tap
            pr.gameObject.GetComponent<PrizeAnimation>().GoBack=true;
            Despawn = false;
        }
    }
}
