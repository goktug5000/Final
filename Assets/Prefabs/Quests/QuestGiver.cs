using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private QuestSO questSO;
    [SerializeField] private PlayerQuests playerQuests;
    [SerializeField] private QuestGiverSO giverSO;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject dialogWait;

    private void Start()
    {
        playerQuests = PlayerConstantsHolder._playerConstantsHolder.playerQuests;
        dialog.SetActive(false);
        dialogWait.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (questSO != null)
            {
                dialog?.SetActive(true);
            }
            else
            {
                dialogWait?.SetActive(true);
            }

            if (Input.GetKeyDown(KeyBindings.KeyCodes[KeyBindings.KeyCode_Interaction]))
            {
                var quests = playerQuests.CheckQuests(giverSO);
                foreach (var quest in quests)
                {
                    CompleteQuest(quest);
                }
                if (questSO != null)
                {
                    GiveQuest();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialog.SetActive(false);
            dialogWait.SetActive(false);
        }
    }

    public void GiveQuest()
    {
        playerQuests.AddQuest(questSO);
        questSO = null;
        dialog.SetActive(false);
        dialogWait.SetActive(true);
    }

    public void CompleteQuest(QuestSO questSO)
    {
        playerQuests.ComplateQuest(questSO);
    }
}
