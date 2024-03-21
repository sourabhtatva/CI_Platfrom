using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entity;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackEnd.DAL
{
    public class DALVolunteeringTimesheet
    {
        private readonly CIDbContext _cIDbContext;
        public DALVolunteeringTimesheet(CIDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }
        #region Volunteeting Hours

        public List<VolunteeringHours> GetVolunteeringHoursList(int userId)
        {
            List<VolunteeringHours> volunteeringHours = new List<VolunteeringHours>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserId", userId);
                    volunteeringHours = cnn.Query<VolunteeringHours>(StoreProcedure.VolunteeringHoursList_Usp, param, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringHours;
        }
        public VolunteeringHours GetVolunteeringHoursListById(int id)
        {
            VolunteeringHours volunteeringHours = new VolunteeringHours();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    volunteeringHours = cnn.Query<VolunteeringHours>(StoreProcedure.VolunteeringHoursDetailById_Usp, param, null, true, 0, CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringHours;
        }
        public string AddVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserId", volunteeringHours.UserId);
                    param.Add("@MissionId", volunteeringHours.MissionId);
                    param.Add("@DateVolunteered", volunteeringHours.DateVolunteered);
                    param.Add("@Hours", volunteeringHours.Hours);
                    param.Add("@Minutes", volunteeringHours.Minutes);
                    param.Add("@Message", volunteeringHours.Message);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.AddVolunteeringHours_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UpdateVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", volunteeringHours.Id);
                    param.Add("@UserId", volunteeringHours.UserId);
                    param.Add("@MissionId", volunteeringHours.MissionId);
                    param.Add("@DateVolunteered", volunteeringHours.DateVolunteered);
                    param.Add("@Hours", volunteeringHours.Hours);
                    param.Add("@Minutes", volunteeringHours.Minutes);
                    param.Add("@Message", volunteeringHours.Message);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.UpdateVolunteeringHours_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteVolunteeringHours(int id)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.DeleteVolunteeringHours_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Volunteeting Goals

        public List<VolunteeringGoals> GetVolunteeringGoalsList(int userId)
        {
            List<VolunteeringGoals> volunteeringGoals = new List<VolunteeringGoals>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserId", userId);
                    volunteeringGoals = cnn.Query<VolunteeringGoals>(StoreProcedure.VolunteeringGoalsList_Usp, param, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringGoals;
        }
        public VolunteeringGoals GetVolunteeringGoalsListById(int id)
        {
            VolunteeringGoals volunteeringGoals = new VolunteeringGoals();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    volunteeringGoals = cnn.Query<VolunteeringGoals>(StoreProcedure.VolunteeringGoalsDetailById_Usp, param, null, true, 0, CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringGoals;
        }
        public string AddVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserId", volunteeringGoals.UserId);
                    param.Add("@MissionId", volunteeringGoals.MissionId);
                    param.Add("@Date", volunteeringGoals.Date);
                    param.Add("@Action", volunteeringGoals.Action);                    
                    param.Add("@Message", volunteeringGoals.Message);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.AddVolunteeringGoals_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UpdateVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", volunteeringGoals.Id);
                    param.Add("@UserId", volunteeringGoals.UserId);
                    param.Add("@MissionId", volunteeringGoals.MissionId);
                    param.Add("@Date", volunteeringGoals.Date);
                    param.Add("@Action", volunteeringGoals.Action);
                    param.Add("@Message", volunteeringGoals.Message);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.UpdateVolunteeringGoals_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteVolunteeringGoals(int id)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.DeleteVolunteeringGoals_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
