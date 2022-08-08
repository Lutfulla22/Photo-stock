namespace Test.Entities
{
    public class Media
    {
        public Guid Id { get; set; }
        
        public byte[] Data { get; set; }

        [Obsolete("Used only for Entities binding.", true)]
        public Media() { }  

        public Media(byte[] data)
        {
            Id = Guid.NewGuid();
            Data = data;
        }
    }
}