namespace redrum_not_muckduck_game
{
    class Render
    {
        public void AdjacentRooms()
        {
            int ROW_WHERE_OPTIONS_START = 14;
            int COLUMN_WHERE_OPTIONS_START = 2;
            string header = "You have the choice to go to: ";
            for (int i = 0; i < header.Length; i++)
            {
                Board.board[ROW_WHERE_OPTIONS_START, COLUMN_WHERE_OPTIONS_START + i] = header[i];
            }
            ROW_WHERE_OPTIONS_START++;
            foreach (Room room in Game.CurrentRoom.AdjacentRoom)
            {
                for (int i = 0; i < room.Name.Length; i++)
                {
                    Board.board[ROW_WHERE_OPTIONS_START, COLUMN_WHERE_OPTIONS_START + i] = room.Name[i];
                }
                ROW_WHERE_OPTIONS_START++;
            }
        }

        public void Quote()
        {
            int ROW_WHERE_QUOTE_STARTS = 14;
            int COLUMN_WHERE_QUOTE_STARTS = 1;
            for (int i = 0; i < Game.CurrentRoom.PersonInRoom.Length; i++)
            {
                Board.board[ROW_WHERE_QUOTE_STARTS, COLUMN_WHERE_QUOTE_STARTS + i] = Game.CurrentRoom.PersonInRoom[i];
            }
        }

        public void Action()
        {
            int ROW_WHERE_ACTIONS_START = 5;
            int COLUMN_WHERE_ACTIONS_START = 2;
            for (int i = 0; i < Game.Actions.Length; i++)
            {
                for (int j = 0; j < Game.Actions[i].Length; j++)
                {
                    Board.board[ROW_WHERE_ACTIONS_START, COLUMN_WHERE_ACTIONS_START + j] = Game.Actions[i][j];
                }
                ROW_WHERE_ACTIONS_START++;
            }
        }

        public void AskForSolution(string question)
        {
            int ROW_WHERE_QUESITON_STARTS = 14;
            int COLUMN_WHERE_QUESTION_STARTS = 1;
            for (int i = 0; i < question.Length; i++)
            {
                Board.board[ROW_WHERE_QUESITON_STARTS, COLUMN_WHERE_QUESTION_STARTS + i] = question[i];
            }
        }

        public void DeleteScene()
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
