using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlerScript : MonoBehaviour
{
    public float velocidad;
    public int wantmovedirection,wasmove;// 1=T 2=D 3=L 4=R
    public float startcolddown, whenstart;
    public bool startgame;
    public bool down, top, left, right;
    public bool RL,TD,RT,RD,LT,LD,LTR,TRD,RDL,DLT,RTLD;
    public bool canmoveDown, canmoveTop, canmoveLeft, canmoveRight;
    private Animator Animator;
    

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

        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector3(-7.4f , transform.position.y, 0);
        }
        if (transform.position.x < -7.5f)
        {
            transform.position = new Vector3(7.4f, transform.position.y, 0);
        }
        startcolddown += Time.deltaTime;

        if (startcolddown > whenstart)
        {
            startgame = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) && top == true)
        {
            wantmovedirection = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) && down == true)
        {
            wantmovedirection = 2;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && left == true)
        {
            wantmovedirection = 3;
        }
        if (Input.GetKey(KeyCode.RightArrow) && right == true)
        {
            wantmovedirection = 4;
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



    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == ("RL")&& RL == false)
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
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Enemigo1") && GameController.instance.canEat == false)
        {
            SceneManager.LoadScene("lose");
        }
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
 
    public void Movimiento1()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + velocidad, 0);
        Animator.SetBool("gotop", true);
        Animator.SetBool("godown", false);
        Animator.SetBool("goleft",false);
        Animator.SetBool("goright", false);
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
