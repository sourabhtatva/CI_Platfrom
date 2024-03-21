﻿using BackEnd.DAL;
using BackEnd.Entity;
using BackEnd.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BAL
{
    public class BALMission
    {
        private readonly DALMission _dalMission;     
        public BALMission(DALMission dalMission)
        {
            _dalMission = dalMission;
        }
        public List<DropDown> GetMissionThemeList()
        {
            return _dalMission.GetMissionThemeList();
        }
        public List<DropDown> GetMissionSkillList()
        {
            return _dalMission.GetMissionSkillList();
        }
        public List<Missions> MissionList()
        {
            return _dalMission.MissionList();
        }
        public string AddMission(Missions  mission)
        {
            return _dalMission.AddMission(mission);
        }       
        public Missions MissionDetailById(int id)
        {
            return _dalMission.MissionDetailById(id);
        }
        public string UpdateMission(Missions mission)
        {
            return _dalMission.UpdateMission(mission);
        }
        public string DeleteMission(int id)
        {
            return _dalMission.DeleteMission(id);
        }
        public List<MissionApplication> MissionApplicationList()
        {
            return _dalMission.MissionApplicationList();
        }

        public string MissionApplicationDelete(int id)
        {
            return _dalMission.MissionApplicationDelete(id);
        }
        public string MissionApplicationApprove(int id)
        {
            return _dalMission.MissionApplicationDelete(id);
        }
        

        public List<Missions> ClientSideMissionList(int userId)
        {
            return _dalMission.ClientSideMissionList(userId);
        } 
        public List<Missions> MissionClientList(SortestData data)
        {
            return _dalMission.MissionClientList(data);
        }
        public string ApplyMission(MissionApplication missionApplication)
        {
            return _dalMission.ApplyMission(missionApplication);
        }
        public Missions MissionDetailByMissionId(SortestData data)
        {
            return _dalMission.MissionDetailByMissionId(data);
        }
       public string AddMissionComment(MissionComment missionComment)
        {
            return _dalMission.AddMissionComment(missionComment);
        }

        public List<MissionComment> MissionCommentListByMissionId(int missionId)
        {
            return _dalMission.MissionCommentListByMissionId(missionId);
        }
        public string AddMissionFavourite(MissionFavourites missionFavourites)
        {
            return _dalMission.AddMissionFavourite(missionFavourites);
        } 
        public string RemoveMissionFavourite(MissionFavourites missionFavourites)
        {
            return _dalMission.RemoveMissionFavourite(missionFavourites);
        } 
        public string MissionRating(MissionRating missionRating)
        {
            return _dalMission.MissionRating(missionRating);
        }   
      
        public List<MissionApplication> RecentVolunteerList(MissionApplication missionApplication)
        {
            return _dalMission.RecentVolunteerList(missionApplication);
        }
        public List<User> GetUserList(int userId)
        {
            return _dalMission.GetUserList(userId);
        }
        public string SendInviteMissionMail(List<MissionShareOrInvite> user)
        {
            return _dalMission.SendInviteMissionMail(user);
        }
    }
}
