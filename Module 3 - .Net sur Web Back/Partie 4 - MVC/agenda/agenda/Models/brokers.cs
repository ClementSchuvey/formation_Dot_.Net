//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace agenda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class brokers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brokers()
        {
            this.appointments = new HashSet<appointments>();
        }
    
        public int id { get; set; }

        /*
         * La regex de notre attribut, et son message d'erreur si la regex passe pas
         * Le nom de l'attribut
         * Nous précisons que nous avons besoins de cet atribut si il est vide un message d'erreur et mis par defaut je peux en mettre un personaliser si je veux
         */
        [RegularExpression(@"^[A-Z]?[a-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ]+[-']?[a-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ]+$", ErrorMessage = "Saisie non valide")]
        [DisplayName("Nom")]
        [Required]
        [StringLength(50, ErrorMessage = "Votre nom est trop grand")]
        public string lastName { get; set; }

        [RegularExpression(@"^[A-Z]?[a-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ]+[-']?[a-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ]+$", ErrorMessage = "Saisie non valide")]
        [DisplayName("Prénom")]
        [Required]
        [StringLength(50, ErrorMessage = "Votre prénom est trop grand")]
        public string firstName { get; set; }
        
        [RegularExpression(@"^[A-Z-a-z-0-9-.éàèîÏôöùüûêëç]{2,}@[A-Z-a-z-0-9éèàêâùïüëç]{2,}[.][a-z]{2,6}$", ErrorMessage = "Saisie non valide")]
        [DisplayName("Mail")]
        [Required]
        [StringLength(100, ErrorMessage = "Votre mail est trop grand")]
        public string mail { get; set; }

        [RegularExpression(@"^[0]{1}[0-9]{9}$", ErrorMessage = "Saisie non valide")]
        [DisplayName("Numéro de téléphone")]
        [Required]
        [StringLength(10, ErrorMessage = "Numéro de téléphone doit comporter 10 chiffres")]
        public string phoneNumber { get; set; }

        public string completNameBroker
        {
            get
            {
                // Concaténer lastname et firstname pour avoir une seule chaîne de caractères
                return string.Format("{0} {1}", lastName, firstName);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointments> appointments { get; set; }
    }
}
