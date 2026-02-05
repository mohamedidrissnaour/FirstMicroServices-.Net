namespace ecom_web_app.Configurations
{
    public class MongoDBSettings
    {
        // chaine de connection à la base de données MongoDB
        public string ConnectionString { get; set; } 
        // le nom de la base de donnees MongoDB
        public string DatabaseName { get; set; }   
        // le nom de la collection MongoDB pour les utilisateurs
        public string CustomerCollection { get; set; } 
        public string BankAccountCollection { get; set; }
    }
}