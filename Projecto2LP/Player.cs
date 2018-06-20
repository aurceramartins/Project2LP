using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    /// <summary>
    /// Class Player.
    /// </summary>
    class Player
    {
        /// <summary>
        /// Propertie int HP.
        /// </summary>
        public int HP { get; set; }
        /// <summary>
        /// Propertie Position PlayerPos.
        /// </summary>
        public Position PlayerPos { get; set; }
        /// <summary>
        /// Construnctor Player.
        /// </summary>
        /// <param name="hp"></param>
        public Player(int hp = 100)
        {
            HP = hp;
            PlayerPos = PlayerRandPos();
        }
        /// <summary>
        /// Method PlayerRandPos. Set the player random position in the board
        /// </summary>
        /// <returns></returns>
        public Position PlayerRandPos()
        {
            ///Instanciate class Random
            Random rnd = new Random();
            ///Save the random position between 0 and 8.
            int startPos = rnd.Next(0, 8);
            ///Set the new position to the player.
            PlayerPos = new Position(startPos, 0);
            return PlayerPos;
        }
        /// <summary>
        /// Method DoPlayerAction. Do the posible player actions.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="enableMov"></param>
        /// <param name="quit"></param>
        /// <param name="canPickUp"></param>
        public void DoPlayerAction(int action, out bool enableMov, out bool quit, ref int canPickUp)
        {
            ///asigned param out enableMov.
            enableMov = true;
            ///asigned param out quit.
            quit = false;
            ///Switch actions of the player.
            switch (action)
            {
                case 1:
                    canPickUp = 0;
                    ///If player isn´t in a border of the board
                    if (PlayerPos.Row - 1 >= 0)
                    {
                        ///Move player to west
                        PlayerPos = new Position(PlayerPos.Row - 1, PlayerPos.Column);
                    }
                    else
                    {
                        enableMov = false;
                    }
                    break;
                case 2:
                    canPickUp = 0;
                    if (PlayerPos.Column - 1 >= 0)
                    {
                        PlayerPos = new Position(PlayerPos.Row, PlayerPos.Column - 1);
                    }
                    else
                    {
                        enableMov = false;
                    }
                    break;
                case 3:
                    canPickUp = 0;
                    if (PlayerPos.Row + 1 <= 7)
                    {
                        PlayerPos = new Position(PlayerPos.Row + 1, PlayerPos.Column);
                    }
                    else
                    {
                        enableMov = false;
                    }
                    break;
                case 4:
                    canPickUp = 0;
                    if (PlayerPos.Column + 1 <= 7)
                    {
                        PlayerPos = new Position(PlayerPos.Row, PlayerPos.Column + 1);
                    }
                    else
                    {
                        enableMov = false;
                    }
                    break;
                case 5:
                    ///Exit game to the menu.
                    quit = true;
                    break;
                case 6:
                    ///If the player can pickup the object
                    if(canPickUp != 0)
                    {
                        ///Set the ref variable to 1 thats it the map option
                        if(canPickUp == 1) { canPickUp = 1; }
                        else { canPickUp = - 1; }
                    }
                    else
                    {
                        canPickUp = -1;
                    }
                    break;
                    ///If the action its not posible return option to repeat the movement.
                case 0: enableMov = false; canPickUp = 0; break;
            }
        }
        /// <summary>
        /// Mathod ChoseAction. Get player input election.
        /// </summary>
        /// <returns></returns>
        public int ChoseAction()
        {
            string option = Console.ReadLine();
            switch (option)
            {
                case "w": return 1;
                case "a": return 2;
                case "s": return 3;
                case "d": return 4;
                case "q": return 5;
                case "e": return 6;
                default: return 0;
            }
        }
        /// <summary>
        /// Method PlayerActions. Set the posible positions of the player in the board.
        /// </summary>
        /// <param name="board"></param>
        public void PlayerActions(Board board)
        {
            ///Insert the player in the Tile
            board.BoardTiles[PlayerPos.Row, PlayerPos.Column].Insert(0, this);
            ///Remove the last Tile in the board cell.
            board.BoardTiles[PlayerPos.Row, PlayerPos.Column].RemoveAt(10);
            ///Explore the player cell.
            board.BoardTiles[PlayerPos.Row, PlayerPos.Column].TileExploration = true;
            ///Explore tiles when player position isn´t in the border of board.
            if (PlayerPos.Column > 0 && PlayerPos.Column < 7)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;

            }
            if (PlayerPos.Row > 0 && PlayerPos.Row < 7)
            {
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            ///Expored tiles when player is in the first row and column
            if (PlayerPos.Column == 0 && PlayerPos.Row == 0)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            ///Expored tiles when player is in the last row and first column
            if (PlayerPos.Column == 0 && PlayerPos.Row == 7)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
            }
            ///Expored tiles when player is in the last column and first row
            if (PlayerPos.Column == 7 && PlayerPos.Row == 0)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            ///Expored tiles when player is in the last row and column
            if (PlayerPos.Column == 7 && PlayerPos.Row == 7)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
            }
            ///Expored tiles when player is in the first column
            if (PlayerPos.Column == 0 && (PlayerPos.Row > 0 && PlayerPos.Row < 7))
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            ///Expored tiles when player is in the last column
            if (PlayerPos.Column == 7 && (PlayerPos.Row > 0 && PlayerPos.Row < 7))
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            ///Expored tiles when player is in the first row
            if (PlayerPos.Row == 0 && (PlayerPos.Column > 0 && PlayerPos.Column < 7))
            {
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
            }
            ///Expored tiles when player is in the last row
            if (PlayerPos.Row == 7 && (PlayerPos.Column > 0 && PlayerPos.Column < 7))
            {
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
            }
        }
    }
}
