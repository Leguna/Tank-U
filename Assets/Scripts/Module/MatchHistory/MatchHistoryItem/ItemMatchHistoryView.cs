using Agate.MVC.Base;
using TankU.Module.Base;
using TMPro;
using UnityEngine.UI;

namespace TankU.Module.MatchHistory.MatchHistoryItem
{
    public class ItemMatchHistoryView : ObjectView<IMatchHistoryItemModel>
    {
        public TMP_Text numberText;
        public TMP_Text winnerText;
        public Image winnerColor;
        public TMP_Text loseText;
        public Image loseColor;

        protected override void InitRenderModel(IMatchHistoryItemModel model)
        {
            gameObject.SetActive(true);
        }

        protected override void UpdateRenderModel(IMatchHistoryItemModel model)
        {
        }
    }
}