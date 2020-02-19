using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class ApuestasRepository
    {
        /*public ApuestaDTO ToDTO(Apuesta apuesta)
        {
            int eventoId;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventoId = context.Mercados.FirstOrDefault(m => m.MercadoId == apuesta.MercadoId).EventoId;
            }

            return new ApuestaDTO(apuesta.UsuarioId, eventoId, apuesta.Cuota, apuesta.Cantidad, apuesta.Tipo, apuesta.Mercado);
        }*/

        // Inicio ejercicio 1
        public ApuestaDTO ToDTO(Apuesta apuesta)
        {
            int mercadoId;
            int usuarioId;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercadoId = context.Apuestas.FirstOrDefault(m => m.MercadoId == apuesta.MercadoId).MercadoId;
                usuarioId = context.Apuestas.FirstOrDefault(u => u.UsuarioId == apuesta.UsuarioId).UsuarioId;
            }

            return new ApuestaDTO(usuarioId, mercadoId);
        }
        // Fin ejercicio 1

        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();

            using(PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //apuestas = context.Apuestas.ToList();
                apuestas = context.Apuestas.Include(p => p.Mercado).ToList();
            }

            return apuestas;
        }

        internal List<Apuesta> RetrieveMoney(double dinero)
        {
            List<Apuesta> apuestas = new List<Apuesta>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //apuestas = context.Apuestas.ToList();
                apuestas = context.Apuestas.Where(a => a.Cantidad > dinero).ToList();
            }

            return apuestas;
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();

            using(PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(p => p.Mercado).Select(p => ToDTO(p)).ToList();
            }

            return apuestas;
        }

        // Inicio ejercicio 1
        public List<ApuestaDTO> RetrieveMoneyDTO(double money)
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas
                    .Where(a => a.Cantidad > money)
                    .Select(p => ToDTO(p)).ToList();
            }

            return apuestas;
        }

        // FIn ejercicio 1

        internal Apuesta Retrieve(int id)
        {
            Apuesta apuestas;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas
                    .Where(s => s.ApuestaId == id)
                    .FirstOrDefault();
            }

            return apuestas;
        }

        internal void Save(Apuesta a)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Apuestas.Add(a);
            context.SaveChanges();
        }
    }
}