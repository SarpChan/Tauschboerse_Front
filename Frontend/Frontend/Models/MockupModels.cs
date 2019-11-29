namespace Frontend.Models
{
    class MockupModels { 

        public MockupModels()
        {
            MockModule = "EMPTY";
        }
        private string _mockModule;
        public string MockModule
        {
            get
            {
                return _mockModule;
            }
            set
            {
                _mockModule = value;
            }
        }
    }
}
