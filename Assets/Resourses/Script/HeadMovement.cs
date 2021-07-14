using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Script
{

    public class HeadMovement : MonoBehaviour
    {
        //public GameObject tempFruit, fruitPrefab, TailPrefab;
        //public List<Transform> tail = new List<Transform>();
        //Vector2 direction;
        //Rigidbody2D rb;
        //[SerializeField]
        //float speed = 1.0f;
        //float timer = 0;
        //// Start is called before the first frame update
        //void Start()
        //{
        //    tempFruit = Instantiate(fruitPrefab, new Vector2(Random.Range(-9, 10) + 0.5f, Random.Range(-3, 4) + 0.5f), Quaternion.identity);
        //    //    rb = GetComponent<Rigidbody2D>();
        //    // rb.velocity = transform.up * speed;

        //   // InvokeRepeating("Move", 0, 0.2f);
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    float vertical = Input.GetAxisRaw("Vertical");
        //    float horizontal = Input.GetAxisRaw("Horizontal");
        //    if (vertical == 0 && horizontal != 0 || vertical != 0 && horizontal == 0)
        //    {
        //        direction = new Vector2(horizontal, vertical);
        //    }
        //    if (timer< 0)
        //    {
        //        Move();
        //        timer = 1;
        //    }
        //    timer -= Time.deltaTime;
        //}
        //void Move()
        //{
        //    Vector2 lastPositoin = transform.position;
        //    transform.Translate(direction);

        //    if (!tempFruit)
        //    {
        //        tempFruit = Instantiate(fruitPrefab, new Vector2(Random.Range(-9, 10) + 0.5f, Random.Range(-3, 4) + 0.5f), Quaternion.identity);
        //        GameObject t = Instantiate(TailPrefab, lastPositoin, Quaternion.identity);
        //        tail.Insert(0, t.transform);

        //    }

        //    if (tail.Count < 0)
        //    {
        //        tail.Last().position = lastPositoin;
        //        tail.Insert(0, tail.Last());
        //        tail.RemoveAt(tail.Count - 1);
        //    }
        //}
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject == tempFruit)
        //        Destroy(tempFruit);
        //    else
        //        SceneManager.LoadScene("SampleScene");
        //}

        public Score score;
        public Snake snake;
        public GameController GC;

        void OnTriggerEnter2D(Collider2D other)
        {

            if (other.tag == "Frute")
            {
                snake.Eat();
                score.UpScore();
            }
            else
                GC.GameReload(true);


        }

    }
}