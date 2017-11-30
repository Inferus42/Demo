using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplication2.Models;
using WebApplication2.DAO;


namespace WebApplication2.DAO
{
    public class ShipDAO : DAO
    {

        public List<Ship> GetAllRecords()

        {
            Connect();
            List<Ship> recordList = new List<Ship>();

                SqlCommand command = new SqlCommand("SELECT * FROM Ship", sql);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Ship record = new Ship();
                    record.Id = Convert.ToInt32(reader["Id"]);
                    record.NameShip = Convert.ToString(reader["NameShip"]);
                    record.Length = Convert.ToInt32(reader["Length"]);
                    record.Width = Convert.ToInt32(reader["Width"]);
                    record.Height = Convert.ToInt32(reader["Height"]);
                    record.Capacity = Convert.ToInt32(reader["Capacity"]);
                    record.Info = Convert.ToString(reader["Info"]);
                    record.Date = Convert.ToDateTime(reader["Date"]);
                    recordList.Add(record);
                }
                reader.Close();

            return recordList;
        }

        public bool AddRecord(Ship records)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Ship (NameShip, Length, Width, Height, Capacity, Info, Date) " +
                "VALUES (@NameShip, @Length, @Width, @Height, @Capacity, @Info, @Date)", sql);
                cmd.Parameters.Add(new SqlParameter("@NameShip", records.NameShip));
                cmd.Parameters.Add(new SqlParameter("@Length", records.Length));
                cmd.Parameters.Add(new SqlParameter("@Width", records.Width));
                cmd.Parameters.Add(new SqlParameter("@Height", records.Height));
                cmd.Parameters.Add(new SqlParameter("@Capacity", records.Capacity));
                cmd.Parameters.Add(new SqlParameter("@Info", records.Info));
                cmd.Parameters.Add(new SqlParameter("@Date", records.Date));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public void EditRecord(Ship record)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("UPDATE Ship SET NameShip = @NameShip, Length = @Length," +
                "Width = @Width, Height = @Height, Capacity = @Capacity, Info = @Info, Date = @Date WHERE Id = @Id", sql);
                cmd.Parameters.Add(new SqlParameter("@NameShip", record.NameShip));
                cmd.Parameters.Add(new SqlParameter("@Length", record.Length));
                cmd.Parameters.Add(new SqlParameter("@Width", record.Width));
                cmd.Parameters.Add(new SqlParameter("@Height", record.Height));
                cmd.Parameters.Add(new SqlParameter("@Capacity", record.Capacity));
                cmd.Parameters.Add(new SqlParameter("@Info", record.Info));
                cmd.Parameters.Add(new SqlParameter("@Date", record.Date));
                cmd.Parameters.Add(new SqlParameter("@Id", record.Id));
                cmd.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }

        }

        public Ship getById(int id)
        {
            List<Ship> Ships = GetAllRecords();
            foreach (var s in Ships)
            {
                if (s.Id == id) { return s; }
            }
            return new Ship("Не найден объект с таким Id");

        }
        public void DeleteRecord(int id)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Ship WHERE Id = @Id", sql);
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();
            }

            finally
            {
                Disconnect();
            }

        }
    }
}