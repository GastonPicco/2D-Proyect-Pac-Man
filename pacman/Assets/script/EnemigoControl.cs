using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControl : MonoBehaviour
{
    public float velocidad;
    public int wantmovedirection, wasmove;// 1=T 2=D 3=L 4=R
    public float startcolddown, whenstart;
    public bool startgame;
    public bool down, top, left, right;
    public bool RL, TD, RT, RD, LT, LD, LTR, TRD, RDL, DLT, RTLD;
    public bool canmoveDown, canmoveTop, canmoveLeft, canmoveRight;
    private Animator Animator;
    public GameObject Player;
    public float rand,rand2;
    public float timer,timer2,timer3;
    public float Atdi;
    public bool AtdiB,moved,colconfirm;
    public int prioridad, contadorcol;
    public float colddown, timeinbox;
    

    void Start()
    {
        
        Animator = GetComponent<Animator>();
        wantmovedirection = 4;
        startgame = false;
        whenstart = 4;
        RL = true;
        canmoveDown = true;
        canmoveLeft = true;
        canmoveRight = true;
        canmoveTop = true;
        AtdiB = false;
        colconfirm = false;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {


       
        if (wantmovedirection == 1 && canmoveTop)
        {
            Movimiento1();
        }
        if (wantmovedirection == 2 && canmoveDown)
        {
            Movimiento2();
        }
        if (wantmovedirection == 3 && canmoveLeft)
        {
            Movimiento3();
        }
        if (wantmovedirection == 4 && canmoveRight)
        {
            Movimiento4();
        }

    }
    void Update()
    {
        
        if(GameController.instance.canEat == true)
        {
            Animator.SetBool("azul", true);
        }
        else
        {
            Animator.SetBool("azul", false);
        }
        if (contadorcol > 80)
        {
            colconfirm = false;
        }
        if (moved)
        {
            timer3 += Time.deltaTime;
            if(timer3 > 0.6)
            {
                timer3 = 0;
                moved = false;
            }
        }
        colddown += Time.deltaTime;
        
        float randx = Random.Range(-2f, 2f);
        timer += Time.deltaTime;
        if(timer > 3.5f && !RDL && !DLT && !LTR && !TRD)
        {
            rand = randx;
            timer = 0;
        }
        startcolddown += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer2 > 0.1f)
        {
            rand2 = randx;
            timer2 = 0;
        }

        Vector3 direction = Player.transform.position - transform.position;
        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector3(-7.4f, transform.position.y, 0);
        }
        if (transform.position.x < -7.5f)
        {
            transform.position = new Vector3(7.4f, transform.position.y, 0);
        }
        if (direction.x < Atdi && direction.y < Atdi)
        {
            AtdiB = true;
        }
        else
        {
            AtdiB = false;
        }
        //████████████████████████████████████████████RT█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RT) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RT) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RT) && right == true)
            {
                wantmovedirection = 4;
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RT) && right == true)
            {
                wantmovedirection = 4;
            }
        }

        //████████████████████████████████████████████RD█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RD) && right == true)
            {
                wantmovedirection = 4;
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RD) && down == true)
            {
                wantmovedirection = 2;
            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RD) && right == true)
            {
                wantmovedirection = 4;
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RD) && down == true)
            {
                wantmovedirection = 2;
            }
        }

        //████████████████████████████████████████████LD█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && LD) && left == true)
            {
                wantmovedirection = 3;
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && LD) && left == true)
            {
                wantmovedirection = 3;
            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && LD) && down == true)
            {
                wantmovedirection = 2;
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && LD) && down == true)
            {
                wantmovedirection = 2;
            }
        }

        //████████████████████████████████████████████LT█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && LT) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && LT) && left == true)
            {
                wantmovedirection = 3;
            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && LT) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && LT) && left == true)
            {
                wantmovedirection = 3;
            }
        }

        //████████████████████████████████████████████TRD█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && TRD) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && TRD) && top == true && down == true && !TD)
            {
                if (rand < 0)
                {
                    wantmovedirection = 1;
                }
                if (rand >= 0)
                {
                    wantmovedirection = 2;
                }

            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && TRD) && right == true)
            {
                wantmovedirection = 4;
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && TRD) && down == true)
            {
                wantmovedirection = 2;
            }
        }

        //████████████████████████████████████████████RDL█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RDL) && right == true && left == true)
            {
                if (rand > 0)
                {
                    wantmovedirection = 3;
                }
                if (rand <= 0)
                {
                    wantmovedirection = 4;
                }
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RDL) && left == true)
            {
                wantmovedirection = 3;
            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RDL) && right == true)
            {
                wantmovedirection = 4;
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RDL) && down == true)
            {
                wantmovedirection = 2;
            }
        }

        //████████████████████████████████████████████DLT█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && DLT) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && DLT) && left == true)
            {
                wantmovedirection = 3;
            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && DLT) && top == true && down == true)
            {
                if (rand < 0)
                {
                    wantmovedirection = 1;
                }
                if (rand >= 0)
                {
                    wantmovedirection = 2;
                }
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && DLT) && down == true)
            {
                wantmovedirection = 2;
            }
        }
        
        //████████████████████████████████████████████LTR█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && LTR) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && LTR) && left == true)
            {
                wantmovedirection = 3;
            }
            if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && LTR) && right == true)
            {
                wantmovedirection = 4;
            }
            if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && LTR) && right == true && left == true && !RL)
            {
                if (direction.x < 0)
                {
                    if (rand < 0)
                    {
                        wantmovedirection = 3;
                    }
                    if (rand >= 0)
                    {
                        wantmovedirection = 4;
                    }
                }
                else
                {
                    if (rand > 0)
                    {
                        wantmovedirection = 3;
                    }
                    if (rand <= 0)
                    {
                        wantmovedirection = 4;
                    }
                }
            }
        }

        //████████████████████████████████████████████RTLD█████████████████████████████████████████████████
        if (AtdiB)
        {
            if ((direction.y > 0 && direction.x > -0.5f && direction.x < 0.5f && RTLD) && top == true)
            {
                wantmovedirection = 1;
            }
            else if ((direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RTLD) && top == true)
            {
                wantmovedirection = 1;
            }
            if ((direction.x < 0 && direction.y > -0.5f && direction.y < 0.5f && RTLD) && left == true)
            {
                wantmovedirection = 3;
            }
            else if ((direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RTLD) && left == true)
            {
                wantmovedirection = 3;
            }
            if ((direction.x > 0 && direction.y > -0.5f && direction.y < 0.5f && RTLD) && right == true)
            {
                wantmovedirection = 4;
            }
            else if ((direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && RTLD) && right == true)
            {
                wantmovedirection = 4;
            }
            if ((direction.y < 0 && direction.x > -0.5f && direction.x < 0.5f && RTLD) && down == true)
            {
                wantmovedirection = 2;
            }
            else if ((direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && RTLD) && down == true)
            {
                wantmovedirection = 2;
            }
        }
        //████████████████████████████████████████████RAND█████████████████████████████████████████████████
        


        if (!RL && !TD && !RT && !RD && !LT && !LD && LTR && !TRD && !RDL && !DLT && !RTLD && !AtdiB && !moved)//LTR
        {
            moved = true;
            if (wantmovedirection == 2 )
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 4;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }
            if (wantmovedirection == 3)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 3;
                }
            }
            if (wantmovedirection == 4)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 4;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }

        }



        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && RDL && !DLT && !RTLD && !AtdiB && !moved)//RDL
        {
            moved = true;
            if (wantmovedirection == 1)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 4;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }
            if (wantmovedirection == 3)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 3;
                }
            }
            if (wantmovedirection == 4)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 3;
                }
            }

        }

   
        
        if (!RL && !TD && !RT && RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD && !AtdiB) //RD
        {
            moved = true;
            if (rand2 < -1)
            {
                wantmovedirection = 2;
            }
            if (rand2 < 0 && rand2 >= -1)
            {
                wantmovedirection = 2;
            }
            if (rand2 > 0 && rand2 <= 1)
            {
                wantmovedirection = 4;
            }
            if (rand2 > 1)
            {
                wantmovedirection = 4;
            }
        }
        
        
        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && DLT && !RTLD && !AtdiB && !moved)//DLT
        {
            moved = true;
            if (wantmovedirection == 2)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 3;
                }
            }
            if (wantmovedirection == 1)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 3;
                }
            }
            if (wantmovedirection == 4)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 1;
                }
            }

        }
        
        
        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && RTLD && !AtdiB && !moved)// RTLD
        {
            moved = true;
            if (wantmovedirection == 1)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }
            if (wantmovedirection == 2)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }
            if (wantmovedirection == 3)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 3;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 3;
                }
            }
            if (wantmovedirection == 4)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 4;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }

        }
        
        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && TRD && !RDL && !DLT && !RTLD && !AtdiB && !moved) //TRD
        {
            moved = true;
            if (wantmovedirection == 1)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 4;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }
            if (wantmovedirection == 2)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 4;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 4;
                }
            }
            if (wantmovedirection == 3)
            {
                if (rand2 < -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 < 0 && rand2 >= -1)
                {
                    wantmovedirection = 1;
                }
                if (rand2 > 0 && rand2 <= 1)
                {
                    wantmovedirection = 2;
                }
                if (rand2 > 1)
                {
                    wantmovedirection = 2;
                }
            }

        }
        
        if (!RL && !TD && !RT && !RD && !LT && LD && !LTR && !TRD && !RDL && !DLT && !RTLD && !AtdiB)//LD
        {
            moved = true;
            if (rand2 < -1)
            {
                wantmovedirection = 2;
            }
            if (rand2 < 0 && rand2 >= -1)
            {
                wantmovedirection = 2;
            }
            if (rand2 > 0 && rand2 <= 1)
            {
                wantmovedirection = 3;
            }
            if (rand2 > 1)
            {
                wantmovedirection = 3;
            }
        }
        
        if (!RL && !TD && !RT && !RD && LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD && !AtdiB)//LT
        {
            moved = true;
            if (rand2 < -1)
            {
                wantmovedirection = 1;
            }
            if (rand2 < 0 && rand2 >= -1)
            {
                wantmovedirection = 1;
            }
            if (rand2 > 0 && rand2 <= 1)
            {
                wantmovedirection = 3;
            }
            if (rand2 > 1)
            {
                wantmovedirection = 3;
            }
        }
        
        if (!RL && !TD && RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD && !AtdiB)//RT 
        {
            moved = true;
            if (rand2 < -1)
            {
                wantmovedirection = 1;
            }
            if (rand2 < 0 && rand2 >= -1)
            {
                wantmovedirection = 1;
            }
            if (rand2 > 0 && rand2 <= 1)
            {
                wantmovedirection = 4;
            }
            if (rand2 > 1)
            {
                wantmovedirection = 4;
            }
        }
        
        //████████████████████████████████████████████RAND█████████████████████████████████████████████████

        if (startcolddown > whenstart)
        {
            startgame = true;
        }

        if (RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD) //RL
        {
            top = false;
            down = false;
            left = true;
            right = true;

        }
        if (!RL && TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD) // TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
        }
        if (RL && !TD && !RT && !RD && !LT && !LD && LTR && !TRD && !RDL && !DLT && !RTLD) // LTR RL
        {
            top = false;
            down = false;
            left = true;
            right = true;
            if (wantmovedirection == 2)
            {
                canmoveDown = false;
                Movimiento20();
            }
            if (wantmovedirection == 1)
            {
                canmoveDown = true;
            }
        }
        if (!RL && !TD && !RT && !RD && !LT && !LD && LTR && !TRD && !RDL && !DLT && !RTLD)//LTR
        {
            top = true;
            down = false;
            left = true;
            right = true;
            if (wantmovedirection == 2)
            {
                canmoveDown = false;
                Movimiento20();
            }
            if (wantmovedirection == 1)
            {
                canmoveDown = true;
            }
        }

        if (!RL && TD && !RT && !RD && !LT && !LD && LTR && !TRD && !RDL && !DLT && !RTLD) //LTR TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
        }
        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && RDL && !DLT && !RTLD)//RDL
        {
            top = false;
            down = true;
            left = true;
            right = true;
            if (wantmovedirection == 1)
            {
                canmoveTop = false;
                Movimiento10();
            }
            if (wantmovedirection == 2)
            {
                canmoveTop = true;
            }
        }
        if (!RL && TD && !RT && !RD && !LT && !LD && !LTR && !TRD && RDL && !DLT && !RTLD) // RDL TD
        {
            top = true;
            down = true;
            left = false;
            right = false;

        }
        if (RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && RDL && !DLT && !RTLD) // RDL RL
        {
            top = false;
            down = false;
            left = true;
            right = true;
            if (wantmovedirection == 1)
            {
                canmoveTop = false;
                Movimiento10();
            }
            if (wantmovedirection == 2)
            {
                canmoveTop = true;
            }
        }
        if (!RL && !TD && !RT && RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD) //RD
        {
            top = false;
            down = true;
            left = false;
            right = true;
            if (wantmovedirection == 1)
            {
                canmoveTop = false;
                Movimiento10();
            }
            if (wantmovedirection == 2)
            {
                canmoveTop = true;
            }
            if (wantmovedirection == 3)
            {
                canmoveLeft = false;
                Movimiento30();
            }
            if (wantmovedirection == 4)
            {
                canmoveLeft = true;
            }
        }
        if (!RL && TD && !RT && RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD) //RD TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
            if (wantmovedirection == 3)
            {
                canmoveLeft = false;
                Movimiento30();
            }
            if (wantmovedirection == 4)
            {
                canmoveLeft = true;
            }
        }
        if (RL && !TD && !RT && RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD) //RD RL
        {
            top = false;
            down = false;
            left = true;
            right = true;
            if (wantmovedirection == 1)
            {
                canmoveTop = false;
                Movimiento10();
            }
            if (wantmovedirection == 2)
            {
                canmoveTop = true;
            }
        }
        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && DLT && !RTLD)//DLT
        {
            top = true;
            down = true;
            left = true;
            right = false;
            if (wantmovedirection == 4)
            {
                canmoveRight = false;
                Movimiento40();
            }
            if (wantmovedirection == 3)
            {
                canmoveRight = true;
            }
        }
        if (!RL && TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && DLT && !RTLD)// DLT TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
            if (wantmovedirection == 4)
            {
                canmoveRight = false;
                Movimiento40();
            }
            if (wantmovedirection == 3)
            {
                canmoveRight = true;
            }
        }
        if (RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && DLT && !RTLD)// DLT RL
        {
            top = false;
            down = false;
            left = true;
            right = true;

        }
        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && RTLD)// RTLD
        {
            top = true;
            down = true;
            left = true;
            right = true;
        }
        if (!RL && TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && RTLD)// RTLD TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
        }
        if (RL && !TD && !RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && RTLD)// RTLD RL
        {
            top = false;
            down = false;
            left = true;
            right = true;
        }
        if (!RL && !TD && !RT && !RD && !LT && !LD && !LTR && TRD && !RDL && !DLT && !RTLD) //TRD
        {
            top = true;
            down = true;
            left = false;
            right = true;
            if (wantmovedirection == 3)
            {
                canmoveLeft = false;
                Movimiento30();
            }
            if (wantmovedirection == 4)
            {
                canmoveLeft = true;
            }
        }
        if (!RL && TD && !RT && !RD && !LT && !LD && !LTR && TRD && !RDL && !DLT && !RTLD) //TRD TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
            if (wantmovedirection == 3)
            {
                canmoveLeft = false;
                Movimiento30();
            }
            if (wantmovedirection == 4)
            {
                canmoveLeft = true;
            }
        }
        if (RL && !TD && !RT && !RD && !LT && !LD && !LTR && TRD && !RDL && !DLT && !RTLD) //TRD RL
        {
            top = false;
            down = false;
            left = true;
            right = true;

        }
        if (!RL && !TD && !RT && !RD && !LT && LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//LD
        {
            top = false;
            down = true;
            left = true;
            right = false;
            if (wantmovedirection == 1)
            {
                canmoveTop = false;
                Movimiento10();
            }
            if (wantmovedirection == 2)
            {
                canmoveTop = true;
            }
            if (wantmovedirection == 4)
            {
                canmoveRight = false;
                Movimiento40();
            }
            if (wantmovedirection == 3)
            {
                canmoveRight = true;
            }

        }
        if (!RL && TD && !RT && !RD && !LT && LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//LD TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
            if (wantmovedirection == 4)
            {
                canmoveRight = false;
                Movimiento40();
            }
            if (wantmovedirection == 3)
            {
                canmoveRight = true;
            }
        }
        if (RL && !TD && !RT && !RD && !LT && LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//LD RL
        {
            top = false;
            down = false;
            left = true;
            right = true;
            if (wantmovedirection == 1)
            {
                canmoveTop = false;
                Movimiento10();
            }
            if (wantmovedirection == 2)
            {
                canmoveTop = true;
            }
        }
        if (!RL && !TD && !RT && !RD && LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//LT
        {
            top = true;
            down = false;
            left = true;
            right = false;
            if (wantmovedirection == 2)
            {
                canmoveDown = false;
                Movimiento20();
            }
            if (wantmovedirection == 1)
            {
                canmoveDown = true;
            }
            if (wantmovedirection == 4)
            {
                canmoveRight = false;
                Movimiento40();
            }
            if (wantmovedirection == 3)
            {
                canmoveRight = true;
            }
        }
        if (!RL && TD && !RT && !RD && LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD)// LT TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
            if (wantmovedirection == 4)
            {
                canmoveRight = false;
                Movimiento40();
            }
            if (wantmovedirection == 3)
            {
                canmoveRight = true;
            }
        }
        if (RL && !TD && !RT && !RD && LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//LT RL
        {
            top = false;
            down = false;
            left = true;
            right = true;
            if (wantmovedirection == 2)
            {
                canmoveDown = false;
                Movimiento20();
            }
            if (wantmovedirection == 1)
            {
                canmoveDown = true;
            }
        }
        if (!RL && !TD && RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//RT 
        {
            top = true;
            down = false;
            left = false;
            right = true;
            if (wantmovedirection == 2)
            {
                canmoveDown = false;
                Movimiento20();
            }
            if (wantmovedirection == 1)
            {
                canmoveDown = true;
            }
            if (wantmovedirection == 3)
            {
                canmoveLeft = false;
                Movimiento30();
            }
            if (wantmovedirection == 4)
            {
                canmoveLeft = true;
            }
        }
        if (!RL && TD && RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//RT TD
        {
            top = true;
            down = true;
            left = false;
            right = false;
            if (wantmovedirection == 3)
            {
                canmoveLeft = false;
                Movimiento30();
            }
            if (wantmovedirection == 4)
            {
                canmoveLeft = true;
            }
        }
        if (RL && !TD && RT && !RD && !LT && !LD && !LTR && !TRD && !RDL && !DLT && !RTLD)//RT RL
        {
            top = false;
            down = false;
            left = true;
            right = true;
            if (wantmovedirection == 2)
            {
                canmoveDown = false;
                Movimiento20();
            }
            if (wantmovedirection == 1)
            {
                canmoveDown = true;
            }
        }
        if (transform.position.x > -1.25f && transform.position.x < 1.25f && transform.position.y > -3 && transform.position.y < -1.30)
        {
            wantmovedirection = 20;
            Animator.SetBool("azul", false);
            timeinbox += Time.deltaTime;
            if(timeinbox > 8)
            {
                GoOutBox();
            }
        }


    }
    public void GoOutBox()
    {
        wantmovedirection = 4;
        timeinbox = 0;
        transform.position = new Vector3(0f,-0.3f,0f);
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == ("RL") && RL == false)
        {
            RL = true;
        }
        if (col.tag == ("TD") && TD == false)
        {
            TD = true;
        }
        if (col.tag == ("RT") && RT == false)
        {
            RT = true;
        }
        if (col.tag == ("RD") && RD == false)
        {
            RD = true;
        }
        if (col.tag == ("LTR") && LTR == false)
        {
            LTR = true;

        }
        if (col.tag == ("TRD") && TRD == false)
        {
            TRD = true;
        }
        if (col.tag == ("RDL") && RDL == false)
        {
            RDL = true;
        }
        if (col.tag == ("DLT") && DLT == false)
        {
            DLT = true;
        }
        if (col.tag == ("RTLD") && RTLD == false)
        {
            RTLD = true;
        }
        if (col.tag == ("LD") && LD == false)
        {
            LD = true;
        }
        if (col.tag == ("LT") && LT == false)
        {
            LT = true;
        }


    }
    public void OnTriggerEnter2D(Collider2D col)
    {

    }

    public void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == ("RL"))
        {
            RL = false;
        }
        if (col.tag == ("TD"))
        {
            TD = false;
        }
        if (col.tag == ("RT"))
        {
            RT = false;
            canmoveLeft = true;
            canmoveDown = true;
        }
        if (col.tag == ("RD"))
        {
            RD = false;
            canmoveLeft = true;
            canmoveTop = true;
        }
        if (col.tag == ("LTR"))
        {
            LTR = false;
            canmoveDown = true;
        }
        if (col.tag == ("TRD"))
        {
            TRD = false;
            canmoveLeft = true;
        }
        if (col.tag == ("RDL"))
        {
            RDL = false;
            canmoveTop = true;

        }
        if (col.tag == ("DLT"))
        {
            DLT = false;
            canmoveRight = true;
        }
        if (col.tag == ("RTLD"))
        {
            RTLD = false;

        }
        if (col.tag == ("LD"))
        {
            LD = false;
            canmoveRight = true;
            canmoveTop = true;
        }
        if (col.tag == ("LT"))
        {
            LT = false;
            canmoveRight = true;
            canmoveDown = true;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Player") && GameController.instance.canEat == true)
        {
            Debug.Log("come");
            transform.position = new Vector3(0f, -2.6f, 0f);
            GameController.instance.SumarPuntos2(200);
        }
        if (prioridad == 1)
        {
            if (col.gameObject.tag == ("Enemigo1"))
            {
                if (wantmovedirection == 1 && !colconfirm && canmoveDown && colddown > 0.5f)
                {
                    Debug.Log(wantmovedirection);
                    wantmovedirection = 2;
                    colconfirm = true;
                    colddown = 0;
                }
                if (wantmovedirection == 2 && !colconfirm && canmoveTop && colddown > 0.5f)
                {
                    Debug.Log(wantmovedirection);
                    wantmovedirection = 1;
                    colconfirm = true;
                    colddown = 0;
                }
                if (wantmovedirection == 3 && !colconfirm && canmoveRight && colddown > 0.5f)
                {
                    Debug.Log(wantmovedirection);
                    wantmovedirection = 4;
                    colconfirm = true;
                    colddown = 0;
                }
                if (wantmovedirection == 4 && !colconfirm && canmoveLeft && colddown > 0.5f)
                {
                    Debug.Log(wantmovedirection);
                    wantmovedirection = 3;
                    colconfirm = true;
                    colddown = 0;
                }


            }
            if (col.gameObject.tag == ("Enemigo1") && colddown > 0.5f)
            {
                contadorcol = contadorcol + Random.Range(1,20);
                colddown = 0;
            }

        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Enemigo1"))
        {
            colconfirm = false;
        }
    }
    public void Movimiento1()
    {
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + velocidad, 0);
            Animator.SetBool("gotop", true);
            Animator.SetBool("godown", false);
            Animator.SetBool("goleft", false);
            Animator.SetBool("goright", false);
        }  
    }
    public void Movimiento2()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - velocidad, 0);
        Animator.SetBool("gotop", false);
        Animator.SetBool("godown", true);
        Animator.SetBool("goleft", false);
        Animator.SetBool("goright", false);
    }
    public void Movimiento3()
    {
        transform.position = new Vector3(transform.position.x - velocidad, transform.position.y, 0);
        Animator.SetBool("gotop", false);
        Animator.SetBool("godown", false);
        Animator.SetBool("goleft", true);
        Animator.SetBool("goright", false);
    }
    public void Movimiento4()
    {
        transform.position = new Vector3(transform.position.x + velocidad, transform.position.y, 0);
        Animator.SetBool("gotop", false);
        Animator.SetBool("godown", false);
        Animator.SetBool("goleft", false);
        Animator.SetBool("goright", true);
    }
    public void Movimiento10()
    {
        Animator.SetBool("gotop", true);
        Animator.SetBool("godown", false);
        Animator.SetBool("goleft", false);
        Animator.SetBool("goright", false);
    }
    public void Movimiento20()
    {
        Animator.SetBool("gotop", false);
        Animator.SetBool("godown", true);
        Animator.SetBool("goleft", false);
        Animator.SetBool("goright", false);
    }
    public void Movimiento30()
    {
        Animator.SetBool("gotop", false);
        Animator.SetBool("godown", false);
        Animator.SetBool("goleft", true);
        Animator.SetBool("goright", false);
    }
    public void Movimiento40()
    {
        Animator.SetBool("gotop", false);
        Animator.SetBool("godown", false);
        Animator.SetBool("goleft", false);
        Animator.SetBool("goright", true);
    }


}

