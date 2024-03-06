using TMPro;
using UnityEngine;

namespace ScoreManagement
{
    public class ScoreUI : MonoBehaviour
    {
        TMP_Text _textField;

        void Start()
        {
            _textField = GetComponent<TMP_Text>();

            LevelScore.onScoreChanges += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _textField.text = LevelScore.CurrentScorePoints.ToString();
        }
    }
}

