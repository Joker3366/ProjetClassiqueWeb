//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetClassiqueWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Instrumentation
    {
        public int Code_Instrumentation { get; set; }
        public Nullable<int> Code_Oeuvre { get; set; }
        public Nullable<int> Code_Instrument { get; set; }
    
        public virtual Instrument Instrument { get; set; }
        public virtual Oeuvre Oeuvre { get; set; }
    }
}
