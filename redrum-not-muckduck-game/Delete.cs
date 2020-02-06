using System;
namespace redrum_not_muckduck_game
{
    class Delete
    {
        public static void Location(Room currentRoom)
        {
            int ROW_WHERE_LOCATION_STARTS = 1;
            int COLUMN_WHERE_LOCATION_STARTS = 16;

            for (int i = 0; i < currentRoom.GetNameLength(); i++)
            {
                Board.board[ROW_WHERE_LOCATION_STARTS, COLUMN_WHERE_LOCATION_STARTS + i] = ' ';
            }
        }

        public static void Scene()
        {
            int ROW_SCENE_ENDS = 20;
            int COL_SCENCE_STARTS = 1;
            int COL_SCENCE_ENDS = 48;

            for (int ROW_SCENE_STARTS = 14; ROW_SCENE_STARTS < ROW_SCENE_ENDS; ROW_SCENE_STARTS++)
            {
                for (int col = 0; col < COL_SCENCE_ENDS; col++)
                {
                    Board.board[ROW_SCENE_STARTS, COL_SCENCE_STARTS + col] = ' ';
                }
            }
        }
    }
}
