namespace ConverterAPI.Domain {
    public class Currency {

        public string ShortName{get; set;}     

        public string Name{get;set;}
        
        public Currency(){}
        public Currency(string name, string shortName) {        

            Name = name;
            ShortName = shortName;            
        }
    }
}
