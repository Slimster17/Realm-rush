using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace _Scripts
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int startedBalance = 150;

        [SerializeField] private int currentBalance;

        [SerializeField] private TextMeshProUGUI displayBalance;

        private void Awake()
        {
            currentBalance = startedBalance;
            UpdateDislay();
        }


        public int CurrentBalance
        {
            get => currentBalance;
            set => currentBalance = value;
        }

        private void UpdateDislay()
        {
            displayBalance.text = $"Gold: {currentBalance}";
        }

        public void Deposit(int amount)
        {
            currentBalance += Mathf.Abs(amount);
            UpdateDislay();
        }

        public void WithDraw(int amount)
        {
            currentBalance -= Mathf.Abs(amount);
            UpdateDislay();
            
            if (currentBalance < 0)
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
