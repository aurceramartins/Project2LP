using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Player
    {
        public int HP { get; set; }
        public Position PlayerPos { get; set; }
        public Player(int hp = 100)
        {
            HP = hp;
            PlayerPos = PlayerRandPos();
        }

        public Position PlayerRandPos()
        {
            Random rnd = new Random();
            int startPos = rnd.Next(0, 8);
            PlayerPos = new Position(startPos, 0);
            return PlayerPos;
        }

        public void DoPlayerAction(int action, out bool enableMov, out bool quit, ref int canPickUp)
        {
            enableMov = true;
            quit = false;
            
            switch (action)
            {
                case 1:
                    canPickUp = 0;
                    if (PlayerPos.Row - 1 >= 0)
                    {
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
                    quit = true;
                    break;
                case 6:
                    if(canPickUp != 0)
                    {
                        if(canPickUp == 1) { canPickUp = 1; }
                        else { canPickUp = - 1; }
                    }
                    else
                    {
                        canPickUp = -1;
                    }
                    break;
                case 0: enableMov = false; canPickUp = 0; break;
            }
        }

        public int ChoseAction()
        {
            string option = Console.ReadLine();
            switch (option)
            {
                case "w": return 1; break;
                case "a": return 2; break;
                case "s": return 3; break;
                case "d": return 4; break;
                case "q": return 5; break;
                case "e": return 6; break;
                default: return 0;
            }
        }

        public void PlayerActions(Board board)
        {
            board.BoardTiles[PlayerPos.Row, PlayerPos.Column].Insert(0, this);
            board.BoardTiles[PlayerPos.Row, PlayerPos.Column].RemoveAt(10);
            board.BoardTiles[PlayerPos.Row, PlayerPos.Column].TileExploration = true;

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
            if (PlayerPos.Column == 0 && PlayerPos.Row == 0)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            if (PlayerPos.Column == 0 && PlayerPos.Row == 7)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
            }
            if (PlayerPos.Column == 7 && PlayerPos.Row == 0)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            if (PlayerPos.Column == 7 && PlayerPos.Row == 7)
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
            }
            if (PlayerPos.Column == 0 && (PlayerPos.Row > 0 && PlayerPos.Row < 7))
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            if (PlayerPos.Column == 7 && (PlayerPos.Row > 0 && PlayerPos.Row < 7))
            {
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
            }
            if (PlayerPos.Row == 0 && (PlayerPos.Column > 0 && PlayerPos.Column < 7))
            {
                board.BoardTiles[PlayerPos.Row + 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
            }
            if (PlayerPos.Row == 7 && (PlayerPos.Column > 0 && PlayerPos.Column < 7))
            {
                board.BoardTiles[PlayerPos.Row - 1, PlayerPos.Column].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column + 1].TileExploration = true;
                board.BoardTiles[PlayerPos.Row, PlayerPos.Column - 1].TileExploration = true;
            }
        }
    }
}
