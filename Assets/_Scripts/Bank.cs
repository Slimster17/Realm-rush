using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int startedBalance = 150;

        [SerializeField] private int currentBalance;

        private void Awake()
        {
            currentBalance = startedBalance;
        }


        public int CurrentBalance
        {
            get => currentBalance;
            set => currentBalance = value;
        }

        public void Deposit(int amount)
        {
            currentBalance += Mathf.Abs(amount);
        }

        public void WithDraw(int amount)
        {
            currentBalance -= Mathf.Abs(amount);
           
            if (currentBalance <= 0)
            {
                ReloadScene();
            }
        }

        private static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
