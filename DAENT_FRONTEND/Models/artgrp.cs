namespace DAENT_FRONTEND.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class artgrp : Model1
    {
        public int id { get; set; }

        public string artikelname { get; set; }

        public string artikelgruppe { get; set; }

        public int artikelanzahl { get; set; }
    }
}
