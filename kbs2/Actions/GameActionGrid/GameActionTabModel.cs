using kbs2.Actions.Interfaces;
using kbs2.UserInterface.GameActionGui;
using kbs2.World.Structs;
using kbs2.WorldEntity.Structs;

namespace kbs2.Actions.GameActionGrid
{
    public class GameActionTabModel
    {
        public const int COLUMNS = 3;
        public const int ROWS = 3;

        public const int GAME_ACTIONS_PER_TAB = ROWS * COLUMNS;

        private int GuiWidth => (int) parent.View.Width;
        private int GuiHeight => (int) parent.View.Height;

        /// <summary>
        /// Times the size of the moats in between the items
        /// </summary>
        private const float ITEM_WEIGHT = 2;

        /// <summary>
        /// ITEM_WEIGHT times as big as the 'moats' in between
        /// </summary>
        private int ItemWidth => (int) (GuiWidth / (COLUMNS * (ITEM_WEIGHT + 1) + 1) * ITEM_WEIGHT);

        /// <summary>
        /// Horizontal moat size
        /// </summary>
        private int HMoatSize => (int) (GuiWidth / (COLUMNS * (ITEM_WEIGHT + 1) + 1));
        
        /// <summary>
        /// Vertical moat size
        /// </summary>
        private int VMoatSize => (int) ((GuiHeight - (ROWS * ItemWidth)) / ROWS + 1);

        private GameActionGuiController parent;

        public GameActionTabItem[] GameActionTabItems { get; }

        public GameActionTabModel(IGameAction[] gameActions, GameActionGuiController parent)
        {
            this.parent = parent;

            GameActionTabItems = new GameActionTabItem[GAME_ACTIONS_PER_TAB];

            int column = 0;
            int row = 0;

            for (int i = 0; i < gameActions.Length; i++)
            {
                IGameAction gameAction = gameActions[i];
                FloatCoords location = new FloatCoords()
                {
                    x = column * (ItemWidth + HMoatSize) + HMoatSize,
                    y = row * (ItemWidth + VMoatSize) + VMoatSize
                };

                location += parent.View.Coords;

                ViewValues viewValues = new ViewValues(gameAction.IconValues.Image, ItemWidth, ItemWidth);
                gameAction.IconValues = viewValues;

                GameActionTabItems[i] = new GameActionTabItem(gameAction, location);
                column++;

                if (column < COLUMNS) continue;

                column = 0;
                row++;
            }
        }
    }
}