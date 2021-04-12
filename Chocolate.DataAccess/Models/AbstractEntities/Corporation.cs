namespace Chocolate.DataAccess.Models.AbstractEntities
{
    public abstract class Corporation : NamedEntity
    {
        public string Type { get; set; }
        public string FullName
        {
            get
            {
                return $"{Name} {Type}";
            }
        }
    }
}
