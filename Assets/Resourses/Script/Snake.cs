using UnityEngine;

namespace Script
{
    public class Snake : MonoBehaviour
    {

        public GameObject prefabBody;
        //public GameController GC;

        public float vertical;
        public float horizontal;
        float speed = 2;

        float screenWidth = 0;
        float screenHiegth = 0;

        bool is_eaten = false;

        int HeadMovementRot = 0;
        // Start is called before the first frame update
        void Start()
        {
            screenHiegth = 30;
            screenWidth = (Screen.width / (Screen.height / screenHiegth)) - 1.7f;
            Move();
            Time.timeScale = 1;
           // GC.GameReload();

        }

        float timer = 1;
        void Update()
        {
            if (timer * speed > 1)
            {
                Move();
                timer = 0;
            }
            timer += Time.deltaTime;
        

        }


        void Move()
        {

            HeadMovement h = GetComponentInChildren<HeadMovement>();

            if (HeadMovementRot == 0 && h.transform.position.x + 3.4f < screenWidth)
            {



                Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);


                h.transform.position = new Vector3(h.transform.position.x + 3.4f,
                                                    h.transform.position.y,
                                                    h.transform.position.z);



                MoveBody();


            }

            if (HeadMovementRot == 90 && h.transform.position.y + 3.4f < screenHiegth)
            {



                Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);


                h.transform.position = new Vector3(h.transform.position.x,
                                                    h.transform.position.y + 3.4f,
                                                    h.transform.position.z);


                MoveBody();


            }

            if (HeadMovementRot == 180 && h.transform.position.x - 3.4f > -screenHiegth)
            {



                Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);


                h.transform.position = new Vector3(h.transform.position.x - 3.4f,
                                                    h.transform.position.y,
                                                    h.transform.position.z);


                MoveBody();


            }
            if (HeadMovementRot == 270 && h.transform.position.y - 3.4f > -screenHiegth)
            {



                Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);


                h.transform.position = new Vector3(h.transform.position.x,
                                                    h.transform.position.y - 3.4f,
                                                    h.transform.position.z);


                MoveBody();


            }
             vertical = Input.GetAxis("Vertical");
             horizontal = Input.GetAxis("Horizontal");
            if (vertical > 0)
            {
                Up();
            }
            else if (vertical < 0)
            {
                Down();
            }
            else if (horizontal > 0)
            {
                Right();

            }
            else if (horizontal < 0)
            {
                Left();
            }
        }

        public void Reload()
        {
            HeadMovementRot = 0;
            HeadMovement h = GetComponentInChildren<HeadMovement>();
            h.transform.position = new Vector3(3.4f, 0, 0);
            h.transform.rotation = Quaternion.Euler(0, 0, 0);

            //TailMovement t = GetComponentInChildren<TailMovement>();
            //t.transform.position = new Vector3(-6.8f, 0, 0);
            //t.transform.rotation = Quaternion.Euler(0, 0, 0);

            var bb = GetComponentsInChildren<BodyMovement>();

            foreach (var b in bb)
            {
                Destroy(b.gameObject);
            }

            Instantiate(prefabBody, new Vector3(-3.4f, 0, 0), Quaternion.identity, transform);
            Instantiate(prefabBody, new Vector3(0, 0, 0), Quaternion.identity, transform);
        }

        public void Eat()
        {
            is_eaten = true;
            timer += 0.5f;
        }

        void MoveBody()
        {

            if (!is_eaten)
            {

                BodyMovement[] bb = GetComponentsInChildren<BodyMovement>();

                //TailMovement t = GetComponentInChildren<TailMovement>();

                //t.transform.rotation = bb[1].transform.rotation;
              //  t.transform.position = bb[0].transform.position;

                Destroy(bb[0].gameObject);
            }
            else
                is_eaten = false;

        }



        public void Right()
        {
            timer = 0;

            if (HeadMovementRot == 90 || HeadMovementRot == 270)
            {


                HeadMovement h = GetComponentInChildren<HeadMovement>();

               // h.transform.rotation = Quaternion.Euler(0, 0, 0);



                //if (HeadMovementRot == 90)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);
                //if (HeadMovementRot == 270)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);

                HeadMovementRot = 0;

              //  h.transform.position = new Vector3(h.transform.position.x + 3.4f,
                                                    //h.transform.position.y,
                                                    //h.transform.position.z);

                MoveBody();


            }

        }
        public void Left()
        {
            timer = 0;
            if (HeadMovementRot == 90 || HeadMovementRot == 270)
            {

                HeadMovement h = GetComponentInChildren<HeadMovement>();

               // h.transform.rotation = Quaternion.Euler(0, 0, 180);

                //if (HeadMovementRot == 270)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);
                //if (HeadMovementRot == 90)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);

                HeadMovementRot = 180;

               /// h.transform.position = new Vector3(h.transform.position.x - 3.4f,
                                                    //h.transform.position.y,
                                                    //h.transform.position.z);

                MoveBody();
            }

        }
        public void Up()
        {
            timer = 0;
            if (HeadMovementRot == 0 || HeadMovementRot == 180)
            {

                HeadMovement h = GetComponentInChildren<HeadMovement>();

               // h.transform.rotation = Quaternion.Euler(0, 0, 90);



                //if (HeadMovementRot == 180)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);
                //if (HeadMovementRot == 0)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);

                HeadMovementRot = 90;

               // h.transform.position = new Vector3(h.transform.position.x,
                                                    //h.transform.position.y + 3.4f,
                                                    //h.transform.position.z);

                MoveBody();


            }
        }
        public void Down()
        {
            timer = 0;
            if (HeadMovementRot == 0 || HeadMovementRot == 180)
            {

                HeadMovement h = GetComponentInChildren<HeadMovement>();

                //h.transform.rotation = Quaternion.Euler(0, 0, 270);



                //if (HeadMovementRot == 0)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);
                //if (HeadMovementRot == 180)
                //    Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, HeadMovementRot), transform);

                HeadMovementRot = 270;

              //  h.transform.position = new Vector3(h.transform.position.x,
                                                    //h.transform.position.y - 3.4f,
                                                    //h.transform.position.z);

                MoveBody();


            }

        }

    }
}