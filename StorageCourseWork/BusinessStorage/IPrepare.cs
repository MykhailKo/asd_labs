namespace BusinessStorage
{    
    public enum Packages
    {
        PlasticBag = 1,
        PaperBox = 5,
        WoodenBox = 10
    }
    public interface IPrepare
    {
        public void Packaging();
        public void Loading();
    }
}