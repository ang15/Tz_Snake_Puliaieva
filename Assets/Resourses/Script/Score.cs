using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script{
    public class Score : MonoBehaviour
    {
       public int score = 0;

        public GameController GO;

        int sizeHeight = 30;
        int max_score=10;
        void Start() {
            //int height = (int)(sizeHeight / 3.4f) - 1;
            //int width = (int)((Screen.width / (Screen.height / sizeHeight) - 1.7f) / 3.4f) - 1;

            //max_score = height * width - 4;


        }

        public void UpScore() {

            score++;
            GetComponent<Text>().text = score.ToString();

            if (score == max_score)
                GO.GameReload(false);

        }

        public void ReloadScore() {

            score = 0;
            GetComponent<Text>().text = score.ToString();

        }
        private void Update()
        {
            if (score == max_score)
            {
                Time.timeScale = 0;
                GO.GameReload(false);
            }
        }
    }
}