﻿using BackEnd.Entity;
using BackEnd.Entity.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class DALMission
    {
        private readonly CIDbContext _cIDbContext;
        
        public DALMission(CIDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }
        public List<DropDown> GetMissionThemeList()
        {
            List<DropDown> missionthemeList = new List<DropDown>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    missionthemeList = cnn.Query<DropDown>(StoreProcedure.ActiveThemeList_Usp, null, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return missionthemeList;
        }
        public List<DropDown> GetMissionSkillList()
        {
            List<DropDown> missionskillList = new List<DropDown>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    missionskillList = cnn.Query<DropDown>(StoreProcedure.ActiveSkillList_Usp, null, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return missionskillList;
        }
        public List<Missions> MissionList()
        {
            List<Missions> missions = new List<Missions>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {                    
                    missions = cnn.Query<Missions>(StoreProcedure.MissionList_Usp, null, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return missions;
        }
        public string AddMission(Missions mission)
        {
            string result = "";
            try
            {
                using(SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();                  
                    param.Add("@MissionTitle", mission.MissionTitle);
                    param.Add("@MissionDescription", mission.MissionDescription);
                    param.Add("@MissionOrganisationName", mission.MissionOrganisationName);
                    param.Add("@MissionOrganisationDetail", mission.MissionOrganisationDetail);
                    param.Add("@CountryId", mission.CountryId);
                    param.Add("@CityId", mission.CityId);
                    param.Add("@StartDate", mission.StartDate);
                    param.Add("@EndDate", mission.EndDate);
                    param.Add("@MissionType", mission.MissionType);
                    param.Add("@TotalSheets", mission.TotalSheets);
                    param.Add("@RegistrationDeadLine", mission.RegistrationDeadLine);
                    param.Add("@MissionThemeId", mission.MissionThemeId);
                    param.Add("@MissionSkillId", mission.MissionSkillId);
                    param.Add("@MissionImages", mission.MissionImages);
                    param.Add("@MissionDocuments", mission.MissionDocuments);
                    param.Add("@MissionAvilability", mission.MissionAvilability);
                    param.Add("@MissionVideoUrl", mission.MissionVideoUrl);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.AddMission_Usp, param, null, 0, CommandType.StoredProcedure));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }        
        public Missions MissionDetailById(int id)
        {
            Missions mission = new Missions();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    mission = cnn.Query<Missions>(StoreProcedure.MissionDetailById_Usp, param, null, true, 0, CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return mission;
        }
        public string UpdateMission(Missions mission)
        {
            string result = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", mission.Id);
                    param.Add("@MissionTitle", mission.MissionTitle);
                    param.Add("@MissionDescription", mission.MissionDescription);
                    param.Add("@MissionOrganisationName", mission.MissionOrganisationName);
                    param.Add("@MissionOrganisationDetail", mission.MissionOrganisationDetail);
                    param.Add("@CountryId", mission.CountryId);
                    param.Add("@CityId", mission.CityId);
                    param.Add("@StartDate", mission.StartDate);
                    param.Add("@EndDate", mission.EndDate);
                    param.Add("@MissionType", mission.MissionType);
                    param.Add("@TotalSheets", mission.TotalSheets);
                    param.Add("@RegistrationDeadLine", mission.RegistrationDeadLine);
                    param.Add("@MissionThemeId", mission.MissionThemeId);
                    param.Add("@MissionSkillId", mission.MissionSkillId);
                    param.Add("@MissionImages", mission.MissionImages);
                    param.Add("@MissionDocuments", mission.MissionDocuments);
                    param.Add("@MissionAvilability", mission.MissionAvilability);
                    param.Add("@MissionVideoUrl", mission.MissionVideoUrl);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.UpdateMission_Usp, param, null, 0, CommandType.StoredProcedure));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public string DeleteMission(int id)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.DeleteMission_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MissionApplication> MissionApplicationList()
        {
            List<MissionApplication> missionApplicationList = new List<MissionApplication>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    missionApplicationList = cnn.Query<MissionApplication>(StoreProcedure.MissionApplicationList_Usp, null, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return missionApplicationList;
        }
        
        public string MissionApplicationDelete(int id)
        {
            try
            {
                var missionApplication = _cIDbContext.MissionApplication.FirstOrDefault(m => m.Id == id);
                if (missionApplication != null)
                {
                    missionApplication.IsDeleted = true;
                    _cIDbContext.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Record not found";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string MissionApplicationApprove(int id)
        {
            try
            {
                var missionApplication = _cIDbContext.MissionApplication.FirstOrDefault(m => m.Id == id);
                if (missionApplication != null)
                {
                    missionApplication.Status = true;
                    _cIDbContext.SaveChanges();
                    return "Mission is approved";
                }
                else
                {
                    return "Mission is not approved";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<Missions> ClientSideMissionList(int userId)
        {
            List<Missions> clientSideMissionlist = new List<Missions>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@UserId", userId);
                    clientSideMissionlist = cnn.Query<Missions>(StoreProcedure.MissionListClientSide_Usp, param, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return clientSideMissionlist;
        }
        public List<Missions> MissionClientList(SortestData data)
        {
            List<Missions> clientSideMissionlist = new List<Missions>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@UserId", data.UserId);
                    param.Add("@SortingValue", data.SortestValue);
                    clientSideMissionlist = cnn.Query<Missions>(StoreProcedure.TestingMissionListClientSide_Usp, param, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return clientSideMissionlist;
        }

        public string ApplyMission(MissionApplication missionApplication)
        {
            string result = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", missionApplication.MissionId);
                    param.Add("@UserId", missionApplication.UserId);
                    param.Add("@AppliedDate", missionApplication.AppliedDate);
                    param.Add("@Status", missionApplication.Status);                            
                    param.Add("@Sheet", missionApplication.Sheet);                            
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.ApplyMission_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public Missions MissionDetailByMissionId(SortestData data)
        {
            Missions missionDetail = new Missions();
            try
            {
                using(SqlConnection cnn =new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", data.MissionId);
                    param.Add("@UserId", data.UserId);
                    missionDetail = cnn.Query<Missions>(StoreProcedure.MissionDetailByMissionId_Usp, param, null, true, 0, CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return missionDetail;
        }
        public string AddMissionComment(MissionComment missionComment)
        {
            string result = "";
            try
            {   
                using(SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", missionComment.MissionId);
                    param.Add("@UserId", missionComment.UserId);
                    param.Add("@CommentDescription", missionComment.CommentDescription);
                    param.Add("@CommentDate", missionComment.CommentDate);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.AddMissionComment_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MissionComment> MissionCommentListByMissionId(int missionId)
        {
            List<MissionComment> missionCommentList = new List<MissionComment>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", missionId);
                    missionCommentList = cnn.Query<MissionComment>(StoreProcedure.MissionCommentListByMissionId_Usp, param, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return missionCommentList;
        }
        public string AddMissionFavourite(MissionFavourites missionFavourites)
        {
            string result = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", missionFavourites.MissionId);
                    param.Add("@UserId", missionFavourites.UserId);                
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.AddMissionFavourite_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string RemoveMissionFavourite(MissionFavourites missionFavourites)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", missionFavourites.MissionId);
                    param.Add("@UserId", missionFavourites.UserId);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.RemoveMissionFavourite_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string MissionRating(MissionRating missionRating)
        {
            try
            {
                string result = "";
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", missionRating.MissionId);
                    param.Add("@UserId", missionRating.UserId);
                    param.Add("@Rating", missionRating.Rating);
                    result = Convert.ToString(cnn.ExecuteScalar(StoreProcedure.AddUpdateMissionRating_Usp, param, null, 0, CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MissionApplication> RecentVolunteerList(MissionApplication missionApplication)
        {
            List<MissionApplication> recentList = new List<MissionApplication>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@MissionId", missionApplication.MissionId);
                    param.Add("@UserId", missionApplication.UserId);
                    recentList = cnn.Query<MissionApplication>(StoreProcedure.RecentVolunteersList_Usp, param, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return recentList;
        } 
        public List<User> GetUserList(int userId)
        {
            List<User> userList = new List<User>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cIDbContext.CreateConnection().ConnectionString))
                {
                    cnn.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserId", userId);
                    userList = cnn.Query<User>(StoreProcedure.UserListShareOrInvite_Usp, param, null, true, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }
        public string SendInviteMissionMail(List<MissionShareOrInvite> user)
        {
            string result = "";
            try
            {                              
                foreach(var item in user)
                {                
                    string callbackurl =  item.baseUrl + "/volunteeringMission/"+item.MissionId;
                    string mailTo = item.EmailAddress;
                    string userName = item.UserFullName;
                    string emailBody= "Hi " + userName + ",<br/><br/> Click the link below to suggest mission link <br/><br/> " + callbackurl;
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient();
                    mail.From = new MailAddress(item.MissionShareUserEmailAddress);
                    mail.To.Add(mailTo);
                    mail.Subject = "Invite Mission Link";
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    SmtpServer.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred = new NetworkCredential(item.MissionShareUserEmailAddress, "yourpassword");
                    SmtpServer.Credentials = NetworkCred;
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Port = 587;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.Send(mail);                    
                }
                result = "Mission Invite Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
