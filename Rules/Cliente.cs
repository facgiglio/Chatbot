﻿using System;
using System.Collections.Generic;
using Framework;
using Framework.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace Rules
{
    public class Cliente
    {
        Mapper<Models.Cliente> mapper = new Mapper<Models.Cliente>();

        #region Insertar
        public void Insertar(Models.Cliente cliente)
        {
            mapper.Insert(cliente);

            Logger.LogInfo();
        }
        #endregion

        #region Modificar
        public void Modificar(Models.Cliente cliente)
        {
            //Actualizo el usuario
            mapper.Update(cliente);
        }
        #endregion

        #region Eliminar
        public void Eliminar(int Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@IdCliente", Id)
            };

            mapper.Delete(parameters.ToArray());
        }
        #endregion

        #region Obtener
        
        public Models.Cliente ObtenerPorId(int Id)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@IdCliente", Id)
                };

                return mapper.GetById(Id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public List<object> ObtenerListado()
        {
            return mapper.GetList(null);
        }
        
        public Models.Cliente ObtenerPoryRazonSocial(string RazonSocial)
        {
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@RazonSocial", RazonSocial)
            };

            return mapper.GetByWhere(parameters.ToArray());
        }
        
        #endregion

    }
}
