
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class GameController : MonoBehaviour
    {
        public Snake snake;
        public Fruts fruts;
        public Score score;

        public Text fail;
        public Text win;
        Text text;
        bool is_text_active = false;

        private void Start()
        {
            fail.gameObject.SetActive(false);
            win.gameObject.SetActive(false);
        }
        public void GameReload(bool isfail = true)
        {

            snake.Reload();
            fruts.NewFrute();
            score.ReloadScore();

            // text.gameObject.SetActive(false);

            if (isfail)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                win.gameObject.SetActive(true);
                Time.timeScale = 0;

                //    SceneManager.LoadScene("SampleScene");
            }

            //text.gameObject.SetActive(true);
         
            is_text_active = true;
             timer = 0;


        }

        float timer = 0;
        void Update()
        {
            if (is_text_active && timer > 5)
            {
                text.gameObject.SetActive(false);
                is_text_active = false;

            }

            timer += Time.deltaTime;
        }
    }
}