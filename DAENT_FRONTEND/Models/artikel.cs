namespace DAENT_FRONTEND.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wawi.artikel")]
    public partial class artikel
    {
        [Key]
        public int artnr { get; set; }

        [Required]
        [StringLength(60)]
        public string bezeichnung { get; set; }

        [Required]
        [StringLength(2)]
        public string gruppe { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal vkpreis { get; set; }

        public int lief { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? ekpreis { get; set; }

        public short? lieferzeit { get; set; }

        public int? mindbestand { get; set; }

        [StringLength(300)]
        public string hinweis { get; set; }

        public int mengebestellt { get; set; }

        public byte? mwst { get; set; }

        public bool aktiv { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? inaktivam { get; set; }

        [StringLength(30)]
        public string inaktivvon { get; set; }

        public virtual artikelgruppen artikelgruppen { get; set; }
    }
}
