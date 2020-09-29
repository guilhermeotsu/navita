﻿namespace Nativa.API.Extensions
{

    /// <summary>
    /// Classe que representa a sessão AppSettings do arquivo appsettings.json
    /// </summary>
    public class AppSettings
    {
        public string Secret { get; set; } // Chave de Criptografia
        public int ExpirationHour { get; set; }  // Quantidade de horas que o token vai ficar valido
        public string Issuer { get; set; }  // Emissor
        public string ValidOn { get; set; } // Quais URLs o token e valido
    }
}
