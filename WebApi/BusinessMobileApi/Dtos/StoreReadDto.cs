namespace BusinessMobileApi.Dtos
{
    public class StoreReadDto
    {
        public int id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public int connected { get; set; }
        public int seller { get; set; }
        public decimal paidAmount { get; set; }
        public decimal unpaidAmount { get; set; }
    }
}
