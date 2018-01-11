namespace SimpleGameLoop
{
    public abstract class SimpleGameLoop : IGameLoop
    {

        /// <summary>
        /// Render the start screen and ask for input from a player.
        /// </summary>
        /// <returns>Code of the player's choice in the menu</returns>
        public abstract int ShowStartScreen();

        /// <summary>
        /// Start and render the game.
        /// </summary>
        /// <returns>Code of player's choice upon the end of the game.</returns>
        public abstract int StartGame();

        /// <summary>
        /// Exit the game.
        /// </summary>
        public abstract void ExitGame();

        public void Run()
        {
            while (true)
            {
                if (ShowStartScreen() == 0)
                    break;
                StartGame();
            }
            ExitGame();
        }

    }
}
