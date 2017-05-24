using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace CompleteProject
{

    public class moveryatacar : NetworkBehaviour
    {
        public float shootDistance = 4f;
        /*public PlayerShooting shootingScript;*/
        [SerializeField]
        private Transform targetedEnemy, bulletfire;

        public Animator anim;
        public UnityEngine.AI.NavMeshAgent navMeshAgent;
        private Ray shootRay;
        private RaycastHit shootHit;
        private bool walking, enemyClicked;
        private float nextFire, cooldowntimer, cooldown;
        vida vidaenemigo;
        bool daño;

        RaycastHit hit;

        // Use this for initialization
        void Awake()
        {
            anim = GetComponent<Animator>();

            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

            cooldowntimer = 1;
            cooldown = cooldowntimer;

        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetButtonDown("Fire2"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit, 10000))
                {

                    if (hit.collider.CompareTag("Enemy"))
                    {
                        targetedEnemy = hit.transform;
                        vidaenemigo = targetedEnemy.GetComponent<vida>();

                        enemyClicked = true;
                        Debug.Log("Enemigo clickado");
                    }
                    else
                    {
                        StopShooting();
                    }
                }
            }

            if (targetedEnemy != null)
            {
                if (vidaenemigo.getVida_total() <= 0)
                {
                    StopShooting();
                }
            }

            if (daño)
            {
                if (cooldown < 0)
                {
                    cooldown = cooldowntimer;
                    vidaenemigo.setVida_total(20);
                    
                }
                else
                {
                    cooldown -= Time.deltaTime;
                }
            }

            if (enemyClicked)
            {
                MoveAndShoot();

            }

            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                {
                    walking = false;
                    anim.SetInteger("estadoAnimacion", 0);
                }
            }
            else
            {
                walking = true;
            }
        }


        private void StopShooting()
        {

            anim.SetInteger("Disparar", 0);
            targetedEnemy = null;

            walking = true;
            anim.SetInteger("estadoAnimacion", 1);

            enemyClicked = false;
            //Debug.Log(hit.point);

            navMeshAgent.destination = hit.point;
            navMeshAgent.Resume();

            daño = false;

        }




        private void MoveAndShoot()
        {
            if (targetedEnemy == null)
            {
                daño = false;
                return;
            }

            navMeshAgent.destination = targetedEnemy.position;

            if (navMeshAgent.remainingDistance >= shootDistance)
            {
                daño = false;
                navMeshAgent.Resume();
                walking = true;
                anim.SetInteger("Disparar", 0);
                anim.SetInteger("estadoAnimacion", 1);

            }

            if ((navMeshAgent.remainingDistance + 6) < shootDistance)
            {
                anim.SetInteger("estadoAnimacion", 0);

                anim.SetInteger("Disparar", 1);
                daño = true;

                transform.LookAt(targetedEnemy);
                Vector3 dirToShoot = targetedEnemy.transform.position - transform.position;

                navMeshAgent.Stop();
                walking = false;
            }
        }

        public void bulletsmoke() {

            Instantiate(bulletfire, gameObject.transform.position, gameObject.transform.rotation)

        }

    }

}
