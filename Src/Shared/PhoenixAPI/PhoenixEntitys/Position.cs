namespace Shared.PhoenixAPI.PhoenixEntitys
{
    public class Position
    {
        public Position(byte positionX, byte positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public byte PositionX { get; }
        public byte PositionY { get; }
    }
}