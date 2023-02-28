using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Ejercicio4.Model;


namespace Ejercicio4.Controller
{
    public class DB_Empleados
    {
        readonly SQLiteAsyncConnection dbase;
        public DB_Empleados(String dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            // Crearemos las tablas de la base de datos 
            dbase.CreateTableAsync<Empleados>(); //Creado la tabla de Empleado


        }

        #region OperacionesEmple
        // CRUD - Create - Read - Update - Delete
        // Create
        public Task<int> EmpleSave(Empleados emple)
        {
            if (emple.codigo != 0)
            {
                return dbase.UpdateAsync(emple); // Update
            }
            else
            {
                return dbase.InsertAsync(emple); ;// Insert
            }
        }

        // Read
        public Task<List<Empleados>> obtenerListaEmple()
        {
            return dbase.Table<Empleados>().ToListAsync();
        }

        // Read V2
        public Task<Empleados> obtenerEmple(int pid)
        {
            return dbase.Table<Empleados>()
                .Where(i => i.codigo == pid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> EmpleDelete(Empleados emple)
        {
            return dbase.DeleteAsync(emple);
        }

        #endregion OperacionesEmple
    }
}
