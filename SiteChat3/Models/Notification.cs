//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteChat3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        public int IdNotification { get; set; }
        public string TexteNotification { get; set; }
        public byte StatutNotification { get; set; }
        public int IdCreateur { get; set; }
        public int IdDestinataire { get; set; }
        public Nullable<int> IdDiscussion { get; set; }
        public int IdTypeNotification { get; set; }
    
        public virtual Utilisateur Utilisateur { get; set; }
        public virtual Utilisateur Utilisateur1 { get; set; }
        public virtual TypeNotification TypeNotification { get; set; }
    }
}
