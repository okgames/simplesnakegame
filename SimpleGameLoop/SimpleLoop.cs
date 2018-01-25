namespace SimpleGameLoop
{
    public abstract class SimpleLoop : IGameLoop
    {
        public void Run()
        {
            while(ShowStartScreen() != 0 && StartGame() != 0)
            {                
            }
            ExitGame();
        }

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
        
    }
}
