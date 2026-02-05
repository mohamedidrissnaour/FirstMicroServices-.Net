namespace ecom_web_app.bankaccount_service.Configurations;

public class BankAccountCollection
{
        // chaine de connection à la base de données MongoDB
        public string ConnectionString { get; set; } 
        // le nom de la base de donnees MongoDB
        public string DatabaseName { get; set; }   
        // le nom de la collection MongoDB pour les utilisateurs
        public string accountcollection { get; set; } 
    }

