namespace BusinessStorage
{
    public delegate void StorageEventHandler(object sender, EventArgs args);
    public class EventArgs
    {
        public string Message { get; set; }

        public EventArgs(string mes)
        {
            Message = mes;
        }
    }
}