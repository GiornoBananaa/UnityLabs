namespace ResourceSystem
{
    public class Resource
    {
        private int _quantity;
        
        public ResourceType Type { get; private set; }
        
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                if (_quantity < 0)
                {
                    _quantity = 0; 
                }
            }
        }

        public Resource(ResourceType type, int quantity)
        {
            Type = type;
            Quantity = quantity;
        }
    }
}
