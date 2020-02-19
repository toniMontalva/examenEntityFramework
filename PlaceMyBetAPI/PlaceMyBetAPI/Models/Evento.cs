﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }

        public List<Mercado> Mercados { get; set; }

        public Evento(int eventoId, string equipoLocal, string equipoVisitante, DateTime time)
        {
            EventoId = eventoId;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = time;
            //Mercados = new List<Mercado>();
            //Apuestas = new List<Apuesta>();
        }

        public Evento()
        {

        }
    }
}