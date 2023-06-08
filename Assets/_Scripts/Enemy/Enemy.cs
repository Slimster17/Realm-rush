using UnityEngine;

namespace _Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int goldReward = 25;
        [SerializeField] private int goldPenalty = 25;

        private Bank _bank;
    
    
        // Start is called before the first frame update
        void Start()
        {
            _bank = FindObjectOfType<Bank>();
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void RewardGoal()
        {
            if (_bank == null)
            {
                return;
            }
            
            _bank.Deposit(goldReward);
        }

        public void StealGoal()
        {
            if (_bank == null)
            {
                return;
            }
            _bank.WithDraw(goldPenalty);
        }
        
    }
}
