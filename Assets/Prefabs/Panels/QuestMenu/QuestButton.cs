using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestButton : MonoBehaviour
{
    public RawImage itemIamge;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI getText;
    public TextMeshProUGUI haveText;
    public QuestSO questSO;

    public void SetQuest(QuestSO quest)
    {
        questSO = quest;

        nameText.text = questSO.questName;
        descText.text = questSO.description;
        var getTextt = "";
        foreach (var a in questSO.gets)
        {
            getTextt += a.itemSo.objName + " -" + a.amount + "\n";
        }
        getText.text = getTextt;

        var haveTextt = "";
        foreach (var a in questSO.haves)
        {
            haveTextt += a.itemSo.objName + " -" + a.amount + "\n";
        }
        haveText.text = haveTextt;
    }
}
