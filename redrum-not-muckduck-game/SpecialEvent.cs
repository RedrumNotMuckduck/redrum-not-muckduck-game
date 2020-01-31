using System;
namespace redrum_not_muckduck_game
{
    public class SpecialEvent
    {
        public string SpecialEvent1 { get; } = "Oscar falling out of ceiling";
        public string SpecialEvent2 { get; } = "vending machine";

        //TODO: Make a function that knows what event to render
        public void Render()
        {
            int COLUMN_WHERE_TEXTS_END = 10;
            for (int i = 0; i < COLUMN_WHERE_TEXTS_END; i++)
            {
            }
        }
    }
}
