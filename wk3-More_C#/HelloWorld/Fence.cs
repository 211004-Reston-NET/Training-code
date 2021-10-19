namespace HouseFunction
{
    public class Fence : House
    {
        public Fence(string p_ghost)
        {
            //Fence has access to Ghost property because it is the child class of House
            base.Ghost = p_ghost;
        }
    }
}